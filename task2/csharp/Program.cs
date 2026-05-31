using System;
using System.Collections.Generic;


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

// --- PIECES ---
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

    public void MovePiece(Piece piece, int newX, int newY)
    {
        Console.WriteLine($"Próba przesunięcia {piece.Name} ({piece.Color}) z ({piece.X}, {piece.Y}) na ({newX}, {newY})");
        if (MoveValidator.IsMoveValid(piece, newX, newY))
        {
            Console.WriteLine("Status: Ruch jest prawidłowy.");
            piece.X = newX;
            piece.Y = newY;
        }
        else
        {
            Console.WriteLine("Status: BŁĄD! Ruch jest nieprawidłowy.");
        }
    }

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