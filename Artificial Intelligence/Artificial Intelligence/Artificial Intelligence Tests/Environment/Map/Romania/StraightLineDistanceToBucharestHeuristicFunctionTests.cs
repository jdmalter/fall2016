using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Artificial_Intelligence.Environment.Map.Romania.Tests
{
    [TestClass]
    public class StraightLineDistanceToBucharestHeuristicFunctionTests
    {
        /// <summary>
        /// Subject under test.
        /// </summary>
        private StraightLineDistanceToBucharestHeuristicFunction _sut;

        /// <summary>
        /// Parameter to subject under test.
        /// </summary>
        private RomaniaMapState _state;

        [TestInitialize]
        public void TestInitialize()
        {
            _sut = new StraightLineDistanceToBucharestHeuristicFunction();
        }

        [TestMethod]
        public void HeuristicZero()
        {
            // Arrange
            _state = RomaniaMapState.BUCHAREST;
            double expected = 0;

            // Act
            double actual = _sut.Heuristic(_state);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HeuristicSome()
        {
            // Arrange
            _state = RomaniaMapState.ARAD;
            double expected = 366;

            // Act
            double actual = _sut.Heuristic(_state);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}