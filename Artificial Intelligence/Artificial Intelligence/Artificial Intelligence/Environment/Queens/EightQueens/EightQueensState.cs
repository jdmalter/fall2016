namespace Artificial_Intelligence.Environment.Queens.EightQueens
{
    /// <summary>
    /// An agent's memory of its environment.
    /// </summary>
    public class EightQueensState : QueensState
    {
        /// <summary>
        /// The number of elements in any dimension.
        /// </summary>
        private static readonly uint _length = 8;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public EightQueensState() : base(_length)
        {

        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="copy">An EightQueensState being copied.</param>
        public EightQueensState(EightQueensState copy) : base(copy)
        {

        }
    }
}
