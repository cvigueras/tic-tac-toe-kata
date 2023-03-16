namespace TicTacToe.Console;

public class Board
{
    public string[,] Value { get; }

    private Board(string[,] value)
    {
        Value = value;
    }

    public static Board? Create(string[,] value)
    {
        return new Board(value);
    }

    public void InsertMotion(string player, Position position)
    {
        Value[position.X,position.Y] = $"[{player}]";
    }

    public string IsPlayerXWinner()
    {
        return "Player X Win";
    }
}