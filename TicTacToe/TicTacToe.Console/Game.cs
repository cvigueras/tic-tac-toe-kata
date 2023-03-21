﻿namespace TicTacToe.Console;

public class Game
{
    private readonly Player _playerX;
    private readonly Player _playerO;
    private const string PlayerXWin = "Player X Win";
    private const string PlayerOWin = "Player O Win";
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
        if (Board != null)
        {
            Board.Value[position.X, position.Y] = $"[{token}]";
        }
    }

    public string HasWinnerPlayer()
    {
        if (IsPlayerWinByDiagonal(_playerX)) return PlayerXWin;
        if (IsPlayerWin(_playerX)) return PlayerXWin;
        if (IsPlayerWinByDiagonal(_playerO)) return PlayerOWin;
        if (IsPlayerWin(_playerO)) return PlayerOWin;
        return Draw;
    }

    private bool IsPlayerWin(Player player)
    {
        return IsPlayerWinByRow(0,
                   player.MatchPlayerWin) ||
               IsPlayerWinByRow(1,
                   player.MatchPlayerWin) ||
               IsPlayerWinByRow(2,
                   player.MatchPlayerWin) ||
               IsPlayerWinByColumn(new Position(0, 0), player) ||
               IsPlayerWinByColumn(new Position(0, 1), player) ||
               IsPlayerWinByColumn(new Position(0, 2), player);
    }


    private bool IsPlayerWinByDiagonal(Player player)
    {
        return Board?.Value[2, 0] + Board?.Value[1, 1] +
            Board?.Value[0, 2] == player.MatchPlayerWin || Board?.Value[0, 0] + Board?.Value[1, 1] +
            Board?.Value[2, 2] == player.MatchPlayerWin;
    }


    private bool IsPlayerWinByColumn(Position position, Player player)
    {
        var isWinner = string.Empty;
        if (Board == null) return isWinner.Equals(player.MatchPlayerWin);
        for (var i = 0; i < Board.Value.GetLength(0); i++)
        {
            for (var j = 0; j < Board.Value.GetLength(1); j++)
            {
                if (j == position.Y)
                {
                    isWinner += Board.Value[i, j];
                }
            }
        }

        return isWinner.Equals(player.MatchPlayerWin);
    }

    private bool IsPlayerWinByRow(int numberRow, string matchPlayerWin)
    {
        var isWinner = string.Empty;
        if (Board == null) return isWinner.Equals(matchPlayerWin);
        for (var i = 0; i < Board.Value.GetLength(0); i++)
        {
            for (var j = 0; j < Board.Value.GetLength(1); j++)
            {
                if (i == numberRow)
                {
                    isWinner += Board.Value[i, j];
                }
            }
        }

        return isWinner.Equals(matchPlayerWin);
    }
}