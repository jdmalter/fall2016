using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Environment.Queens
{
    /// <summary>
    /// A queens result function that returns ADD.
    /// </summary>
    public class QueensResultFunction : IResultFunction<IQueensState, QueensAction>
    {
        /// <summary>
        /// Returns the state that results from doing the given action in the given state.
        /// </summary>
        /// <param name="state">A particular state.</param>
        /// <param name="action">An action being executed in a particular state.</param>
        /// <returns>The state that results from doing the given action in the given state.</returns>
        public IQueensState Result(IQueensState state, QueensAction action)
        {
            state.NonNull();
            action.NonNull();

            if (QueensAction.Add(action.X, action.Y).Equals(action))
            {
                return state.AddQueen(action.X, action.Y);
            }
            else
            {
                return state;
            }
        }
    }
}
