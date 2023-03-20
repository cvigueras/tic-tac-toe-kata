using FluentAssertions;
using TicTacToe.Console;

namespace TicTacToe.Test
{
    public class BoardShould
    {
        private string[,] _givenBoard;
        private Game _game;

        [SetUp]
        public void Setup()
        {
            _givenBoard = new[,] { { "[ ]", "[ ]", "[ ]" }, { "[ ]", "[ ]", "[ ]" }, { "[ ]", "[ ]", "[ ]" } };
            _game = new Game();
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
            _game.InsertMotion(Token.X, new Position(0, 0));
            _game.Board.Value.Should().BeEquivalentTo(expectedBoard);
        }

        [Test]
        public void InsertSecondMotionForPlayerX()
        {
            var expectedBoard = new[,] { { "[X]", "[O]", "[X]" }, { "[ ]", "[ ]", "[ ]" }, { "[ ]", "[ ]", "[ ]" } };
            _game.InsertMotion(Token.X, new Position(0, 0));
            _game.InsertMotion(Token.O, new Position(0, 1));
            _game.InsertMotion(Token.X, new Position(0, 2));
            _game.Board.Value.Should().BeEquivalentTo(expectedBoard);
        }


        [Test]
        public void InsertFirstMotionForPlayerO()                                                                                                                                                                                                                                                                               
        {
            var expectedBoard = new[,] { { "[X]", "[O]", "[ ]" }, { "[ ]", "[ ]", "[ ]" }, { "[ ]", "[ ]", "[ ]" } };
            _game.InsertMotion(Token.X, new Position(0, 0));
            _game.InsertMotion(Token.O, new Position(0, 1));
            _game.Board.Value.Should().BeEquivalentTo(expectedBoard);
        }


        [Test]
        public void InsertSecondMotionForPlayerO()
        {
            var expectedBoard = new[,] { { "[X]", "[O]", "[X]" }, { "[O]", "[ ]", "[ ]" }, { "[ ]", "[ ]", "[ ]" } };
            _game.InsertMotion(Token.X, new Position(0, 0));
            _game.InsertMotion(Token.O, new Position(0, 1));
            _game.InsertMotion(Token.X, new Position(0, 2));
            _game.InsertMotion(Token.O, new Position(1, 0));
            _game.Board.Value.Should().BeEquivalentTo(expectedBoard);
        }

        [Test]
        public void InsertThirdMotionForPlayerX()
        {
            var expectedBoard = new[,] { { "[X]", "[O]", "[X]" }, { "[ ]", "[ ]", "[ ]" }, { "[ ]", "[ ]", "[X]" } };
            _game.InsertMotion(Token.X, new Position(0, 0));
            _game.InsertMotion(Token.O, new Position(0, 1));
            _game.InsertMotion(Token.X, new Position(0, 2));
            _game.InsertMotion(Token.X, new Position(2, 2));
            _game.Board.Value.Should().BeEquivalentTo(expectedBoard);
        }

        [Test]
        public void InsertThirdMotionForPlayerO()
        {
            var expectedBoard = new[,] { { "[X]", "[O]", "[X]" }, { "[O]", "[O]", "[ ]" }, { "[ ]", "[ ]", "[X]" } };
            _game.InsertMotion(Token.X, new Position(0, 0));
            _game.InsertMotion(Token.O, new Position(0, 1));
            _game.InsertMotion(Token.X, new Position(0, 2));
            _game.InsertMotion(Token.O, new Position(1, 0));
            _game.InsertMotion(Token.X, new Position(2, 2));
            _game.InsertMotion(Token.O, new Position(1, 1));
            _game.Board.Value.Should().BeEquivalentTo(expectedBoard);
        }

        [Test]
        public void WhenPlayerXWinByFirstRowShowPlayerXWin()
        {
            _game.InsertMotion(Token.X, new Position(0, 0));
            _game.InsertMotion(Token.O, new Position(2, 2));
            _game.InsertMotion(Token.X, new Position(0, 1));
            _game.InsertMotion(Token.O, new Position(2, 1));
            _game.InsertMotion(Token.X, new Position(0, 2));
            var result = _game.HasWinnerPlayer();
            result.Should().Be("Player X Win");
        }

        [Test]
        public void WhenPlayerOWinByFirstRowShowPlayerOWin()
        {
            _game.InsertMotion(Token.O, new Position(0, 0));
            _game.InsertMotion(Token.X, new Position(2, 2));
            _game.InsertMotion(Token.O, new Position(0, 1));
            _game.InsertMotion(Token.X, new Position(2, 1));
            _game.InsertMotion(Token.O, new Position(0, 2));
            var result = _game.HasWinnerPlayer();
            result.Should().Be("Player O Win");
        }

        [Test]
        public void WhenPlayerXWinBySecondRowShowPlayerXWin()
        {
            _game.InsertMotion(Token.X, new Position(1, 0));
            _game.InsertMotion(Token.O, new Position(2, 2));
            _game.InsertMotion(Token.X, new Position(1, 1));
            _game.InsertMotion(Token.O, new Position(2, 1));
            _game.InsertMotion(Token.X, new Position(1, 2));
            var result = _game.HasWinnerPlayer();
            result.Should().Be("Player X Win");
        }

