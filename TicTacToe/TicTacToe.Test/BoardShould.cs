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
        public void InsertFirstMotionForPlayerX()
        {
            var board = new Board();
            var result = board.InsertMotion("X", 0, 0);
            result.Should().Be($"[X][ ][ ]{Environment.NewLine}[ ][ ][ ]{Environment.NewLine}[ ][ ][ ]");
        }

        [Test]
        public void InsertFirstMotionForPlayerO()
        {
            var board = new Board();
            var result = board.InsertMotion("O", 0,1);
            result.Should().Be($"[X][O][ ]{Environment.NewLine}[ ][ ][ ]{Environment.NewLine}[ ][ ][ ]");
        }

    }
}
