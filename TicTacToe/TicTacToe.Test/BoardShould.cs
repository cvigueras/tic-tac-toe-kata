using FluentAssertions;
using TicTacToe.Console;

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

        [Test]
        public void InsertFirstMotion()
        {
            var board = new Board();
            var result = board.InsertMotion();
            result.Should().Be($"[X][ ][ ]{Environment.NewLine}[ ][ ][ ]{Environment.NewLine}[ ][ ][ ]");
        }

    }
}