        [Test]
        public void WhenPlayerOWinBySecondRowShowPlayerOWin()
        {
            _game.InsertMotion(Token.O, new Position(1, 0));
            _game.InsertMotion(Token.X, new Position(2, 2));
            _game.InsertMotion(Token.O, new Position(1, 1));
            _game.InsertMotion(Token.X, new Position(2, 1));
            _game.InsertMotion(Token.O, new Position(1, 2));
            var result = _game.HasWinnerPlayer();
            result.Should().Be("Player O Win");
        }

        [Test]
        public void WhenPlayerXWinByThirdRowShowPlayerXWin()
        {
            _game.InsertMotion(Token.X, new Position(2, 0));
            _game.InsertMotion(Token.O, new Position(0, 2));
            _game.InsertMotion(Token.X, new Position(2, 1));
            _game.InsertMotion(Token.O, new Position(1, 1));
            _game.InsertMotion(Token.X, new Position(2, 2));
            var result = _game.HasWinnerPlayer();
            result.Should().Be("Player X Win");
        }

        [Test]
        public void WhenPlayerOWinByThirdRowShowPlayerOWin()
        {
            _game.InsertMotion(Token.O, new Position(2, 0));
            _game.InsertMotion(Token.X, new Position(1, 2));
            _game.InsertMotion(Token.O, new Position(2, 1));
            _game.InsertMotion(Token.X, new Position(1, 1));
            _game.InsertMotion(Token.O, new Position(2, 2));
            var result = _game.HasWinnerPlayer();
            result.Should().Be("Player O Win");
        }

        [Test]
        public void WhenPlayerXWinByFirstColumnShowPlayerXWin()
        {
            _game.InsertMotion(Token.X, new Position(0, 0));
            _game.InsertMotion(Token.O, new Position(2, 2));
            _game.InsertMotion(Token.X, new Position(1, 0));
            _game.InsertMotion(Token.O, new Position(2, 1));
            _game.InsertMotion(Token.X, new Position(2, 0));
            var result = _game.HasWinnerPlayer();
            result.Should().Be("Player X Win");
        }

        [Test]
        public void WhenPlayerOWinByFirstColumnShowPlayerOWin()
        {
            _game.InsertMotion(Token.O, new Position(0, 0));
            _game.InsertMotion(Token.X, new Position(2, 2));
            _game.InsertMotion(Token.O, new Position(1, 0));
            _game.InsertMotion(Token.X, new Position(2, 1));
            _game.InsertMotion(Token.O, new Position(2, 0));
            var result = _game.HasWinnerPlayer();
            result.Should().Be("Player O Win");
        }

        [Test]
        public void WhenPlayerXWinBySecondColumnShowPlayerXWin()
        {
            _game.InsertMotion(Token.X, new Position(0, 1));
            _game.InsertMotion(Token.O, new Position(2, 2));
            _game.InsertMotion(Token.X, new Position(1, 1));
            _game.InsertMotion(Token.O, new Position(2, 0));
            _game.InsertMotion(Token.X, new Position(2, 1));
            var result = _game.HasWinnerPlayer();
            result.Should().Be("Player X Win");
        }

        [Test]
        public void WhenPlayerOWinBySecondColumnShowPlayerOWin()
        {
            _game.InsertMotion(Token.O, new Position(0, 1));
            _game.InsertMotion(Token.X, new Position(2, 2));
            _game.InsertMotion(Token.O, new Position(1, 1));
            _game.InsertMotion(Token.X, new Position(2, 0));
            _game.InsertMotion(Token.O, new Position(2, 1));
            var result = _game.HasWinnerPlayer();
            result.Should().Be("Player O Win");
        }

        [Test]
        public void WhenPlayerXWinByThirdColumnShowPlayerXWin()
        {
            _game.InsertMotion(Token.X, new Position(0, 2));
            _game.InsertMotion(Token.O, new Position(2, 2));
            _game.InsertMotion(Token.X, new Position(1, 2));
            _game.InsertMotion(Token.O, new Position(2, 0));
            _game.InsertMotion(Token.X, new Position(2, 2));
            var result = _game.HasWinnerPlayer();
            result.Should().Be("Player X Win");
        }

        [Test]
        public void WhenPlayerOWinByThirdColumnShowPlayer0Win()
        {
            _game.InsertMotion(Token.O, new Position(0, 2));
            _game.InsertMotion(Token.X, new Position(2, 2));
            _game.InsertMotion(Token.O, new Position(1, 2));
            _game.InsertMotion(Token.X, new Position(2, 0));
            _game.InsertMotion(Token.O, new Position(2, 2));
            var result = _game.HasWinnerPlayer();
            result.Should().Be("Player O Win");
        }

        [Test]
        public void WhenPlayerXWinByFirstDiagonalShowPlayerXWin()
        {
            _game.InsertMotion(Token.X, new Position(0, 0));
            _game.InsertMotion(Token.O, new Position(2, 1));
            _game.InsertMotion(Token.X, new Position(1, 1));
            _game.InsertMotion(Token.O, new Position(2, 0));
            _game.InsertMotion(Token.X, new Position(2, 2));
            var result = _game.HasWinnerPlayer();
            result.Should().Be("Player X Win");
        }
    }
}