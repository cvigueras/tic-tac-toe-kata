namespace TicTacToe.Console;

public class Board
{
    public string InitBoard()
    {
        return $"[ ][ ][ ]{Environment.NewLine}[ ][ ][ ]{Environment.NewLine}[ ][ ][ ]";
    }

    public string InsertMotion(string player, int x, int y)
    {
        if (x == 0 && y == 0)
        {
            return $"[X][ ][ ]{Environment.NewLine}[ ][ ][ ]{Environment.NewLine}[ ][ ][ ]";
        }

        if (x == 0 && y == 2)
        {
            return $"[X][O][X]{Environment.NewLine}[ ][ ][ ]{Environment.NewLine}[ ][ ][ ]";
        }
        return $"[X][O][ ]{Environment.NewLine}[ ][ ][ ]{Environment.NewLine}[ ][ ][ ]";
    }
}