using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Moq;
using System.Linq;

namespace Artificial_Intelligence.Environment.SlidingPuzzle.Tests
{
    [TestClass]
    public class SlidingPuzzleActionsFunctionTests
    {
        /// <summary>
        /// Subject under test.
        /// </summary>
        private SlidingPuzzleActionsFunction _sut;

        /// <summary>
        /// Parameter to subject under test.
        /// </summary>
        private Mock<ISlidingPuzzleState> _state;

        /// <summary>
        /// Return of subject under test.
        /// </summary>
        private ISet<SlidingPuzzleAction> _actions;

        [TestInitialize]
        public void TestInitialize()
        {
            _sut = new SlidingPuzzleActionsFunction();
            _state = new Mock<ISlidingPuzzleState>();
        }

        [TestMethod]
        public void NullStateParameter()
        {
            // Arrange
            _actions = null;

            try
            {
                // Act
                _actions = _sut.Actions(null);

                // Assert
                Assert.Fail("ArgumentNullException not thrown");
            }
            catch (ArgumentNullException)
            {
                // Assert
                Assert.IsNull(_actions);
            }
        }

        [TestMethod]
        public void EmptyActions()
        {
            // Act
            _actions = _sut.Actions(_state.Object);

            // Assert
            Assert.IsFalse(_actions.Any());
        }

        [TestMethod]
        public void ActionsUp()
        {
            // Arrange
            _state.Setup(_state => _state.CanMoveBlankSpaceUp()).Returns(true);

            // Act
            _actions = _sut.Actions(_state.Object);

            // Assert
            Assert.IsTrue(_actions.Contains(SlidingPuzzleAction.UP));
        }

        [TestMethod]
        public void ActionsDown()
        {
            // Arrange
            _state.Setup(_state => _state.CanMoveBlankSpaceDown()).Returns(true);

            // Act
            _actions = _sut.Actions(_state.Object);

            // Assert
            Assert.IsTrue(_actions.Contains(SlidingPuzzleAction.DOWN));
        }

        [TestMethod]
        public void ActionsLeft()
        {
            // Arrange
            _state.Setup(_state => _state.CanMoveBlankSpaceLeft()).Returns(true);

            // Act
            _actions = _sut.Actions(_state.Object);

            // Assert
            Assert.IsTrue(_actions.Contains(SlidingPuzzleAction.LEFT));
        }

        [TestMethod]
        public void ActionsRight()
        {
            // Arrange
            _state.Setup(_state => _state.CanMoveBlankSpaceRight()).Returns(true);

            // Act
            _actions = _sut.Actions(_state.Object);

            // Assert
            Assert.IsTrue(_actions.Contains(SlidingPuzzleAction.RIGHT));
        }
    }
}