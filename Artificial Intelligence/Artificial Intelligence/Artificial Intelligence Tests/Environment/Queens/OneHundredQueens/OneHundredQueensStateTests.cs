using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Artificial_Intelligence.Environment.Queens.OneHundredQueens.Tests
{
    [TestClass]
    public class OneHundredQueensStateTests
    {
        /// <summary>
        /// Subject under test.
        /// </summary>
        private OneHundredQueensState _sut;

        [TestMethod]
        public void NullLocationsParameter()
        {
            // Arrange
            bool[,] locations = null;
            _sut = null;

            try
            {
                // Act
                _sut = new OneHundredQueensState(locations);

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
            uint length = OneHundredQueensState.DefaultLength;
            bool[,] locations = new bool[length - 1, length];
            _sut = null;

            try
            {
                // Act
                _sut = new OneHundredQueensState(locations);

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
            uint length = OneHundredQueensState.DefaultLength;
            bool[,] locations = new bool[length, length - 1];
            _sut = null;

            try
            {
                // Act
                _sut = new OneHundredQueensState(locations);

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
            OneHundredQueensState copy = null;
            _sut = null;

            try
            {
                // Act
                _sut = new OneHundredQueensState(copy);

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