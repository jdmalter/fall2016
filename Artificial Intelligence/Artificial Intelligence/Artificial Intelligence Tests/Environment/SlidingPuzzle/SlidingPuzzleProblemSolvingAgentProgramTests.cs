using Artificial_Intelligence.Chapter_3.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Artificial_Intelligence.Environment.SlidingPuzzle.Tests
{
    [TestClass]
    public class SlidingPuzzleProblemSolvingAgentProgramTests
    {
        /// <summary>
        /// Subject under test.
        /// </summary>
        private SlidingPuzzleProblemSolvingAgentProgram _sut;

        /// <summary>
        /// Dependency of subject under test.
        /// </summary>
        private Mock<ISlidingPuzzleState> _state;

        /// <summary>
        /// Dependency of subject under test.
        /// </summary>
        private Mock<ISlidingPuzzleState> _goal;

        /// <summary>
        /// Dependency of subject under test.
        /// </summary>
        private Mock<ISearch<SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction>> _search;

        [TestInitialize]
        public void TestInitialize()
        {
            _state = new Mock<ISlidingPuzzleState>();
            _goal = new Mock<ISlidingPuzzleState>();
            _search = new Mock<ISearch<SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction>>();
            _sut = null;
        }

        [TestMethod]
        public void NullStateParameter()
        {
            try
            {
                // Act
                _sut = new SlidingPuzzleProblemSolvingAgentProgram(null, _search.Object, _goal.Object);

                // Assert
                Assert.Fail("ArgumentNullException not thrown");
            }
            catch (ArgumentNullException)
            {
                // Assert
                Assert.IsNull(_sut);
            }
        }

        [TestMethod]
        public void NullSearchParameter()
        {
            try
            {
                // Act
                _sut = new SlidingPuzzleProblemSolvingAgentProgram(_state.Object, null, _goal.Object);

                // Assert
                Assert.Fail("ArgumentNullException not thrown");
            }
            catch (ArgumentNullException)
            {
                // Assert
                Assert.IsNull(_sut);
            }
        }

        [TestMethod]
        public void NullGoalParameter()
        {
            try
            {
                // Act
                _sut = new SlidingPuzzleProblemSolvingAgentProgram(_state.Object, _search.Object, null);

                // Assert
                Assert.Fail("ArgumentNullException not thrown");
            }
            catch (ArgumentNullException)
            {
                // Assert
                Assert.IsNull(_sut);
            }
        }

        [TestMethod]
        public void InvokeNoActions()
        {
            // Arrange
            IList<SlidingPuzzleAction> actions = new List<SlidingPuzzleAction>();
            _search.Setup(search => search.Search(It.IsAny<SlidingPuzzleProblem>())).Returns(actions);
            _sut = new SlidingPuzzleProblemSolvingAgentProgram(_state.Object, _search.Object, _goal.Object);

            // Act
            SlidingPuzzleAction actual = _sut.Invoke(null);

            // Assert
            Assert.AreEqual(SlidingPuzzleAction.NULL, actual);
        }

        [TestMethod]
        public void InvokeSomeActions()
        {
            // Arrange
            IList<SlidingPuzzleAction> actions = new List<SlidingPuzzleAction>()
            {
                SlidingPuzzleAction.UP,
                SlidingPuzzleAction.DOWN,
                SlidingPuzzleAction.LEFT,
                SlidingPuzzleAction.RIGHT,
            };
            _search.Setup(search => search.Search(It.IsAny<SlidingPuzzleProblem>())).Returns(actions);
            _sut = new SlidingPuzzleProblemSolvingAgentProgram(_state.Object, _search.Object, _goal.Object);

            // Act
            SlidingPuzzleAction actual = _sut.Invoke(null);

            // Assert
            Assert.AreEqual(SlidingPuzzleAction.UP, actual);

            // Act
            actual = _sut.Invoke(null);

            // Assert
            Assert.AreEqual(SlidingPuzzleAction.DOWN, actual);

            // Act
            actual = _sut.Invoke(null);

            // Assert
            Assert.AreEqual(SlidingPuzzleAction.LEFT, actual);

            // Act
            actual = _sut.Invoke(null);

            // Assert
            Assert.AreEqual(SlidingPuzzleAction.RIGHT, actual);

            // Act
            actual = _sut.Invoke(null);

            // Assert
            Assert.AreEqual(SlidingPuzzleAction.NULL, actual);
        }
    }
}