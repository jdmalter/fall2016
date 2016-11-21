using Artificial_Intelligence.Environment.Queens.EightQueens;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Artificial_Intelligence.Environment.Queens.Tests
{
    [TestClass]
    public class QueensStateTests
    {
        /// <summary>
        /// Subject under test.
        /// </summary>
        private IQueensState _sut;

        /// <summary>
        /// Dependency of subject under test.
        /// </summary>
        private bool[,] _locations;

        /// <summary>
        /// Return of subject under test.
        /// </summary>
        private IQueensState _actual;

        [TestInitialize]
        public void TestInitialize()
        {
            _locations = new bool[,]
            {
                { false, false, false, false, false, false, false, false, },
                { false, false, false, false, false, false, false, false, },
                { false, false, false, false, false, false, false, false, },
                { false, false, false, false, false, false, false, false, },
                { false, false, false, false, false, false, false, false, },
                { false, false, false, false, false, false, false, false, },
                { false, false, false, false, false, false, false, false, },
                { false, false, false, false, false, false, false, false, },
            };
            _sut = new EightQueensState(_locations);
        }

        [TestMethod]
        public void AllFalse()
        {
            for (uint x = 0; x < _sut.Length; x++)
            {
                for (uint y = 0; y < _sut.Length; y++)
                {
                    // Assert
                    Assert.IsFalse(_sut[x, y]);
                }
            }
        }

        [TestMethod]
        public void AddQueenSuccessfully()
        {
            // Arrange
            uint x = 0;
            uint y = 0;

            // Act
            _actual = _sut.AddQueen(x, y);

            // Assert
            Assert.AreNotEqual(_sut, _actual);
        }

        [TestMethod]
        public void AddQueenUnsuccessfully()
        {
            // Arrange
            uint x = 0;
            uint y = 0;
            _sut = _sut.AddQueen(x, y);

            // Act
            _actual = _sut.AddQueen(x, y);

            // Assert
            Assert.AreEqual(_sut, _actual);
        }

        [TestMethod]
        public void AttacksOn()
        {
            // Arrange
            uint x = 0;
            uint y = 0;
            uint Length = _sut.Length;
            _sut = _sut.AddQueen(x, y);

            // Horizontal
            for (uint i = 0; i < Length; i++)
            {
                uint count = i != x ? (uint)1 : 0;
                Assert.AreEqual(count, _sut.AttacksOn(i, y));
            }

            // Vertical
            for (uint j = 0; j < Length; j++)
            {
                uint count = j != y ? (uint)1 : 0;
                Assert.AreEqual(count, _sut.AttacksOn(x, j));
            }

            // Down diagonal
            bool top = x >= y;
            for (uint i = top ? x - y : 0, j = top ? 0 : y - x;
                i < Length && j < Length;
                i++, j++)
            {
                uint count = i != x ? (uint)1 : 0;
                Assert.AreEqual(count, _sut.AttacksOn(i, j));
            }

            // Up diagonal
            bool bottom = (x + y >= Length);
            for (uint i = bottom ? x + y - Length + 1 : 0, j = bottom ? Length - 1 : x + y;
                i < Length && j + 1 > j;
                i++, j--)
            {
                uint count = i != x ? (uint)1 : 0;
                Assert.AreEqual(count, _sut.AttacksOn(i, j));
            }
        }
    }
}