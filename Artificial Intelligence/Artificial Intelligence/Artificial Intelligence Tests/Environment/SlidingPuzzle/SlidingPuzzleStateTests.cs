using Artificial_Intelligence.Environment.SlidingPuzzle.EightPuzzle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Artificial_Intelligence.Environment.SlidingPuzzle.Tests
{
    [TestClass]
    public class SlidingPuzzleStateTests
    {
        /// <summary>
        /// Subject under test.
        /// </summary>
        private ISlidingPuzzleState _sut;

        /// <summary>
        /// Dependency of subject under test.
        /// </summary>
        private uint[,] _locations;

        /// <summary>
        /// Return of subject under test.
        /// </summary>
        private ISlidingPuzzleState _actual;

        [TestMethod]
        public void CanMoveBlankSpaceUpTrue()
        {
            // Arrange
            _locations = new uint[,]
            {
                { 8, 7, 6, },
                { 4, 0, 1, },
                { 3, 2, 5, },
            };
            _sut = new EightPuzzleState(_locations);

            // Act
            bool test = _sut.CanMoveBlankSpaceUp();

            // Assert
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void CanMoveBlankSpaceDownTrue()
        {
            // Arrange
            _locations = new uint[,]
            {
                { 8, 7, 6, },
                { 4, 0, 1, },
                { 3, 2, 5, },
            };
            _sut = new EightPuzzleState(_locations);

            // Act
            bool test = _sut.CanMoveBlankSpaceDown();

            // Assert
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void CanMoveBlankSpaceLeftTrue()
        {
            // Arrange
            _locations = new uint[,]
            {
                { 8, 7, 6, },
                { 4, 0, 1, },
                { 3, 2, 5, },
            };
            _sut = new EightPuzzleState(_locations);

            // Act
            bool test = _sut.CanMoveBlankSpaceLeft();

            // Assert
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void CanMoveBlankSpaceRightTrue()
        {
            // Arrange
            _locations = new uint[,]
            {
                { 8, 7, 6, },
                { 4, 0, 1, },
                { 3, 2, 5, },
            };
            _sut = new EightPuzzleState(_locations);

            // Act
            bool test = _sut.CanMoveBlankSpaceRight();

            // Assert
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void CanMoveBlankSpaceUpFalse()
        {
            // Arrange
            _locations = new uint[,]
            {
                { 8, 0, 6, },
                { 4, 7, 1, },
                { 3, 2, 5, },
            };
            _sut = new EightPuzzleState(_locations);

            // Act
            bool test = _sut.CanMoveBlankSpaceUp();

            // Assert
            Assert.IsFalse(test);
        }

        [TestMethod]
        public void CanMoveBlankSpaceDownFalse()
        {
            // Arrange
            _locations = new uint[,]
            {
                { 8, 7, 6, },
                { 4, 2, 1, },
                { 3, 0, 5, },
            };
            _sut = new EightPuzzleState(_locations);

            // Act
            bool test = _sut.CanMoveBlankSpaceDown();

            // Assert
            Assert.IsFalse(test);
        }

        [TestMethod]
        public void CanMoveBlankSpaceLeftFalse()
        {
            // Arrange
            _locations = new uint[,]
            {
                { 8, 7, 6, },
                { 0, 4, 1, },
                { 3, 2, 5, },
            };
            _sut = new EightPuzzleState(_locations);

            // Act
            bool test = _sut.CanMoveBlankSpaceLeft();

            // Assert
            Assert.IsFalse(test);
        }

        [TestMethod]
        public void CanMoveBlankSpaceRightFalse()
        {
            // Arrange
            _locations = new uint[,]
            {
                { 8, 7, 6, },
                { 4, 1, 0, },
                { 3, 2, 5, },
            };
            _sut = new EightPuzzleState(_locations);

            // Act
            bool test = _sut.CanMoveBlankSpaceRight();

            // Assert
            Assert.IsFalse(test);
        }

        [TestMethod]
        public void MoveBlankSpaceUpSuccessfully()
        {
            // Arrange
            _locations = new uint[,]
            {
                { 8, 7, 6, },
                { 4, 0, 1, },
                { 3, 2, 5, },
            };
            _sut = new EightPuzzleState(_locations);

            // Act
            _actual = _sut.MoveBlankSpaceUp();

            // Assert
            Assert.AreNotEqual(_sut, _actual);
        }

        [TestMethod]
        public void MoveBlankSpaceDownSuccessfully()
        {
            // Arrange
            _locations = new uint[,]
            {
                { 8, 7, 6, },
                { 4, 0, 1, },
                { 3, 2, 5, },
            };
            _sut = new EightPuzzleState(_locations);

            // Act
            _actual = _sut.MoveBlankSpaceDown();

            // Assert
            Assert.AreNotEqual(_sut, _actual);
        }

        [TestMethod]
        public void MoveBlankSpaceLeftSuccessfully()
        {
            // Arrange
            _locations = new uint[,]
            {
                { 8, 7, 6, },
                { 4, 0, 1, },
                { 3, 2, 5, },
            };
            _sut = new EightPuzzleState(_locations);

            // Act
            _actual = _sut.MoveBlankSpaceLeft();

            // Assert
            Assert.AreNotEqual(_sut, _actual);
        }

        [TestMethod]
        public void MoveBlankSpaceRightSuccessfully()
        {
            // Arrange
            _locations = new uint[,]
            {
                { 8, 7, 6, },
                { 4, 0, 1, },
                { 3, 2, 5, },
            };
            _sut = new EightPuzzleState(_locations);

            // Act
            _actual = _sut.MoveBlankSpaceRight();

            // Assert
            Assert.AreNotEqual(_sut, _actual);
        }

        [TestMethod]
        public void MoveBlankSpaceUpUnsuccessfully()
        {
            // Arrange
            _locations = new uint[,]
            {
                { 8, 0, 6, },
                { 4, 7, 1, },
                { 3, 2, 5, },
            };
            _sut = new EightPuzzleState(_locations);

            // Act
            _actual = _sut.MoveBlankSpaceUp();

            // Assert
            Assert.AreEqual(_sut, _actual);
        }

        [TestMethod]
        public void MoveBlankSpaceDownUnsuccessfully()
        {
            // Arrange
            _locations = new uint[,]
            {
                { 8, 7, 6, },
                { 4, 2, 1, },
                { 3, 0, 5, },
            };
            _sut = new EightPuzzleState(_locations);

            // Act
            _actual = _sut.MoveBlankSpaceDown();

            // Assert
            Assert.AreEqual(_sut, _actual);
        }

        [TestMethod]
        public void MoveBlankSpaceLeftUnsuccessfully()
        {
            // Arrange
            _locations = new uint[,]
            {
                { 8, 7, 6, },
                { 0, 4, 1, },
                { 3, 2, 5, },
            };
            _sut = new EightPuzzleState(_locations);

            // Act
            _actual = _sut.MoveBlankSpaceLeft();

            // Assert
            Assert.AreEqual(_sut, _actual);
        }

        [TestMethod]
        public void MoveBlankSpaceRightUnsuccessfully()
        {
            // Arrange
            _locations = new uint[,]
            {
                { 8, 7, 6, },
                { 4, 1, 0, },
                { 3, 2, 5, },
            };
            _sut = new EightPuzzleState(_locations);

            // Act
            _actual = _sut.MoveBlankSpaceRight();

            // Assert
            Assert.AreEqual(_sut, _actual);
        }

        [TestMethod]
        public void EqualsSutTrue()
        {
            // Arrange
            _locations = new uint[,]
            {
                { 8, 7, 6, },
                { 4, 0, 1, },
                { 3, 2, 5, },
            };
            _sut = new EightPuzzleState(_locations);

            // Act
            bool equals = _sut.Equals(_sut);

            // Assert
            Assert.IsTrue(equals);
        }

        [TestMethod]
        public void EqualsNullObjParameterFalse()
        {
            // Arrange
            _locations = new uint[,]
            {
                { 8, 7, 6, },
                { 4, 0, 1, },
                { 3, 2, 5, },
            };
            _sut = new EightPuzzleState(_locations);

            // Act
            bool equals = _sut.Equals(null);

            // Assert
            Assert.IsFalse(equals);
        }

        [TestMethod]
        public void GetHashCodeTest()
        {
            // Arrange
            _locations = new uint[,]
            {
                { 8, 7, 6, },
                { 4, 0, 1, },
                { 3, 2, 5, },
            };
            _sut = new EightPuzzleState(_locations);
            int expected = 0;

            for (uint x = 0; x < _locations.GetLength(0); x++)
            {
                for (uint y = 0; y < _locations.GetLength(1); y++)
                {
                    expected = (912935 * expected) + (int)_locations[x, y];
                }
            }

            // Act
            int actual = _sut.GetHashCode();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}