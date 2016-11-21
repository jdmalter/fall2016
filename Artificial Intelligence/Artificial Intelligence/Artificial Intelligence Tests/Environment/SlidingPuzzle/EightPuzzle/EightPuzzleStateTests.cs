using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Artificial_Intelligence.Environment.SlidingPuzzle.EightPuzzle.Tests
{
    [TestClass]
    public class EightPuzzleStateTests
    {
        /// <summary>
        /// Subject under test.
        /// </summary>
        private EightPuzzleState _sut;

        [TestMethod]
        public void NullLocationsParameter()
        {
            // Arrange
            uint[,] locations = null;
            _sut = null;

            try
            {
                // Act
                _sut = new EightPuzzleState(locations);

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
            uint length = EightPuzzleState.DefaultLength;
            uint[,] locations = new uint[length - 1, length];
            _sut = null;

            try
            {
                // Act
                _sut = new EightPuzzleState(locations);

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
            uint length = EightPuzzleState.DefaultLength;
            uint[,] locations = new uint[length, length - 1];
            _sut = null;

            try
            {
                // Act
                _sut = new EightPuzzleState(locations);

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
            EightPuzzleState copy = null;
            _sut = null;

            try
            {
                // Act
                _sut = new EightPuzzleState(copy);

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