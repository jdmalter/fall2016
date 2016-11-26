using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Artificial_Intelligence.Environment.Map.Tests
{
    [TestClass]
    public class MapGoalTestFunctionTests
    {
        /// <summary>
        /// Subject under test.
        /// </summary>
        private MapGoalTestFunction<IMapState> _sut;

        /// <summary>
        /// Dependency of subject under test.
        /// </summary>
        private Mock<IMapState> _goal;

        /// <summary>
        /// Parameter to subject under test.
        /// </summary>
        private Mock<IMapState> _state;

        [TestInitialize]
        public void TestInitialize()
        {
            _goal = new Mock<IMapState>();
            _state = new Mock<IMapState>();
            _sut = new MapGoalTestFunction<IMapState>(_goal.Object);
        }

        [TestMethod]
        public void NullGoal()
        {
            // Arrange
            _sut = null;

            try
            {
                // Act
                _sut = new MapGoalTestFunction<IMapState>(null);

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
            _goal.Setup(_goal => _goal.Equals(_state.Object)).Returns(true);

            // Act
            bool test = _sut.GoalTest(_state.Object);

            // Assert
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void GoalTestFalse()
        {
            // Arrange
            _goal.Setup(_goal => _goal.Equals(_state.Object)).Returns(false);

            // Act
            bool test = _sut.GoalTest(_state.Object);

            // Assert
            Assert.IsFalse(test);
        }
    }
}