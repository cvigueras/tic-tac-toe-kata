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
        if (IsPlayerXWinByFirstRow())
        {
            return "Player X Win";
        }
        if (IsPlayerXWinBySecondRow())
        {
            return "Player X Win";
        }
        if (IsPlayerYWinByFirstRow())
        {
            return "Player O Win";
        }

        return "Player Y Win";
    }

    private bool IsPlayerYWinByFirstRow()
    {
        return Value[1, 0].Contains("O") && Value[1, 1].Contains("O") && Value[1, 2].Contains("O");
    }

    private bool IsPlayerXWinBySecondRow()
    {
        return Value[1, 0].Contains("X") && Value[1, 1].Contains("X") && Value[1, 2].Contains("X");
    }

    private bool IsPlayerXWinByFirstRow()
    {
        return Value[0, 0].Contains("X") && Value[0, 1].Contains("X") && Value[0, 2].Contains("X");
    }
}