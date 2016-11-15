namespace Artificial_Intelligence.Environment.Queens.EightQueens
{
    /// <summary>
    /// A queens goal test function that returns whether
    /// there are a particular number of queens on the board and none are attacked.
    /// </summary>
    public class EightQueensGoalTestFunction : QueensGoalTestFunction<EightQueensState>
    {
        /// <summary>
        /// The number of queens on the board.
        /// </summary>
        private static readonly uint _queens = 8;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public EightQueensGoalTestFunction() : base(_queens)
        {

        }
    }
}
