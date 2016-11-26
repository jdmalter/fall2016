using Artificial_Intelligence.Environment.Map.Romania;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Artificial_Intelligence.Environment.Map.Tests
{
    [TestClass]
    public class MapResultFunctionTests
    {
        /// <summary>
        /// Subject under test.
        /// </summary>
        private MapResultFunction<IMapState, MapAction<IMapState>> _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _sut = new MapResultFunction<IMapState, MapAction<IMapState>>();
        }

        [TestMethod]
        public void NullActionParameter()
        {
            // Arrange
            IMapState result = null;

            try
            {
                // Act
                result = _sut.Result(null, null);

                // Assert
                Assert.Fail("ArgumentNullException not thrown");
            }
            catch (ArgumentNullException)
            {
                // Assert
                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public void ResultState()
        {
            // Arrange
            Mock<IMapState> state = new Mock<IMapState>();
            Mock<MapAction<IMapState>> action = new Mock<MapAction<IMapState>>(state.Object);
            action.SetupGet(a => a.State).Returns(state.Object);

            // Act
            IMapState actual = _sut.Result(null, action.Object);

            // Assert
            action.VerifyGet(a => a.State);
            Assert.AreEqual(state.Object, actual);
        }
    }
}