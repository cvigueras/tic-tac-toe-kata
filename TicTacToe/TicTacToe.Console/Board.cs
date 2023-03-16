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
        return IsPlayerXWin() ? "Player X Win" : IsPlayerYWin() ? "Player O Win" : "Draw";
    }

    private bool IsPlayerYWin()
    {
        return IsPlayerWinByRow(0,
                   "[O][O][O]") ||
               IsPlayerWinByRow(1,
                   "[O][O][O]") ||
               IsPlayerWinByRow(2,
                   "[O][O][O]") ||
               IsPlayerWinByColumn(0, "[O][O][O]") ||
               IsPlayerWinByColumn(1, "[O][O][O]");
    }

    private bool IsPlayerXWin()
    {
        return IsPlayerWinByRow(0,
                   "[X][X][X]") ||
               IsPlayerWinByRow(1,
                   "[X][X][X]") ||
               IsPlayerWinByRow(2,
                   "[X][X][X]") ||
               IsPlayerWinByColumn(0, "[X][X][X]") ||
               IsPlayerWinByColumn(1, "[X][X][X]");
    }

    private bool IsPlayerWinByColumn(int numberColumn, string matchPlayerWin)
    {
        string isWinner = string.Empty;
        var playerXWinner = matchPlayerWin;
        for (var i = 0; i < Value.GetLength(0); i++)
        {
            for (var j = 0; j < Value.GetLength(1); j++)
            {
                if (j == numberColumn)
                {
                    isWinner += Value[i, j];
                }
            }
        }

        return isWinner.Equals(playerXWinner);
    }

    private bool IsPlayerWinByRow(int numberRow, string matchPlayerWin)
    {
        string isWinner = string.Empty;
        for (var i = 0; i < Value.GetLength(0); i++)
        {
            for (var j = 0; j < Value.GetLength(1); j++)
            {
                if (i == numberRow)
                {
                    isWinner += Value[i, j];
                }
            }
        }

        return isWinner.Equals(matchPlayerWin);
    }
}