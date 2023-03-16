using FluentAssertions;
using TicTacToe.Console;

namespace TicTacToe.Test
{
    public class BoardShould
    {
        private string[,] _givenBoard;
        private Board _board;

        [SetUp]
        public void Setup()
        {
            _givenBoard = new[,] { { "[ ]", "[ ]", "[ ]" }, { "[ ]", "[ ]", "[ ]" }, { "[ ]", "[ ]", "[ ]" } };
            _board = Board.Create(_givenBoard);
        }

        [Test]
        public void CreateEmptyBoard()
        {
            var result = Board.Create(_givenBoard);
            result.Value.Should().BeEquivalentTo(_givenBoard);
        }

        [Test]
        public void InsertFirstMotionForPlayerX()
        {
            var expectedBoard = new[,] { { "[X]", "[ ]", "[ ]" }, { "[ ]", "[ ]", "[ ]" }, { "[ ]", "[ ]", "[ ]" } };
            _board.InsertMotion("X", new Position(0, 0));
            _board.Value.Should().BeEquivalentTo(expectedBoard);
        }

        [Test]
        public void InsertSecondMotionForPlayerX()
        {
            var expectedBoard = new[,] { { "[X]", "[O]", "[X]" }, { "[ ]", "[ ]", "[ ]" }, { "[ ]", "[ ]", "[ ]" } };
            _board.InsertMotion("X", new Position(0, 0));
            _board.InsertMotion("O", new Position(0, 1));
            _board.InsertMotion("X", new Position(0, 2));
            _board.Value.Should().BeEquivalentTo(expectedBoard);
        }


        [Test]
        public void InsertFirstMotionForPlayerO()                                                                                                                                                                                                                                                                               
        {
            var expectedBoard = new[,] { { "[X]", "[O]", "[ ]" }, { "[ ]", "[ ]", "[ ]" }, { "[ ]", "[ ]", "[ ]" } };
            _board.InsertMotion("X", new Position(0, 0));
            _board.InsertMotion("O", new Position(0, 1));
            _board.Value.Should().BeEquivalentTo(expectedBoard);
        }


        [Test]
        public void InsertSecondMotionForPlayerO()
        {
            var expectedBoard = new[,] { { "[X]", "[O]", "[X]" }, { "[O]", "[ ]", "[ ]" }, { "[ ]", "[ ]", "[ ]" } };
            _board.InsertMotion("X", new Position(0, 0));
            _board.InsertMotion("O", new Position(0, 1));
            _board.InsertMotion("X", new Position(0, 2));
            _board.InsertMotion("O", new Position(1, 0));
            _board.Value.Should().BeEquivalentTo(expectedBoard);
        }

        [Test]
        public void InsertThirdMotionForPlayerX()
        {
            var expectedBoard = new[,] { { "[X]", "[O]", "[X]" }, { "[ ]", "[ ]", "[ ]" }, { "[ ]", "[ ]", "[X]" } };
            _board.InsertMotion("X", new Position(0, 0));
            _board.InsertMotion("O", new Position(0, 1));
            _board.InsertMotion("X", new Position(0, 2));
            _board.InsertMotion("X", new Position(2, 2));
            _board.Value.Should().BeEquivalentTo(expectedBoard);
        }

        [Test]
        public void InsertThirdMotionForPlayerO()
        {
            var expectedBoard = new[,] { { "[X]", "[O]", "[X]" }, { "[O]", "[O]", "[ ]" }, { "[ ]", "[ ]", "[X]" } };
            _board.InsertMotion("X", new Position(0, 0));
            _board.InsertMotion("O", new Position(0, 1));
            _board.InsertMotion("X", new Position(0, 2));
            _board.InsertMotion("O", new Position(1, 0));
            _board.InsertMotion("X", new Position(2, 2));
            _board.InsertMotion("O", new Position(1, 1));
            _board.Value.Should().BeEquivalentTo(expectedBoard);
        }

        [Test]
        public void WhenPlayerXWinByFirstRowShowPlayerXWin()
        {
            _board.InsertMotion("X", new Position(0, 0));
            _board.InsertMotion("O", new Position(2, 2));
            _board.InsertMotion("X", new Position(0, 1));
            _board.InsertMotion("O", new Position(2, 1));
            _board.InsertMotion("X", new Position(0, 2));
            var result = _board.HasWinnerPlayer();
            result.Should().Be("Player X Win");
        }

        [Test]
        public void WhenPlayerYWinByFirstRowShowPlayerXWin()
        {
            _board.InsertMotion("O", new Position(0, 0));
            _board.InsertMotion("X", new Position(2, 2));
            _board.InsertMotion("O", new Position(0, 1));
            _board.InsertMotion("X", new Position(2, 1));
            _board.InsertMotion("O", new Position(0, 2));
            var result = _board.HasWinnerPlayer();
            result.Should().Be("Player Y Win");
        }

        [Test]
        public void WhenPlayerXWinBySecondRowShowPlayerXWin()
        {
            _board.InsertMotion("X", new Position(1, 0));
            _board.InsertMotion("O", new Position(2, 2));
            _board.InsertMotion("X", new Position(1, 1));
            _board.InsertMotion("O", new Position(2, 1));
            _board.InsertMotion("X", new Position(1, 2));
            var result = _board.HasWinnerPlayer();
            result.Should().Be("Player X Win");
        }

        [Test]
        public void WhenPlayerYWinBySecondRowShowPlayerXWin()
        {
            _board.InsertMotion("O", new Position(1, 0));
            _board.InsertMotion("X", new Position(2, 2));
            _board.InsertMotion("O", new Position(1, 1));
            _board.InsertMotion("X", new Position(2, 1));
            _board.InsertMotion("O", new Position(1, 2));
            var result = _board.HasWinnerPlayer();
            result.Should().Be("Player O Win");
        }
    }
}