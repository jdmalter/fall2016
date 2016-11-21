using Artificial_Intelligence.Chapter_3.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Artificial_Intelligence.Environment.Queens.Tests
{
    [TestClass]
    public class QueensProblemSolvingAgentProgramTests
    {
        /// <summary>
        /// Subject under test.
        /// </summary>
        private QueensProblemSolvingAgentProgram _sut;

        /// <summary>
        /// Dependency of subject under test.
        /// </summary>
        private Mock<IQueensState> _state;

        /// <summary>
        /// Dependency of subject under test.
        /// </summary>
        private Mock<ISearch<QueensProblem, IQueensState, QueensAction>> _search;

        [TestInitialize]
        public void TestInitialize()
        {
            _state = new Mock<IQueensState>();
            _search = new Mock<ISearch<QueensProblem, IQueensState, QueensAction>>();
            _sut = null;
        }

        [TestMethod]
        public void NullStateParameter()
        {
            try
            {
                // Act
                _sut = new QueensProblemSolvingAgentProgram(null, _search.Object);

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
                _sut = new QueensProblemSolvingAgentProgram(_state.Object, null);

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
            IList<QueensAction> actions = new List<QueensAction>();
            _search.Setup(search => search.Search(It.IsAny<QueensProblem>())).Returns(actions);
            _sut = new QueensProblemSolvingAgentProgram(_state.Object, _search.Object);

            // Act
            QueensAction actual = _sut.Invoke(null);

            // Assert
            Assert.AreEqual(QueensAction.NULL, actual);
        }

        [TestMethod]
        public void InvokeSomeActions()
        {
            // Arrange
            IList<QueensAction> actions = new List<QueensAction>()
            {
                QueensAction.Add(0, 0),
                QueensAction.Add(1, 1),
                QueensAction.Add(2, 2),
                QueensAction.Add(3, 3),
            };
            _search.Setup(search => search.Search(It.IsAny<QueensProblem>())).Returns(actions);
            _sut = new QueensProblemSolvingAgentProgram(_state.Object, _search.Object);

            // Act
            QueensAction actual = _sut.Invoke(null);

            // Assert
            Assert.AreEqual(QueensAction.Add(0, 0), actual);

            // Act
            actual = _sut.Invoke(null);

            // Assert
            Assert.AreEqual(QueensAction.Add(1, 1), actual);

            // Act
            actual = _sut.Invoke(null);

            // Assert
            Assert.AreEqual(QueensAction.Add(2, 2), actual);

            // Act
            actual = _sut.Invoke(null);

            // Assert
            Assert.AreEqual(QueensAction.Add(3, 3), actual);

            // Act
            actual = _sut.Invoke(null);

            // Assert
            Assert.AreEqual(QueensAction.NULL, actual);
        }
    }
}