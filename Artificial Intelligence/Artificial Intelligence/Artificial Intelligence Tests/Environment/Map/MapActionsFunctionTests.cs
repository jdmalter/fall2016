using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Moq;
using System.Linq;

namespace Artificial_Intelligence.Environment.Map.Tests
{
    [TestClass]
    public class MapActionsFunctionTests
    {
        /// <summary>
        /// Subject under test.
        /// </summary>
        private MapActionsFunction<IMapState, MapAction<IMapState>> _sut;

        /// <summary>
        /// Dependency of subject under test.
        /// </summary>
        private Mock<IDictionary<IMapState, ISet<MapAction<IMapState>>>> _dictionary;

        /// <summary>
        /// Parameter to subject under test.
        /// </summary>
        private Mock<IMapState> _state;

        /// <summary>
        /// Return of subject under test.
        /// </summary>
        private ISet<MapAction<IMapState>> _actions;

        [TestInitialize]
        public void TestInitialize()
        {
            _state = new Mock<IMapState>();
            _dictionary = new Mock<IDictionary<IMapState, ISet<MapAction<IMapState>>>>();
            _sut = new MapActionsFunction<IMapState, MapAction<IMapState>>(_dictionary.Object);
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
        public void NoActions()
        {
            // Arrange
            _dictionary.Setup(dictionary => dictionary.ContainsKey(_state.Object)).Returns(false);

            // Act
            _actions = _sut.Actions(_state.Object);

            // Assert
            Assert.IsFalse(_actions.Any());
        }

        [TestMethod]
        public void SomeActions()
        {
            // Arrange
            ISet<MapAction<IMapState>> expected = new HashSet<MapAction<IMapState>>()
            {
                null
            };
            _dictionary.Setup(dictionary => dictionary.ContainsKey(_state.Object)).Returns(true);
            _dictionary.Setup(dictionary => dictionary[_state.Object]).Returns(expected);

            // Act
            _actions = _sut.Actions(_state.Object);

            // Assert
            Assert.IsTrue(expected.SetEquals(_actions));
        }
    }
}