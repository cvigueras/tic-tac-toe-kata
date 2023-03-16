namespace TicTacToe.Console;

public class Game
{
    private readonly Board? _board;
    private readonly Player _playerX;
    private readonly Player _playerO;
    public Board? Board => _board;

    public Game()
    {
        _playerX = Player.Create(Token.X, "[X][X][X]");
        _playerO = Player.Create(Token.O, "[O][O][O]");
        _board = Board.Create(new[,] { { "[ ]", "[ ]", "[ ]" }, { "[ ]", "[ ]", "[ ]" }, { "[ ]", "[ ]", "[ ]" } });
    }

    public void InsertMotion(Token token, Position position)
    {
        if (_board != null)
        {
            _board.Value[position.X, position.Y] = $"[{token}]";
        }
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
               IsPlayerWinByColumn(0, player) ||
               IsPlayerWinByColumn(1, player) ||
               IsPlayerWinByColumn(2, player);
    }

    private bool IsPlayerWinByColumn(int numberColumn, Player player)
    {
        var isWinner = string.Empty;
        if (_board != null)
        {
            for (var i = 0; i < _board.Value.GetLength(0); i++)
            {
                for (var j = 0; j < _board.Value.GetLength(1); j++)
                {
                    if (j == numberColumn)
                    {
                        isWinner += _board.Value[i, j];
                    }
                }
            }
        }

        return isWinner.Equals(player.MatchPlayerWin);
    }

    private bool IsPlayerWinByRow(int numberRow, string matchPlayerWin)
    {
        var isWinner = string.Empty;
        if (_board != null)
        {
            for (var i = 0; i < _board.Value.GetLength(0); i++)
            {
                for (var j = 0; j < _board.Value.GetLength(1); j++)
                {
                    if (i == numberRow)
                    {
                        isWinner += _board.Value[i, j];
                    }
                }
            }
        }

        return isWinner.Equals(matchPlayerWin);
    }
}