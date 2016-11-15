namespace Artificial_Intelligence.Environment.Queens.OneHundredQueens
{
    /// <summary>
    /// A queens goal test function that returns whether
    /// there are a particular number of queens on the board and none are attacked.
    /// </summary>
    public class OneHundredQueensGoalTestFunction : QueensGoalTestFunction<OneHundredQueensState>
    {
        /// <summary>
        /// The number of queens on the board.
        /// </summary>
        private static readonly uint _queens = 100;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public OneHundredQueensGoalTestFunction() : base(_queens)
        {

        }
    }
}
