using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Artificial_Intelligence.Environment.SlidingPuzzle.Tests
{
    [TestClass]
    public class SlidingPuzzleManhattanHeuristicFunctionTests
    {
        /// <summary>
        /// Subject under test.
        /// </summary>
        private SlidingPuzzleManhattanHeuristicFunction _sut;

        /// <summary>
        /// Parameter to subject under test.
        /// </summary>
        private Mock<ISlidingPuzzleState> _state;

        [TestInitialize]
        public void TestInitialize()
        {
            _sut = new SlidingPuzzleManhattanHeuristicFunction();
            _state = new Mock<ISlidingPuzzleState>();
        }

        [TestMethod]
        public void ZeroManhattan()
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
        public void SomeManhattan()
        {
            // Arrange
            _state.Setup(state => state.Length).Returns(3);
            _state.Setup(state => state[0, 0]).Returns(7);
            _state.Setup(state => state[0, 1]).Returns(2);
            _state.Setup(state => state[0, 2]).Returns(4);
            _state.Setup(state => state[1, 0]).Returns(5);
            _state.Setup(state => state[1, 1]).Returns(0);
            _state.Setup(state => state[1, 2]).Returns(6);
            _state.Setup(state => state[2, 0]).Returns(8);
            _state.Setup(state => state[2, 1]).Returns(3);
            _state.Setup(state => state[2, 2]).Returns(1);
            double expected = 18;

            // Act
            double actual = _sut.Heuristic(_state.Object);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}