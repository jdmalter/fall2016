using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Artificial_Intelligence.Environment.Map.Tests
{
    [TestClass]
    public class MapStepCostFunctionTests
    {
        /// <summary>
        /// Subject under test.
        /// </summary>
        private MapStepCostFunction<IMapState, MapAction<IMapState>> _sut;

        /// <summary>
        /// Dependency of subject under test.
        /// </summary>
        private Mock<IDictionary<Tuple<IMapState, MapAction<IMapState>, IMapState>, double>> _stepCosts;

        [TestInitialize]
        public void TestInitialize()
        {
            _stepCosts = new Mock<IDictionary<Tuple<IMapState, MapAction<IMapState>, IMapState>, double>>();
            _sut = new MapStepCostFunction<IMapState, MapAction<IMapState>>(_stepCosts.Object);
        }

        [TestMethod]
        public void StepCostDefault()
        {
            // Arrange
            double value = 0;
            Tuple<IMapState, MapAction<IMapState>, IMapState> triple = new Tuple<IMapState, MapAction<IMapState>, IMapState>(null, null, null);
            _stepCosts.Setup(stepCosts => stepCosts.TryGetValue(triple, out value));

            // Act
            _sut.StepCost(triple.Item1, triple.Item2, triple.Item3);

            // Assert
            _stepCosts.Verify(_stepCosts => _stepCosts.TryGetValue(triple, out value));
            Assert.AreEqual(0, value);
        }

        [TestMethod]
        public void StepCostSuccessful()
        {
            // Arrange
            double expected = 5;
            Tuple<IMapState, MapAction<IMapState>, IMapState> triple = new Tuple<IMapState, MapAction<IMapState>, IMapState>(null, null, null);
            IDictionary<Tuple<IMapState, MapAction<IMapState>, IMapState>, double> stepCosts = new Dictionary<Tuple<IMapState, MapAction<IMapState>, IMapState>, double>()
            {
                [triple] = expected,
            };
            _sut = new MapStepCostFunction<IMapState, MapAction<IMapState>>(stepCosts);

            // Act
            double actual = _sut.StepCost(triple.Item1, triple.Item2, triple.Item3);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}