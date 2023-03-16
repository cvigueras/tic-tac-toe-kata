// See https://aka.ms/new-console-template for more information

using TicTacToe.Console;

const int numeMatchs = 9;
Board? board = Board.Create(new[,] { { "[ ]", "[ ]", "[ ]" }, { "[ ]", "[ ]", "[ ]" }, { "[ ]", "[ ]", "[ ]" } });

for (var i = 0; i < numeMatchs; i++)
{
    Console.WriteLine();
    Console.WriteLine("What player are you? ( X o O ):");
    var player = Console.ReadLine();
    Console.WriteLine("Please write the coordinates to place your token (example ==> 1,0");
    var coordinates = Console.ReadLine();
    var coord = coordinates?.Split(',');
    var x = Convert.ToInt32(coord?[0]);
    var y = Convert.ToInt32(coord?[1]);
    Position position = new Position(x, y);
    if (player != null) board?.InsertMotion(player, position);
    if (board != null)
        for (var j = 0; j < board.Value.GetLength(0); j++)
        {
            if (j != 0)
            {
                Console.WriteLine(Environment.NewLine);
            }

            for (var k = 0; k < board.Value.GetLength(1); k++)
            {
                Console.Write(board.Value[j, k]);
            }
        }
}
