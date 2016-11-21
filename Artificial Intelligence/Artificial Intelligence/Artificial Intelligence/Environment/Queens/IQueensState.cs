using Artificial_Intelligence.Chapter_2.Agent;

namespace Artificial_Intelligence.Environment.Queens
{
    /// <summary>
    /// 
    /// </summary>
    public interface IQueensState : IState
    {
        /// <summary>
        /// The number of elements in any dimension.
        /// </summary>
        uint Length { get; }

        /// <summary>
        /// Gets whether there is a queen at the given coordiantes.
        /// </summary>
        /// <param name="x">A x dimension coordinate.</param>
        /// <param name="y">A y dimension coordinate.</param>
        /// <returns>Whether there is a queen at the given coordiantes.</returns>
        bool this[uint x, uint y] { get; }

        /// <summary>
        /// If there is no queen at the given coordiantes, adds queen at the given coordinates and
        /// returns either the same instance of the unchanged state or a new instance of the updated state.
        /// </summary>
        /// <param name="x">A x dimension coordinate.</param>
        /// <param name="y">A y dimension coordinate.</param>
        /// <returns>Either the same instance of the unchanged state or
        /// a new instance of the updated state.</returns>
        IQueensState AddQueen(uint x, uint y);

        /// <summary>
        /// Sums the number of queens in the same row, column, or diagonal as the coordinates.
        /// </summary>
        /// <param name="x">A x dimension coordinate.</param>
        /// <param name="y">A y dimension coordinate.</param>
        /// <returns>The number of queens in the same row, column, or diagonal as the coordinates.</returns>
        uint AttacksOn(uint x, uint y);

        /// <summary>
        ///  Any implementation could add restrictions on top of this method.
        /// Specifies the number of elements in any dimension and a square two dimensional array of bool.
        /// Returns a new instance of state.
        /// </summary>
        /// <param name="length">The number of elements in any dimension.</param>
        /// <param name="locations">A square two dimensional array of bool.</param>
        /// <returns>A new instance of state.</returns>
        IQueensState Create(uint length, bool[,] locations);
    }
}
