using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Artificial_Intelligence.Environment.SlidingPuzzle.FifteenPuzzle.Tests
{
    [TestClass]
    public class FifteenPuzzleStateTests
    {
        /// <summary>
        /// Subject under test.
        /// </summary>
        private FifteenPuzzleState _sut;

        [TestMethod]
        public void NullLocationsParameter()
        {
            // Arrange
            uint[,] locations = null;
            _sut = null;

            try
            {
                // Act
                _sut = new FifteenPuzzleState(locations);

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
            uint length = FifteenPuzzleState.DefaultLength;
            uint[,] locations = new uint[length - 1, length];
            _sut = null;

            try
            {
                // Act
                _sut = new FifteenPuzzleState(locations);

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
            uint length = FifteenPuzzleState.DefaultLength;
            uint[,] locations = new uint[length, length - 1];
            _sut = null;

            try
            {
                // Act
                _sut = new FifteenPuzzleState(locations);

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
            FifteenPuzzleState copy = null;
            _sut = null;

            try
            {
                // Act
                _sut = new FifteenPuzzleState(copy);

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