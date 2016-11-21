using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Artificial_Intelligence.Environment.Queens.EightQueens.Tests
{
    [TestClass]
    public class EightQueensStateTests
    {
        /// <summary>
        /// Subject under test.
        /// </summary>
        private EightQueensState _sut;

        [TestMethod]
        public void NullLocationsParameter()
        {
            // Arrange
            bool[,] locations = null;
            _sut = null;

            try
            {
                // Act
                _sut = new EightQueensState(locations);

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
        public void InvalidLengthZeroLocationsParameter()
        {
            // Arrange
            uint length = EightQueensState.DefaultLength;
            bool[,] locations = new bool[length - 1, length];
            _sut = null;

            try
            {
                // Act
                _sut = new EightQueensState(locations);

                // Assert
                Assert.Fail("ArgumentException not thrown");
            }
            catch (ArgumentException)
            {
                // Assert
                Assert.IsNull(_sut);
            }
        }

        [TestMethod]
        public void InvalidLengthOneLocationsParameter()
        {
            // Arrange
            uint length = EightQueensState.DefaultLength;
            bool[,] locations = new bool[length, length - 1];
            _sut = null;

            try
            {
                // Act
                _sut = new EightQueensState(locations);

                // Assert
                Assert.Fail("ArgumentException not thrown");
            }
            catch (ArgumentException)
            {
                // Assert
                Assert.IsNull(_sut);
            }
        }

        [TestMethod]
        public void NullCopyParameter()
        {
            // Arrange
            EightQueensState copy = null;
            _sut = null;

            try
            {
                // Act
                _sut = new EightQueensState(copy);

                // Assert
                Assert.Fail("ArgumentNullException not thrown");
            }
            catch (ArgumentNullException)
            {
                // Assert
                Assert.IsNull(_sut);
            }
        }
    }
}