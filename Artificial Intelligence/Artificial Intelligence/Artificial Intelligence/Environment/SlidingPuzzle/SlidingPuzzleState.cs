using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Guard;
using System;
using System.Linq;

namespace Artificial_Intelligence.Environment.SlidingPuzzle
{
    /// <summary>
    /// An agent's memory of its environment.
    /// </summary>
    public abstract class SlidingPuzzleState : IState
    {
        /// <summary>
        /// A square two dimensional array of values.
        /// </summary>
        private uint[,] _locations;

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
        /// Gets and sets a value at the given coordiantes.
        /// </summary>
        /// <param name="x">A x dimension coordinate.</param>
        /// <param name="y">A y dimension coordinate.</param>
        /// <returns>A value at the given coordiantes.</returns>
        private uint this[uint x, uint y]
        {
            get { return _locations[x, y]; }
            set { _locations[x, y] = value; }
        }

        /// <summary>
        /// Gets and sets a value at the given pair of coordiantes.
        /// </summary>
        /// <param name="coordinate">A pair of coordinates.</param>
        /// <returns>A value at the given pair of coordiantes.</returns>
        private uint this[Tuple<uint, uint> coordinate]
        {
            get { return _locations[coordinate.Item1, coordinate.Item2]; }
            set { _locations[coordinate.Item1, coordinate.Item2] = value; }
        }

        /// <summary>
        /// Determines whether the blank space can move up.
        /// </summary>
        /// <returns>Whether the blank space can move up.</returns>
        public bool CanMoveBlankSpaceUp()
        {
            Tuple<uint, uint> location = GetLocation(0);
            return (location.Item2 < Length - 1);
        }

        /// <summary>
        /// Determines whether the blank space can move down.
        /// </summary>
        /// <returns>Whether the blank space can move down.</returns>
        public bool CanMoveBlankSpaceDown()
        {
            Tuple<uint, uint> location = GetLocation(0);
            return (location.Item2 > 0);
        }

        /// <summary>
        /// Determines whether the blank space can move left.
        /// </summary>
        /// <returns>Whether the blank space can move left.</returns>
        public bool CanMoveBlankSpaceLeft()
        {
            Tuple<uint, uint> location = GetLocation(0);
            return (location.Item1 > 0);
        }

        /// <summary>
        /// Determines whether the blank space can move right.
        /// </summary>
        /// <returns>Whether the blank space can move right.</returns>
        public bool CanMoveBlankSpaceRight()
        {
            Tuple<uint, uint> location = GetLocation(0);
            return (location.Item1 < Length - 1);
        }

        /// <summary>
        /// If possible, moves the blank space up and returns whether the state was updated.
        /// </summary>
        /// <returns>Whether the state was updated.</returns>
        public bool MoveBlankSpaceUp()
        {
            Tuple<uint, uint> location = GetLocation(0);

            if (null != location && location.Item2 < Length - 1)
            {
                uint value = this[location];
                this[location] = this[location.Item1, location.Item2 + 1];
                this[location.Item1, location.Item2 + 1] = value;
                return true;
            }

            return false;
        }

        /// <summary>
        /// If possible, moves the blank space down and returns whether the state was updated.
        /// </summary>
        /// <returns>Whether the state was updated.</returns>
        public bool MoveBlankSpaceDown()
        {
            Tuple<uint, uint> location = GetLocation(0);

            if (null != location && location.Item2 > 0)
            {
                uint value = this[location];
                this[location] = this[location.Item1, location.Item2 - 1];
                this[location.Item1, location.Item2 - 1] = value;
                return true;
            }

            return false;
        }

        /// <summary>
        /// If possible, moves the blank space left and returns whether the state was updated.
        /// </summary>
        /// <returns>Whether the state was updated.</returns>
        public bool MoveBlankSpaceLeft()
        {
            Tuple<uint, uint> location = GetLocation(0);

            if (null != location && location.Item1 > 0)
            {
                uint value = this[location];
                this[location] = this[location.Item1 - 1, location.Item2];
                this[location.Item1 - 1, location.Item2] = value;
                return true;
            }

            return false;
        }

        /// <summary>
        /// If possible, moves the blank space right and returns whether the state was updated.
        /// </summary>
        /// <returns>Whether the state was updated.</returns>
        public bool MoveBlankSpaceRight()
        {
            Tuple<uint, uint> location = GetLocation(0);

            if (null != location && location.Item1 < Length - 1)
            {
                uint value = this[location];
                this[location] = this[location.Item1 + 1, location.Item2];
                this[location.Item1 + 1, location.Item2] = value;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns a pair of coordinates whose value equals the given value.
        /// </summary>
        /// <param name="value">A value.</param>
        /// <returns>A pair of coordinates whose value equals the given value./returns>
        private Tuple<uint, uint> GetLocation(uint value)
        {
            for (uint x = 0; x < Length; x++)
            {
                for (uint y = 0; y < Length; y++)
                {
                    if (this[x, y] == value)
                    {
                        return new Tuple<uint, uint>(x, y);
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
            return _locations.GetHashCode();
        }
    }
}
