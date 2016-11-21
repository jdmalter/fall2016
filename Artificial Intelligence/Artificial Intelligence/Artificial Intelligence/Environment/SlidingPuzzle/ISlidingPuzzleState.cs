using Artificial_Intelligence.Chapter_2.Agent;

namespace Artificial_Intelligence.Environment.SlidingPuzzle
{
    /// <summary>
    /// An agent's memory of its environment.
    /// </summary>
    public interface ISlidingPuzzleState : IState
    {
        /// <summary>
        /// The number of elements in any dimension.
        /// </summary>
        uint Length { get; }

        /// <summary>
        /// Gets a value at the given coordiantes.
        /// </summary>
        /// <param name="x">A x dimension coordinate.</param>
        /// <param name="y">A y dimension coordinate.</param>
        /// <returns>A value at the given coordiantes.</returns>
        uint this[uint x, uint y] { get; }

        /// <summary>
        /// Determines whether the blank space can move up.
        /// </summary>
        /// <returns>Whether the blank space can move up.</returns>
        bool CanMoveBlankSpaceUp();

        /// <summary>
        /// Determines whether the blank space can move down.
        /// </summary>
        /// <returns>Whether the blank space can move down.</returns>
        bool CanMoveBlankSpaceDown();

        /// <summary>
        /// Determines whether the blank space can move left.
        /// </summary>
        /// <returns>Whether the blank space can move left.</returns>
        bool CanMoveBlankSpaceLeft();

        /// <summary>
        /// Determines whether the blank space can move right.
        /// </summary>
        /// <returns>Whether the blank space can move right.</returns>
        bool CanMoveBlankSpaceRight();

        /// <summary>
        /// Any implementation could add restrictions on top of this method.
        /// Specifies the number of elements in any dimension and a square two dimensional array of values.
        /// Returns a new instance of state.
        /// </summary>
        /// <param name="length">The number of elements in any dimension.</param>
        /// <param name="locations">A square two dimensional array of values.</param>
        /// <returns>A new instance of state.</returns>
        ISlidingPuzzleState Create(uint length, uint[,] locations);

        /// <summary>
        /// If possible, moves the blank space up and
        /// returns the same instance of the unchanged state or a new instance of the updated state.
        /// </summary>
        /// <returns>The same instance of the unchanged state or
        /// a new instance of the updated state.</returns>
        ISlidingPuzzleState MoveBlankSpaceUp();

        /// <summary>
        /// If possible, moves the blank space down and
        /// returns the same instance of the unchanged state or a new instance of the updated state.
        /// </summary>
        /// <returns>The same instance of the unchanged state
        /// or a new instance of the updated state.</returns>
        ISlidingPuzzleState MoveBlankSpaceDown();

        /// <summary>
        /// If possible, moves the blank space left and
        /// returns the same instance of the unchanged state or a new instance of the updated state.
        /// </summary>
        /// <returns>The same instance of the unchanged state
        /// or a new instance of the updated state.</returns>
        ISlidingPuzzleState MoveBlankSpaceLeft();

        /// <summary>
        /// If possible, moves the blank space right and
        /// returns the same instance of the unchanged state or a new instance of the updated state.
        /// </summary>
        /// <returns>The same instance of the unchanged state
        /// or a new instance of the updated state.</returns>
        ISlidingPuzzleState MoveBlankSpaceRight();
    }
}
