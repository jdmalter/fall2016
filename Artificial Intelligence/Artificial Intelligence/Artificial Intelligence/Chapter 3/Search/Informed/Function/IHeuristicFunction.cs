using Artificial_Intelligence.Chapter_2.Agent;

namespace Artificial_Intelligence.Chapter_3.Search.Informed.Function
{
    /// <summary>
    /// A functional interface for Heuristic.
    /// </summary>
    /// <typeparam name="TState">Any state.</typeparam>
    public interface IHeuristicFunction<TState>
        where TState : IState
    {
        /// <summary>
        /// Returns the estimated cost of the cheapest path fromthe given state to the goal state.
        /// </summary>
        /// <param name="state">A state.</param>
        /// <returns>The estimated cost of the cheapest path from
        /// the given state to the goal state.</returns>
        double Heuristic(TState state);
    }
}
