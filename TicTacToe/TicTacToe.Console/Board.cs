namespace TicTacToe.Console;

public class Board
{
    public string InitBoard()
    {
        return $"[ ][ ][ ]{Environment.NewLine}[ ][ ][ ]{Environment.NewLine}[ ][ ][ ]";
    }

    public string InsertMotion()
    {
        return $"[X][ ][ ]{Environment.NewLine}[ ][ ][ ]{Environment.NewLine}[ ][ ][ ]";
    }
}