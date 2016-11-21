using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Artificial_Intelligence.Environment.Queens.Tests
{
    [TestClass]
    public class QueensActionsFunctionTests
    {
        /// <summary>
        /// Subject under test.
        /// </summary>
        private QueensActionsFunction _sut;

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
            _sut = new QueensActionsFunction();
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
        public void AllActions()
        {
            // Arranage
            uint length = 3;
            SetLength(length);

            // Act
            _actions = _sut.Actions(_state.Object);

            // Assert
            Assert.AreEqual(length * length, (uint)_actions.Count);
            for (uint x = 0; x < length; x++)
            {
                for (uint y = 0; y < length; y++)
                {
                    Assert.IsTrue(_actions.Contains(QueensAction.Add(x, y)));
                }
            }
        }

        [TestMethod]
        public void AllActionsExceptOne()
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
            Assert.AreEqual((length * length) - 1, (uint)_actions.Count);
            for (uint x = 0; x < length; x++)
            {
                for (uint y = 0; y < length; y++)
                {
                    if (x != xException || y != yException)
                    {
                        Assert.IsTrue(_actions.Contains(QueensAction.Add(x, y)));
                    }
                    else
                    {
                        Assert.IsFalse(_actions.Contains(QueensAction.Add(x, y)));
                    }
                }
            }
        }
    }
}