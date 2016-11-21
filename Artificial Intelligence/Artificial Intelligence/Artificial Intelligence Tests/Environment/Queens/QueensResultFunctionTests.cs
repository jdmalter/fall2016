using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Artificial_Intelligence.Environment.Queens.Tests
{
    [TestClass]
    public class QueensResultFunctionTests
    {
        /// <summary>
        /// Subject under test.
        /// </summary>
        private QueensResultFunction _sut;

        /// <summary>
        /// Parameter of subject under test.
        /// </summary>
        private Mock<IQueensState> _state;

        /// <summary>
        /// Parameter of subject under test.
        /// </summary>
        private QueensAction _action;

        [TestInitialize]
        public void TestInitialize()
        {
            _sut = new QueensResultFunction();
            _state = new Mock<IQueensState>();
        }

        [TestMethod]
        public void NullStateParameter()
        {
            // Arrange
            IQueensState _outputState = null;

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
            IQueensState _outputState = null;

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
        public void ResultNull()
        {
            // Arrange
            uint x = 0;
            uint y = 0;
            _action = QueensAction.NULL;

            // Act
            _sut.Result(_state.Object, _action);

            // Assert
            _state.Verify(state => state.AddQueen(x, y), Times.Never());
        }

        [TestMethod]
        public void ResultAdd()
        {
            // Arrange
            uint x = 0;
            uint y = 0;
            _action = QueensAction.Add(x, y);

            // Act
            _sut.Result(_state.Object, _action);

            // Assert
            _state.Verify(state => state.AddQueen(x, y));
        }
    }
}