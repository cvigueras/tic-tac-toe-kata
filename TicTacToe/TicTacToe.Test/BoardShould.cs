using FluentAssertions;

namespace TicTacToe.Test
{
    public class BoardShould
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CreateEmptyBoard()
        {
            var board = new Board();
            var result = board.InitBoard();
            result.Should().Be($"[ ][ ][ ]{Environment.NewLine}[ ][ ][ ]{Environment.NewLine}[ ][ ][ ]");
        }
    }

    public class Board
    {
        public object InitBoard()
        {
            return $"[ ][ ][ ]{Environment.NewLine}[ ][ ][ ]{Environment.NewLine}[ ][ ][ ]";
        }
    }
}
