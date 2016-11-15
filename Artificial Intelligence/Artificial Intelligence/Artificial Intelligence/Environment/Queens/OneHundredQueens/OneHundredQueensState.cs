namespace Artificial_Intelligence.Environment.Queens.OneHundredQueens
{
    /// <summary>
    /// An agent's memory of its environment.
    /// </summary>
    public class OneHundredQueensState : QueensState
    {
        /// <summary>
        /// The number of elements in any dimension.
        /// </summary>
        private static readonly uint _length = 100;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public OneHundredQueensState() : base(_length)
        {

        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="copy">An OneHundredQueensState being copied.</param>
        public OneHundredQueensState(OneHundredQueensState copy) : base(copy)
        {

        }
    }
}
