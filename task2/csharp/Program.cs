using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

// --- DATABASE LOGGING ---
// Extra: Database logging for valid moves, at the end of the game - read the chess.db file to show logged moves
public class DbLogger
{
    private SqliteConnection _conn;

    public DbLogger(string dbPath = "Data Source=chess.db")
    {
        _conn = new SqliteConnection(dbPath);
        _conn.Open();
        var cmd = _conn.CreateCommand();
        // Create a table to log valid moves
        cmd.CommandText = @"
            CREATE TABLE IF NOT EXISTS moves (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                piece_name TEXT NOT NULL,
                color TEXT NOT NULL,
                to_x INTEGER NOT NULL,
                to_y INTEGER NOT NULL
            )";
        cmd.ExecuteNonQuery();
    }

    public void LogMove(Piece piece, int x, int y)
    {
        var cmd = _conn.CreateCommand();
        cmd.CommandText = "INSERT INTO moves (piece_name, color, to_x, to_y) VALUES ($name, $color, $x, $y)";
        cmd.Parameters.AddWithValue("$name", piece.Name);
        cmd.Parameters.AddWithValue("$color", piece.Color);
        cmd.Parameters.AddWithValue("$x", x);
        cmd.Parameters.AddWithValue("$y", y);
        cmd.ExecuteNonQuery();
    }

    public void PrintLogs()
    {
        Console.WriteLine("\n--- ZAWARTOŚĆ BAZY DANYCH ---");
        var cmd = _conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM moves";
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                // Reading data from columns: id, piece_name, color, to_x, to_y
                Console.WriteLine($"({reader.GetInt32(0)}) {reader.GetString(1)} ({reader.GetString(2)}) -> X: {reader.GetInt32(3)}, Y: {reader.GetInt32(4)}");
            }
        }
    }
}


// --- CORE CLASSES ---
public class Player
{
    public string Name { get; }
    public string Color { get; }

    public Player(string name, string color)
    {
        Name = name;
        Color = color;
    }
}

// --- ABSTRACT CLASS FOR PIECES ---
public abstract class Piece
{
    public string Name { get; }
    public string Color { get; }
    public int X { get; set; }
    public int Y { get; set; }

    public Piece(string name, string color, int x, int y)
    {
        Name = name;
        Color = color;
        X = x;
        Y = y;
    }

    //method to check if the move is valid for the piece type
    public abstract bool CheckMove(int newX, int newY);
}

// --- PIECES ---
public class Pawn : Piece
{
    public Pawn(string color, int x, int y) : base("Pawn", color, x, y) { }

    // Pawns can move forward 1 square, or 2 squares from their starting position
    public override bool CheckMove(int newX, int newY)
    {
        if (Color == "white")
        {
            if (Y == 1) return (newX == X && newY == Y + 1) || (newX == X && newY == Y + 2);
            return newX == X && newY == Y + 1;
        }
        else if (Color == "black")
        {
            if (Y == 6) return (newX == X && newY == Y - 1) || (newX == X && newY == Y - 2);
            return newX == X && newY == Y - 1;
        }
        return false;
    }
}

public class Rook : Piece
{
    public Rook(string color, int x, int y) : base("Rook", color, x, y) { }

    public override bool CheckMove(int newX, int newY)
    {
        int dx = Math.Abs(newX - X);
        int dy = Math.Abs(newY - Y);
        return (dx == 0 && dy != 0) || (dx != 0 && dy == 0);
    }
}

public class Knight : Piece
{
    public Knight(string color, int x, int y) : base("Knight", color, x, y) { }

    public override bool CheckMove(int newX, int newY)
    {
        int dx = Math.Abs(newX - X);
        int dy = Math.Abs(newY - Y);
        return (dx == 2 && dy == 1) || (dx == 1 && dy == 2);
    }
}

public class Bishop : Piece
{
    public Bishop(string color, int x, int y) : base("Bishop", color, x, y) { }

    public override bool CheckMove(int newX, int newY)
    {
        int dx = Math.Abs(newX - X);
        int dy = Math.Abs(newY - Y);
        return dx == dy && dx > 0;
    }
}

public class Queen : Piece
{
    public Queen(string color, int x, int y) : base("Queen", color, x, y) { }

    public override bool CheckMove(int newX, int newY)
    {
        int dx = Math.Abs(newX - X);
        int dy = Math.Abs(newY - Y);
        return (dx == 0 && dy > 0) || (dx > 0 && dy == 0) || (dx == dy && dx > 0);
    }
}

public class King : Piece
{
    public King(string color, int x, int y) : base("King", color, x, y) { }

    public override bool CheckMove(int newX, int newY)
    {
        int dx = Math.Abs(newX - X);
        int dy = Math.Abs(newY - Y);
        return dx <= 1 && dy <= 1 && (dx > 0 || dy > 0);
    }
}

// --- BOARD ---
public class Board
{
    private List<Piece> pieces = new List<Piece>();
    private DbLogger dbLogger;

