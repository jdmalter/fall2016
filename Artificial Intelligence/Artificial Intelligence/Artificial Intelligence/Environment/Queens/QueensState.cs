using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Guard;
using System;

namespace Artificial_Intelligence.Environment.Queens
{
    /// <summary>
    /// An agent's memory of its environment.
    /// </summary>
    public abstract class QueensState : IState
    {
        /// <summary>
        /// A square two dimensional array of bool.
        /// </summary>
        private bool[,] _locations;

        /// <summary>
        /// Specifies the number of elements in any dimension and creates an empty board.
        /// </summary>
        /// <param name="length">The number of elements in any dimension.</param>
        public QueensState(uint length)
        {
            Length = length;
            _locations = new bool[Length, Length];
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="copy">A QueensState being copied.</param>
        public QueensState(QueensState copy) : this(copy.NonNull().Length)
        {
            Array.Copy(copy._locations, _locations, Length * Length);
        }

        /// <summary>
        /// The number of elements in any dimension.
        /// </summary>
        public uint Length { get; }

        /// <summary>
        /// Gets and sets whether there is a queen at the given coordiantes.
        /// </summary>
        /// <param name="x">A x dimension coordinate.</param>
        /// <param name="y">A y dimension coordinate.</param>
        /// <returns>Whether there is a queen at the given coordiantes.</returns>
        public bool this[uint x, uint y]
        {
            get { return _locations[x, y]; }
            set { _locations[x, y] = value; }
        }

        /// <summary>
        /// Sums the number of queens in the same row, column, or diagonal as the coordinates.
        /// </summary>
        /// <param name="x">A x dimension coordinate.</param>
        /// <param name="y">A y dimension coordinate.</param>
        /// <returns>The number of queens in the same row, column, or diagonal as the coordinates.</returns>
        public uint AttacksOn(uint x, uint y)
        {
            uint count = 0;

            // Horizontal
            for (uint i = 0; i < Length; i++)
            {
                if (this[i, y] && i != x)
                {
                    count++;
                }
            }

            // Vertical
            for (uint j = 0; j < Length; j++)
            {
                if (this[x, j] && j != y)
                {
                    count++;
                }
            }

            // Down diagonal
            bool top = x >= y;
            for (uint i = top ? x - y : 0, j = top ? 0 : y - x;
                i < Length && j < Length;
                i++, j++)
            {
                if (this[i, j] && i != x)
                {
                    count++;
                }
            }

            // Up diagonal
            bool bottom = (x + y >= Length);
            for (uint i = bottom ? x + y - Length + 1 : 0, j = bottom ? Length - 1 : x + y;
                i < Length && j + 1 > j;
                i++, j--)
            {
                if (this[i, j] && i != x)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Determines whether the given object is equal to the current object.
        /// </summary>
        /// <param name="obj">Any object.</param>
        /// <returns>Whether the given object is equal to the current object.</returns>
        public override bool Equals(object obj)
        {
            QueensState state = obj as QueensState;

            if (null == state || Length != state.Length)
            {
                return false;
            }

            for (uint x = 0; x < Length; x++)
            {
                for (uint y = 0; y < Length; y++)
                {
                    if (this[x, y] != state[x, y])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Uses hash function of a square two dimensional array of bool.
        /// </summary>
        /// <returns>A hash code for a square two dimensional array of bool.</returns>
        public override int GetHashCode()
        {
            return _locations.GetHashCode();
        }
    }
}
