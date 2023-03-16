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
        if (IsPlayerXWinByFirstRow() || IsPlayerXWinBySecondRow() || IsPlayerXWinByThirdRow())
        {
            return "Player X Win";
        }

        if (IsPlayerOWinByFirstRow() || IsPlayerOWinBySecondRow() || IsPlayerOWinByThirdRow())
        {
            return "Player O Win";
        }

        if (Value[0, 0].Contains("X") && Value[1, 0].Contains("X") && Value[2, 0].Contains("X"))
        {
            return "Player X Win";
        }

        return "Draw";
    }
    private bool IsPlayerXWinByFirstRow()
    {
        return Value[0, 0].Contains("X") && Value[0, 1].Contains("X") && Value[0, 2].Contains("X");
    }
    private bool IsPlayerXWinBySecondRow()
    {
        return Value[1, 0].Contains("X") && Value[1, 1].Contains("X") && Value[1, 2].Contains("X");
    }

    private bool IsPlayerXWinByThirdRow()
    {
        return Value[2, 0].Contains("X") && Value[2, 1].Contains("X") && Value[2, 2].Contains("X");
    }
    private bool IsPlayerOWinByFirstRow()
    {
        return Value[0, 0].Contains("O") && Value[0, 1].Contains("O") && Value[0, 2].Contains("O");
    }
    private bool IsPlayerOWinBySecondRow()
    {
        return Value[1, 0].Contains("O") && Value[1, 1].Contains("O") && Value[1, 2].Contains("O");
    }

    private bool IsPlayerOWinByThirdRow()
    {
        return Value[2, 0].Contains("O") && Value[2, 1].Contains("O") && Value[2, 2].Contains("O");
    }
}