    public Board(DbLogger logger = null)
    {
        dbLogger = logger;
    }

    public void AddPiece(Piece piece)
    {
        pieces.Add(piece);
    }

    public void DisplayStatus()
    {
        Console.WriteLine("Aktualna pozycja figur:");
        foreach (var piece in pieces)
        {
            Console.WriteLine($"{piece.Name} ({piece.Color}) - pozycja: ({piece.X}, {piece.Y})");
        }
        Console.WriteLine("-------------------------------");
    }

    // Method to move a piece, with validation and logging
    public void MovePiece(Piece piece, int newX, int newY)
    {
        Console.WriteLine($"Próba przesunięcia {piece.Name} ({piece.Color}) z ({piece.X}, {piece.Y}) na ({newX}, {newY})");
        if (MoveValidator.IsMoveValid(piece, newX, newY))
        {
            // add kill logic
            Piece targetPiece = pieces.Find(p => p.X == newX && p.Y == newY);
            
            if (targetPiece != null)
            {
                if (targetPiece.Color == piece.Color)
                {
                    Console.WriteLine("Status: BŁĄD! Nie możesz stanąć na polu zajętym przez własną figurę.");
                    return;
                }
                else
                {
                    Console.WriteLine($"Status: BICIE! Figura {targetPiece.Name} ({targetPiece.Color}) została usunięta z planszy.");
                    pieces.Remove(targetPiece); 
                }
            }
            Console.WriteLine("Status: Ruch jest prawidłowy.");
            piece.X = newX;
            piece.Y = newY;

            //log the move in the database
            if (dbLogger != null)
            {
                dbLogger.LogMove(piece, newX, newY);
                Console.WriteLine("Zapisano log ruchu w bazie danych (SQLite).");
            }
        }
        else
        {
            Console.WriteLine("Status: BŁĄD! Ruch jest nieprawidłowy.");
        }
    }

    // check if the king of the given color is in check
    public bool IsInCheck(string color)
    {
        Piece king = pieces.Find(p => p is King && p.Color == color);
        if (king == null) return false;

        foreach (var piece in pieces)
        {
            if (piece.Color != color)
            {
                if (piece.CheckMove(king.X, king.Y)) return true;
            }
        }
        return false;
    }

    public void CheckGameState()
    {
        Console.WriteLine("Sprawdzanie stanu gry...");
        if (IsInCheck("white"))
        {
            Console.WriteLine("UWAGA: Biały król jest w szachu!");
        }
        else if (IsInCheck("black"))
        {
            Console.WriteLine("UWAGA: Czarny król jest w szachu!");
        }
        else
        {
            Console.WriteLine("Jest dobrze, brak szachów.");
        }
    }
}

public class MoveValidator
{
    public static bool IsMoveValid(Piece piece, int newX, int newY)
    {
        //check if the new position is within the board limits (0-7)
        if (newX < 0 || newX > 7 || newY < 0 || newY > 7) return false;
        
        // check if the move is valid for the piece type
        return piece.CheckMove(newX, newY);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Initialize the database connection
        DbLogger dbLogger = new DbLogger();

        // 1. Creating players and board
        Player player1 = new Player("Jan", "white");
        Player player2 = new Player("Anna", "black");
        Board board = new Board(logger: dbLogger);

        // 2. Creating pieces for both players
        Piece whiteKing = new King("white", 4, 0);
        Piece whitePawn = new Pawn("white", 4, 1);
        Piece blackRook = new Rook("black", 0, 7);
        Piece blackBishop = new Bishop("black", 2, 7);

        // 3. Adding pieces to the board
        board.AddPiece(whiteKing);
        board.AddPiece(whitePawn);
        board.AddPiece(blackRook);
        board.AddPiece(blackBishop);

        // 4. Initial state
        board.DisplayStatus();
        board.CheckGameState();

        //  --- Sequence of Moves ---

        // VALID: Pawn moves 2 squares forward from the start
        board.MovePiece(whitePawn, 4, 3);

        // INVALID: Rook tries to move diagonally
        board.MovePiece(blackRook, 1, 6);

        // INVALID: Rook tries to move out of bounds (y=8)
        board.MovePiece(blackRook, 0, 8);

        // VALID ATTACK: Rook moves in a straight line to the white King's row (y=0)
        board.MovePiece(blackRook, 0, 0);

        // Check game state - should result in a CHECK!
        board.CheckGameState();

        // VALID DEFENSIVE MOVE: King escapes
        board.MovePiece(whiteKing, 4, 1);

        // VALID MOVE: Black Rook moves under the White King
        board.MovePiece(blackRook, 4, 0);

        // VALID CAPTURE: White King captures the Black Rook!
        board.MovePiece(whiteKing, 4, 0);
        board.DisplayStatus();

        // Check game state after escape - check disappears
        board.CheckGameState();

        // Display final status of the board - read chess.db file to show logged moves
        dbLogger.PrintLogs();
    }
}