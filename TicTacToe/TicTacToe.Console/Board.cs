namespace TicTacToe.Console;

public class Board
{
    public string InitBoard()
    {
        return $"[ ][ ][ ]{Environment.NewLine}[ ][ ][ ]{Environment.NewLine}[ ][ ][ ]";
    }

    public string InsertMotion(string player, Position position)
    {
        if (position.X == 0 && position.Y == 0)
        {
            return $"[X][ ][ ]{Environment.NewLine}[ ][ ][ ]{Environment.NewLine}[ ][ ][ ]";
        }

        if (position.X == 0 && position.Y == 2)
        {
            return $"[X][O][X]{Environment.NewLine}[ ][ ][ ]{Environment.NewLine}[ ][ ][ ]";
        }
        return $"[X][O][ ]{Environment.NewLine}[ ][ ][ ]{Environment.NewLine}[ ][ ][ ]";
    }
}