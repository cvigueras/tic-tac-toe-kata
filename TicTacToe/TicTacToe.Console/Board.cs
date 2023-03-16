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
        Value[position.X, position.Y] = $"[{player}]";
    }

    public string HasWinnerPlayer()
    {
        if (Value[0, 0].Contains("X") && Value[0, 1].Contains("X") && Value[0, 2].Contains("X"))
        {
            return "Player X Win";
        }

        return "Player Y Win";
    }
}