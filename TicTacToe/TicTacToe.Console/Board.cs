namespace TicTacToe.Console;

public class Board
{
    public object InitBoard()
    {
        return $"[ ][ ][ ]{Environment.NewLine}[ ][ ][ ]{Environment.NewLine}[ ][ ][ ]";
    }

    public object InsertMotion()
    {
        return $"[X][ ][ ]{Environment.NewLine}[ ][ ][ ]{Environment.NewLine}[ ][ ][ ]";
    }
}