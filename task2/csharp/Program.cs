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

// --- FIGURES ---
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
