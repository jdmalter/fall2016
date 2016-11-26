using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Environment.Map
{
    /// <summary>
    /// A functional interface for Result.
    /// </summary>
    /// <typeparam name="TState">Any map state.</typeparam>
    /// <typeparam name="TAction">Any map action of TState.</typeparam>
    public class MapResultFunction<TState, TAction> : IResultFunction<TState, TAction>
        where TState : IMapState
        where TAction : MapAction<TState>
    {
        /// <summary>
        /// Returns the state that results from doing the given action in the given state.
        /// </summary>
        /// <param name="state">A particular state.</param>
        /// <param name="action">An action being executed in a particular state.</param>
        /// <returns>The state that results from doing the given action in the given state.</returns>
        public TState Result(TState state, TAction action)
        {
            return action.NonNull().State;
        }
    }
}
