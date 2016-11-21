using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Artificial_Intelligence.Environment.Queens.Tests
{
    [TestClass]
    public class QueensGoalTestFunctionTests
    {
        /// <summary>
        /// Subject under test.
        /// </summary>
        private QueensGoalTestFunction _sut;

        /// <summary>
        /// Parameter to subject under test.
        /// </summary>
        private Mock<IQueensState> _state;

        [TestInitialize]
        public void TestInitialize()
        {
            _sut = new QueensGoalTestFunction();
            _state = new Mock<IQueensState>();

            _state.Setup(state => state.Length).Returns(8);
            _state.Setup(state => state[It.IsAny<uint>(), It.IsAny<uint>()]).Returns(false);
            _state.Setup(state => state.AttacksOn(It.IsAny<uint>(), It.IsAny<uint>())).Returns(0);
        }

        [TestMethod]
        public void NullStateParameter()
        {
            // Arrange
            bool test = true;

            try
            {
                // Act
                test = _sut.GoalTest(null);

                // Assert
                Assert.Fail("ArgumentNullException not thrown");
            }
            catch (ArgumentNullException)
            {
                // Assert
                Assert.IsTrue(test);
            }
        }

        [TestMethod]
        public void GoalTestTrue()
        {
            // Arrange
            _state.Setup(state => state[0, 1]).Returns(true);
            _state.Setup(state => state[1, 3]).Returns(true);
            _state.Setup(state => state[2, 5]).Returns(true);
            _state.Setup(state => state[3, 7]).Returns(true);
            _state.Setup(state => state[4, 2]).Returns(true);
            _state.Setup(state => state[5, 0]).Returns(true);
            _state.Setup(state => state[6, 4]).Returns(true);
            _state.Setup(state => state[7, 6]).Returns(true);

            // Act
            bool test = _sut.GoalTest(_state.Object);

            // Assert
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void GoalTestFalse()
        {
            // Act
            bool test = _sut.GoalTest(_state.Object);

            // Assert
            Assert.IsFalse(test);
        }
    }
}