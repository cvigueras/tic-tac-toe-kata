namespace TicTacToe.Console;

public class Board
{
    private readonly Player _playerX;
    private readonly Player _playerO;
    public string[,] Value { get; }

    private Board(string[,] value)
    {
        Value = value;
        _playerX = Player.Create("X", "[X][X][X]");
        _playerO = Player.Create("Y", "[O][O][O]");
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
        return IsPlayerWin(_playerX) ? "Player X Win" : IsPlayerWin(_playerO) ? "Player O Win" : "Draw";
    }

    private bool IsPlayerWin(Player player)
    {
        return IsPlayerWinByRow(0,
                   player.MatchPlayerWin) ||
               IsPlayerWinByRow(1,
                   player.MatchPlayerWin) ||
               IsPlayerWinByRow(2,
                   player.MatchPlayerWin) ||
               IsPlayerWinByColumn(0, player.MatchPlayerWin) ||
               IsPlayerWinByColumn(1, player.MatchPlayerWin) ||
               IsPlayerWinByColumn(2, player.MatchPlayerWin);
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