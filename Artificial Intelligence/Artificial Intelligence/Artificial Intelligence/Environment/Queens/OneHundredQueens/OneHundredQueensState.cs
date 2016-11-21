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
        public static readonly uint DefaultLength = 100;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public OneHundredQueensState() : base(DefaultLength)
        {

        }

        /// <summary>
        /// Specifies a square two dimensional array of bool.
        /// </summary>
        /// <param name="locations">A square two dimensional array of bool.</param>
        public OneHundredQueensState(bool[,] locations) : base(DefaultLength, locations)
        {

        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="copy">An OneHundredQueensState being copied.</param>
        public OneHundredQueensState(OneHundredQueensState copy) : base(copy)
        {

        }

        /// <summary>
        ///  Any implementation could add restrictions on top of this method.
        /// Specifies the number of elements in any dimension and a square two dimensional array of bool.
        /// Returns a new instance of state.
        /// </summary>
        /// <param name="length">The number of elements in any dimension.</param>
        /// <param name="locations">A square two dimensional array of bool.</param>
        /// <returns>A new instance of state.</returns>
        public override IQueensState Create(uint length, bool[,] locations)
        {
            return new OneHundredQueensState(locations);
        }
    }
}
