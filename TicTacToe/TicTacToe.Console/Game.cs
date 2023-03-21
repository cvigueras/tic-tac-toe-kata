namespace TicTacToe.Console;

public class Game
{
    private readonly Player? _playerX;
    private readonly Player? _playerO;
    private Player? _playerWin;
    private int _maxNumbersPlays = 0;
    private const string Draw = "Draw";
    public Board? Board { get; }

    public Game()
    {
        _playerX = Player.Create(Token.X, "[X][X][X]");
        _playerO = Player.Create(Token.O, "[O][O][O]");
        Board = Board.Create(new[,] { { "[ ]", "[ ]", "[ ]" }, { "[ ]", "[ ]", "[ ]" }, { "[ ]", "[ ]", "[ ]" } });
    }

    public void InsertMotion(Token token, Position position)
    {
        if (Board == null) return;
        if (!IsValidMovement(position))
        {
            throw new Exception("Invalid movement!");
        }

        _maxNumbersPlays++;
        Board.Value[position.X, position.Y] = $"[{token}]";
    }

    private bool IsValidMovement(Position position)
    {
        return Board != null && position is { X: <= 2, Y: <= 2 } && Board.Value[position.X, position.Y].Equals("[ ]");
    }

    public string? HasWinnerPlayer()
    {
        SetPlayerWin();
        return _maxNumbersPlays < 9 ? _playerWin?.WinMessage : Draw;
    }

    private void SetPlayerWin()
    {
        SetPlayerWinByRowOrColumn(new Position(0, 0));
        SetPlayerWinByRowOrColumn(new Position(1, 1));
        SetPlayerWinByRowOrColumn(new Position(2, 2));
        IsPlayerWinByDiagonal(_playerX);
        IsPlayerWinByDiagonal(_playerO);
    }


    private void IsPlayerWinByDiagonal(Player? player)
    {
        if(Board?.Value[2, 0] + Board?.Value[1, 1] +
            Board?.Value[0, 2] == player?.MatchPlayerWin)
            _playerWin = player;
        if(Board?.Value[0, 0] + Board?.Value[1, 1] +
            Board?.Value[2, 2] == player?.MatchPlayerWin)
            _playerWin = player;
    }


    private void SetPlayerWinByRowOrColumn(Position position)
    {
        var isWinnerByRow = string.Empty;
        var isWinnerByColumn = string.Empty;
        for (var i = 0; i < Board?.Value.GetLength(0); i++)
        {
            for (var j = 0; j < Board.Value.GetLength(1); j++)
            {
                if (i == position.X)
                {
                    isWinnerByRow += Board.Value[i, j];
                }
                if (j == position.Y)
                {
                    isWinnerByColumn += Board.Value[i, j];
                }
            }
        }

        if (isWinnerByRow.Equals(_playerX?.MatchPlayerWin) ||
            isWinnerByColumn.Equals(_playerX?.MatchPlayerWin))
            _playerWin = _playerX;
        if (isWinnerByRow.Equals(_playerO?.MatchPlayerWin) ||
            isWinnerByColumn.Equals(_playerO?.MatchPlayerWin))
            _playerWin = _playerO;
    }
}