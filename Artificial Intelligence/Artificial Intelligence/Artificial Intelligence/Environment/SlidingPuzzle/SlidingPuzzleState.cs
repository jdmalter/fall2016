using Artificial_Intelligence.Guard;
using System;
using System.Text;

namespace Artificial_Intelligence.Environment.SlidingPuzzle
{
    /// <summary>
    /// An agent's memory of its environment.
    /// </summary>
    public abstract class SlidingPuzzleState : ISlidingPuzzleState
    {
        /// <summary>
        /// A square two dimensional array of values.
        /// </summary>
        private readonly uint[,] _locations;

        /// <summary>
        /// Specifies the number of elements in any dimension and a square two dimensional array of values.
        /// </summary>
        /// <param name="length">The number of elements in any dimension.</param>
        /// <param name="locations">A square two dimensional array of values.</param>
        public SlidingPuzzleState(uint length, uint[,] locations)
        {
            locations.NonNull();
            Length = length;

            if (Length != locations.GetLength(0) || Length != locations.GetLength(1))
            {
                throw new ArgumentException("The number of elements in any dimension must be " + length);
            }

            _locations = new uint[Length, Length];
            Array.Copy(locations, _locations, Length * Length);
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="copy">An SlidingPuzzleState being copied.</param>
        public SlidingPuzzleState(SlidingPuzzleState copy) : this(copy.NonNull().Length, copy._locations)
        {

        }

        /// <summary>
        /// The number of elements in any dimension.
        /// </summary>
        public uint Length { get; }

        /// <summary>
        /// Gets a value at the given coordiantes.
        /// </summary>
        /// <param name="x">A x dimension coordinate.</param>
        /// <param name="y">A y dimension coordinate.</param>
        /// <returns>A value at the given coordiantes.</returns>
        public uint this[uint x, uint y] { get { return _locations[x, y]; } }

        /// <summary>
        /// Determines whether the blank space can move up.
        /// </summary>
        /// <returns>Whether the blank space can move up.</returns>
        public bool CanMoveBlankSpaceUp()
        {
            Location location = GetLocation(0);
            return location != null && location.X > 0;
        }

        /// <summary>
        /// Determines whether the blank space can move down.
        /// </summary>
        /// <returns>Whether the blank space can move down.</returns>
        public bool CanMoveBlankSpaceDown()
        {
            Location location = GetLocation(0);
            return location != null && location.X < Length - 1;
        }

        /// <summary>
        /// Determines whether the blank space can move left.
        /// </summary>
        /// <returns>Whether the blank space can move left.</returns>
        public bool CanMoveBlankSpaceLeft()
        {
            Location location = GetLocation(0);
            return location != null && location.Y > 0;
        }

        /// <summary>
        /// Determines whether the blank space can move right.
        /// </summary>
        /// <returns>Whether the blank space can move right.</returns>
        public bool CanMoveBlankSpaceRight()
        {
            Location location = GetLocation(0);
            return location != null && location.Y < Length - 1;
        }

        /// <summary>
        /// Specifies the number of elements in any dimension and a square two dimensional array of values.
        /// Returns a new instance of state.
        /// </summary>
        /// <param name="length">The number of elements in any dimension.</param>
        /// <param name="locations">A square two dimensional array of values.</param>
        /// <returns>A new instance of state.</returns>
        public abstract ISlidingPuzzleState Create(uint length, uint[,] locations);

        /// <summary>
        /// If possible, moves the blank space up and
        /// returns the same instance of the unchanged state or a new instance of the updated state.
        /// </summary>
        /// <returns>The same instance of the unchanged state or
        /// a new instance of the updated state.</returns>
        public ISlidingPuzzleState MoveBlankSpaceUp()
        {
            Location location = GetLocation(0);

            if (null != location && location.X > 0)
            {
                uint[,] locations = new uint[Length, Length];
                Array.Copy(_locations, locations, Length * Length);
                locations[location.X, location.Y] = this[location.X - 1, location.Y];
                locations[location.X - 1, location.Y] = this[location.X, location.Y];
                return Create(Length, locations);
            }

            return this;
        }

        /// <summary>
        /// If possible, moves the blank space down and
        /// returns the same instance of the unchanged state or a new instance of the updated state.
        /// </summary>
        /// <returns>The same instance of the unchanged state
        /// or a new instance of the updated state.</returns>
        public ISlidingPuzzleState MoveBlankSpaceDown()
        {
            Location location = GetLocation(0);

            if (null != location && location.X < Length - 1)
            {
                uint[,] locations = new uint[Length, Length];
                Array.Copy(_locations, locations, Length * Length);
                locations[location.X, location.Y] = this[location.X + 1, location.Y];
                locations[location.X + 1, location.Y] = this[location.X, location.Y];
                return Create(Length, locations);
            }

            return this;
        }

        /// <summary>
        /// If possible, moves the blank space left and
        /// returns the same instance of the unchanged state or a new instance of the updated state.
        /// </summary>
        /// <returns>The same instance of the unchanged state
        /// or a new instance of the updated state.</returns>
        public ISlidingPuzzleState MoveBlankSpaceLeft()
        {
            Location location = GetLocation(0);

            if (null != location && location.Y > 0)
            {
                uint[,] locations = new uint[Length, Length];
                Array.Copy(_locations, locations, Length * Length);
                locations[location.X, location.Y] = this[location.X, location.Y - 1];
                locations[location.X, location.Y - 1] = this[location.X, location.Y];
                return Create(Length, locations);
            }

            return this;
        }

        /// <summary>
        /// If possible, moves the blank space right and
        /// returns the same instance of the unchanged state or a new instance of the updated state.
        /// </summary>
        /// <returns>The same instance of the unchanged state
        /// or a new instance of the updated state.</returns>
        public ISlidingPuzzleState MoveBlankSpaceRight()
        {
            Location location = GetLocation(0);

            if (null != location && location.Y < Length - 1)
            {
                uint[,] locations = new uint[Length, Length];
                Array.Copy(_locations, locations, Length * Length);
                locations[location.X, location.Y] = this[location.X, location.Y + 1];
                locations[location.X, location.Y + 1] = this[location.X, location.Y];
                return Create(Length, locations);
            }

            return this;
        }

        /// <summary>
        /// Returns a single point in a two dimensional space whose value equals the given value.
        /// </summary>
        /// <param name="value">A value.</param>
        /// <returns>A single point in a two dimensional space./returns>
        private Location GetLocation(uint value)
        {
            for (uint x = 0; x < Length; x++)
            {
                for (uint y = 0; y < Length; y++)
                {
                    if (this[x, y] == value)
                    {
                        return new Location(x, y);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Determines whether the given object is equal to the current object.
        /// </summary>
        /// <param name="obj">Any object.</param>
        /// <returns>Whether the given object is equal to the current object.</returns>
        public override bool Equals(object obj)
        {
            SlidingPuzzleState state = obj as SlidingPuzzleState;

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
        /// Uses hash function of a square two dimensional array of values.
        /// </summary>
        /// <returns>A hash code for a square two dimensional array of values.</returns>
        public override int GetHashCode()
        {
            int hashCode = 0;

            for (uint x = 0; x < Length; x++)
            {
                for (uint y = 0; y < Length; y++)
                {
                    hashCode = (912935 * hashCode) + (int)this[x, y];
                }
            }

            return hashCode;
        }

        /// <summary>
        /// The string represenation of this objects looks similar to an array initializer for uint[,].
        /// For each row, there are curly brackets on each end and a space after the first bracket like "{ ...}".
        /// For each column, there is the value, a comma, and a space like "N, ".
        /// For a 3 by 3 sliding puzzle state, an example output would be
        /// { 0, 1, 2, }
        /// { 3, 4, 5, }
        /// { 6, 7, 8, }
        /// 
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            for (uint x = 0; x < Length; x++)
            {
                builder.Append("{ ");
                for (uint y = 0; y < Length; y++)
                {
                    builder.AppendFormat("{0,4} ", this[x, y]);
                }
                builder.AppendLine("}");
            }

            return builder.ToString();
        }
    }
}
