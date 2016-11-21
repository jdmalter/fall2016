using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Artificial_Intelligence.Environment.SlidingPuzzle.Tests
{
    [TestClass]
    public class SlidingPuzzleResultFunctionTests
    {
        /// <summary>
        /// Subject under test.
        /// </summary>
        private SlidingPuzzleResultFunction _sut;

        /// <summary>
        /// Parameter of subject under test.
        /// </summary>
        private Mock<ISlidingPuzzleState> _state;

        [TestInitialize]
        public void TestInitialize()
        {
            _sut = new SlidingPuzzleResultFunction();
            _state = new Mock<ISlidingPuzzleState>();
        }

        [TestMethod]
        public void NullStateParameter()
        {
            // Arrange
            ISlidingPuzzleState _outputState = null;

            try
            {
                // Act
                _outputState = _sut.Result(null, null);

                // Assert
                Assert.Fail("ArgumentNullException not thrown");
            }
            catch (ArgumentNullException)
            {
                // Assert
                Assert.IsNull(_outputState);
            }
        }

        [TestMethod]
        public void NullActionParameter()
        {
            // Arrange
            ISlidingPuzzleState _outputState = null;

            try
            {
                // Act
                _outputState = _sut.Result(_state.Object, null);

                // Assert
                Assert.Fail("ArgumentNullException not thrown");
            }
            catch (ArgumentNullException)
            {
                // Assert
                Assert.IsNull(_outputState);
            }
        }

        [TestMethod]
        public void ResultUp()
        {
            // Arrange
            _state.Setup(state => state.CanMoveBlankSpaceUp()).Returns(true);

            // Act
            _sut.Result(_state.Object, SlidingPuzzleAction.UP);

            // Assert
            _state.Verify(state => state.MoveBlankSpaceUp());
        }

        [TestMethod]
        public void ResultDown()
        {
            // Arrange
            _state.Setup(state => state.CanMoveBlankSpaceDown()).Returns(true);

            // Act
            _sut.Result(_state.Object, SlidingPuzzleAction.DOWN);

            // Assert
            _state.Verify(state => state.MoveBlankSpaceDown());
        }

        [TestMethod]
        public void ResultLeft()
        {
            // Arrange
            _state.Setup(state => state.CanMoveBlankSpaceLeft()).Returns(true);

            // Act
            _sut.Result(_state.Object, SlidingPuzzleAction.LEFT);

            // Assert
            _state.Verify(state => state.MoveBlankSpaceLeft());
        }

        [TestMethod]
        public void ResultRight()
        {
            // Arrange
            _state.Setup(state => state.CanMoveBlankSpaceRight()).Returns(true);

            // Act
            _sut.Result(_state.Object, SlidingPuzzleAction.RIGHT);

            // Assert
            _state.Verify(state => state.MoveBlankSpaceRight());
        }
    }
}