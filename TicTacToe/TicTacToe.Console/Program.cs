using TicTacToe.Console;

var numberMatch = 9;
Position coordinates;
int x;
int y;
var game = new Game();
Console.WriteLine("   ===============================");
Console.WriteLine("     Welcome to TIC TAC TOE Game");
Console.WriteLine("   ===============================");
while(numberMatch >= 9)
{
    Console.WriteLine();
    if (game != null)
    {
        var token = game.GetCurrentTokenPlayer();
        Console.WriteLine(
            $"{Environment.NewLine} Please 'Player {token}' write the coordinates to place your token (example ==> 1,0)");
        SetPosition();
        try
        {
            game.InsertMotion(token, coordinates);
            numberMatch++;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex.Message);
            continue;
        }
    }

    PrintBoard(game);
    if (CheckWinner(game)) return;
}

void PrintBoard(Game? game1)
{
    for (var i = 0; i < game1?.Board?.Value.GetLength(0); i++)
    {
        if (i != 0)
        {
            Console.WriteLine(Environment.NewLine);
        }

        for (var j = 0; j < game1.Board?.Value.GetLength(1); j++)
        {
            Console.Write(game1.Board.Value[i, j]);
        }
    }
}

bool CheckWinner(Game? game2)
{
    if (string.IsNullOrEmpty(game2?.HasWinnerPlayer())) return false;
    Console.WriteLine(Environment.NewLine + game2.HasWinnerPlayer());
    return true;

}

void SetPosition()
{
    var position = Console.ReadLine()?.Split(',');

    x = Convert.ToInt32(position?[0]);
    y = Convert.ToInt32(position?[1]);
    coordinates = new Position(x, y);
    Console.Clear();
}
