using System;
using NUnit.Framework;

namespace Breakthrough
{
    [TestFixture]
    public class TestBreakthrough
    {
        private Breakthrough _game;

        [SetUp]
        public void SetUp()
        {
            _game = new Breakthrough();
        }

        [Test]
        public void ShouldHaveBlackPawnOn00()
        {
            Assert.That(PieceType.Black, Is.EqualTo(_game.GetPieceAt(0, 0)));
        }

        [Test]
        public void ShouldHaveWhitePawnOn1515()
        {
            Assert.That(PieceType.White, Is.EqualTo(_game.GetPieceAt(15, 15)));
        }

        [Test]
        public void ShouldBeginWithWhitePlayer()
        {
            Assert.That(_game.GetPlayerInTurn(),Is.EqualTo(PlayerType.White));
        }

        [Test]
        public void ShouldNotBeWinningFromStart()
        {
            Assert.That(_game.GetWinner(), Is.Null);
        }

        [Test]
        public void ShouldBeLegalMoveFromStart()
        {
            Assert.That(_game.IsMoveValid(14, 5, 13, 5), Is.True);
        }

        [Test]
        public void ShouldBeInvalidMoveFromStart()
        {
            Assert.That(_game.IsMoveValid(14, 5, 12, 5), Is.False);
        }

        [Test]
        public void ShouldBeMovingPieceForward()
        {
            Assert.That(PieceType.White, Is.EqualTo(_game.GetPieceAt(14, 7)));
            Assert.That(PieceType.None, Is.EqualTo(_game.GetPieceAt(13, 7)));
            _game.Move(14, 7, 13, 7);
            Assert.That(PieceType.None, Is.EqualTo(_game.GetPieceAt(14, 7)));
            Assert.That(PieceType.White, Is.EqualTo(_game.GetPieceAt(13, 7)));
        }

        [Test]
        public void ShouldBeMovingPieceLeftDiagonal()
        {
            Assert.That(PieceType.White, Is.EqualTo(_game.GetPieceAt(14, 7)));
            Assert.That(PieceType.None, Is.EqualTo(_game.GetPieceAt(13, 6)));
            _game.Move(14, 7, 13, 6);
            Assert.That(PieceType.None, Is.EqualTo(_game.GetPieceAt(14, 7)));
            Assert.That(PieceType.White, Is.EqualTo(_game.GetPieceAt(13, 6)));
        }

        [Test]
        public void ShouldBeMovingPieceRightDiagonal()
        {
            Assert.That(PieceType.White, Is.EqualTo(_game.GetPieceAt(14, 7)));
            Assert.That(PieceType.None, Is.EqualTo(_game.GetPieceAt(13, 8)));
            _game.Move(14, 7, 13, 8);
            Assert.That(PieceType.None, Is.EqualTo(_game.GetPieceAt(14, 7)));
            Assert.That(PieceType.White, Is.EqualTo(_game.GetPieceAt(13, 8)));
        }

        [Test]
        public void ShouldNotBeWinning()
        {
            _game.Move(14, 7, 13, 7);
            _game.Move(13, 7, 12, 7);
            _game.Move(12, 7, 11, 7);
            _game.Move(11, 7, 10, 7);
            _game.Move(10, 7, 9, 7);
            _game.Move(9, 7, 8, 7);
            _game.Move(8, 7, 7, 7);
            _game.Move(7, 7, 6, 7);
            _game.Move(6, 7, 5, 7);
            _game.Move(5, 7, 4, 7);
            _game.Move(4, 7, 3, 7);
            _game.Move(3, 7, 2, 7);
            _game.Move(2, 7, 1, 7);
            _game.Move(1, 7, 0, 7);
            Assert.That(_game.GetWinner(), Is.Null);
        }

        [Test]
        public void ShouldBeWinning()
        {
            _game.Move(14, 7, 13, 7);
            _game.Move(13, 7, 12, 7);
            _game.Move(12, 7, 11, 7);
            _game.Move(11, 7, 10, 7);
            _game.Move(10, 7, 9, 7);
            _game.Move(9, 7, 8, 7);
            _game.Move(8, 7, 7, 7);
            _game.Move(7, 7, 6, 7);
            _game.Move(6, 7, 5, 7);
            _game.Move(5, 7, 4, 7);
            _game.Move(4, 7, 3, 7);
            _game.Move(3, 7, 2, 7);
            _game.Move(2, 7, 1, 6);
            _game.Move(1, 6, 0, 7);
            Assert.That(_game.GetWinner(), Is.EqualTo(PlayerType.White));
        }
    }
}