using Artificial_Intelligence.Environment.SlidingPuzzle.EightPuzzle;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Artificial_Intelligence.Environment.SlidingPuzzle.Tests
{
    [TestClass]
    public class SlidingPuzzleMisplacedTilesHeuristicFunctionTests
    {
        /// <summary>
        /// Subject under test.
        /// </summary>
        private SlidingPuzzleMisplacedTilesHeuristicFunction _sut;

        /// <summary>
        /// Parameter to subject under test.
        /// </summary>
        private Mock<ISlidingPuzzleState> _state;

        [TestInitialize]
        public void TestInitialize()
        {
            _sut = new SlidingPuzzleMisplacedTilesHeuristicFunction();
            _state = new Mock<ISlidingPuzzleState>();
        }

        [TestMethod]
        public void NoMisplacedTiles()
        {
            // Arrange
            _state.Setup(state => state.Length).Returns(3);
            _state.Setup(state => state[0, 0]).Returns(0);
            _state.Setup(state => state[0, 1]).Returns(1);
            _state.Setup(state => state[0, 2]).Returns(2);
            _state.Setup(state => state[1, 0]).Returns(3);
            _state.Setup(state => state[1, 1]).Returns(4);
            _state.Setup(state => state[1, 2]).Returns(5);
            _state.Setup(state => state[2, 0]).Returns(6);
            _state.Setup(state => state[2, 1]).Returns(7);
            _state.Setup(state => state[2, 2]).Returns(8);
            double expected = 0;

            // Act
            double actual = _sut.Heuristic(_state.Object);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AllMisplacedTiles()
        {
            // Arrange
            _state.Setup(state => state.Length).Returns(3);
            _state.Setup(state => state[0, 0]).Returns(1);
            _state.Setup(state => state[0, 1]).Returns(2);
            _state.Setup(state => state[0, 2]).Returns(3);
            _state.Setup(state => state[1, 0]).Returns(4);
            _state.Setup(state => state[1, 1]).Returns(5);
            _state.Setup(state => state[1, 2]).Returns(6);
            _state.Setup(state => state[2, 0]).Returns(7);
            _state.Setup(state => state[2, 1]).Returns(8);
            _state.Setup(state => state[2, 2]).Returns(0);
            double expected = 8;

            // Act
            double actual = _sut.Heuristic(_state.Object);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}