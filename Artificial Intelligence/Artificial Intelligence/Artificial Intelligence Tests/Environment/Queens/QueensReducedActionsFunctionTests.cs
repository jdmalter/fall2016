using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Artificial_Intelligence.Environment.Queens.Tests
{
    [TestClass]
    public class QueensReducedActionsFunctionTests
    {
        /// <summary>
        /// Subject under test.
        /// </summary>
        private QueensReducedActionsFunction _sut;

        /// <summary>
        /// Parameter to subject under test.
        /// </summary>
        private Mock<IQueensState> _state;

        /// <summary>
        /// Dependency of parameter to subject under test.
        /// </summary>
        private uint _length;

        /// <summary>
        /// Return of subject under test.
        /// </summary>
        private ISet<QueensAction> _actions;

        private void SetLength(uint length)
        {
            _length = length;
            _state.Setup(state => state.Length).Returns(_length);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _sut = new QueensReducedActionsFunction();
            _state = new Mock<IQueensState>();
            _state.Setup(state => state[It.IsAny<uint>(), It.IsAny<uint>()]).Returns(false);
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
        public void FirstRowActions()
        {
            // Arranage
            uint length = 3;
            SetLength(length);

            // Act
            _actions = _sut.Actions(_state.Object);

            // Assert
            Assert.AreEqual(length, (uint)_actions.Count);

            // First row
            for (uint y = 0; y < length; y++)
            {
                Assert.IsTrue(_actions.Contains(QueensAction.Add(0, y)));
            }

            // Other rows
            for (uint x = 1; x < length; x++)
            {
                for (uint y = 0; y < length; y++)
                {
                    Assert.IsFalse(_actions.Contains(QueensAction.Add(x, y)));
                }
            }
        }

        [TestMethod]
        public void SecondRowActions()
        {
            // Arranage
            uint length = 3;
            SetLength(length);
            uint xException = 0;
            uint yException = 0;
            _state.Setup(state => state[xException, yException]).Returns(true);

            // Act
            _actions = _sut.Actions(_state.Object);

            // Assert
            Assert.AreEqual(length, (uint)_actions.Count);

            // First row
            for (uint y = 0; y < length; y++)
            {
                Assert.IsFalse(_actions.Contains(QueensAction.Add(0, y)));
            }

            // Second row
            for (uint y = 0; y < length; y++)
            {
                Assert.IsTrue(_actions.Contains(QueensAction.Add(1, y)));
            }

            // Other rows
            for (uint x = 2; x < length; x++)
            {
                for (uint y = 0; y < length; y++)
                {
                    Assert.IsFalse(_actions.Contains(QueensAction.Add(x, y)));
                }
            }
        }
    }
}