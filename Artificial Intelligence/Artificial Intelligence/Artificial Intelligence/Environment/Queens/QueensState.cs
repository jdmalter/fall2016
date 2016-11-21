using Artificial_Intelligence.Guard;
using System;
using System.Text;

namespace Artificial_Intelligence.Environment.Queens
{
    /// <summary>
    /// An agent's memory of its environment.
    /// </summary>
    public abstract class QueensState : IQueensState
    {
        /// <summary>
        /// A square two dimensional array of bool.
        /// </summary>
        private readonly bool[,] _locations;

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
        /// Specifies the number of elements in any dimension and a square two dimensional array of bool.
        /// </summary>
        /// <param name="length">The number of elements in any dimension.</param>
        /// <param name="locations">A square two dimensional array of bool.</param>
        public QueensState(uint length, bool[,] locations)
        {
            locations.NonNull();
            Length = length;

            if (Length != locations.GetLength(0) || Length != locations.GetLength(1))
            {
                throw new ArgumentException("The number of elements in any dimension must be " + length);
            }

            _locations = new bool[Length, Length];
            Array.Copy(locations, _locations, Length * Length);
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="copy">A QueensState being copied.</param>
        public QueensState(QueensState copy) : this(copy.NonNull().Length, copy._locations)
        {

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
        }

        /// <summary>
        /// If there is no queen at the given coordiantes, adds queen at the given coordinates and
        /// returns either the same instance of the unchanged state or a new instance of the updated state.
        /// </summary>
        /// <param name="x">A x dimension coordinate.</param>
        /// <param name="y">A y dimension coordinate.</param>
        /// <returns>Either the same instance of the unchanged state or
        /// a new instance of the updated state.</returns>
        public IQueensState AddQueen(uint x, uint y)
        {
            if (!this[x, y])
            {
                bool[,] locations = new bool[Length, Length];
                Array.Copy(_locations, locations, Length * Length);
                locations[x, y] = true;
                return Create(Length, locations);
            }

            return this;
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
        ///  Any implementation could add restrictions on top of this method.
        /// Specifies the number of elements in any dimension and a square two dimensional array of bool.
        /// Returns a new instance of state.
        /// </summary>
        /// <param name="length">The number of elements in any dimension.</param>
        /// <param name="locations">A square two dimensional array of bool.</param>
        /// <returns>A new instance of state.</returns>
        public abstract IQueensState Create(uint length, bool[,] locations);

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
            int hashCode = 0;

            for (uint x = 0; x < Length; x++)
            {
                for (uint y = 0; y < Length; y++)
                {
                    hashCode = (912935 * hashCode) + (this[x, y] ? 23 : 34);
                }
            }

            return hashCode;
        }

        /// <summary>
        /// The string represenation of this objects looks similar to an array initializer for uint[,].
        /// For each row, there are curly brackets on each end like "{...}".
        /// For each column, there is either a " Q " or " - " for whether or not there is a queen.
        /// For a 8 by 8 queens state, an example output would be
        /// { Q  -  -  -  -  -  -  - }
        /// { -  -  -  -  Q  -  -  - }
        /// { -  Q  -  -  -  -  -  - }
        /// { -  -  -  -  -  Q  -  - }
        /// { -  -  Q  -  -  -  -  - }
        /// { -  -  -  -  -  -  -  - }
        /// { -  -  -  Q  -  -  -  - }
        /// { -  -  -  -  -  -  -  Q }
        /// 
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            for (uint x = 0; x < Length; x++)
            {
                builder.Append("{");
                for (uint y = 0; y < Length; y++)
                {
                    builder.Append(this[x, y] ? " Q " : " - ");
                }
                builder.AppendLine("}");
            }

            return builder.ToString();
        }
    }
}
