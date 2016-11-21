using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Chapter_3.Search.Informed.Function
{
    /// <summary>
    /// An evaluation function which evaluates nodes by their path cost plus the Heuristic.
    /// </summary>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public class AStarEvaluationFunction<TState, TAction> : IEvaluationFunction<TState, TAction>
        where TState : IState
        where TAction : IAction
    {
        /// <summary>
        /// A functional interface for Heuristic.
        /// </summary>
        private readonly IHeuristicFunction<TState> _heuristicFunction;

        /// <summary>
        /// Specifies a functional interface for Heuristic.
        /// </summary>
        /// <param name="heuristicFunction">A functional interface for Heuristic.</param>
        public AStarEvaluationFunction(IHeuristicFunction<TState> heuristicFunction)
        {
            _heuristicFunction = heuristicFunction.NonNull();
        }

        /// <summary>
        /// Returns the estimated cost of the cheapest solution through the given node.
        /// </summary>
        /// <param name="node">A node.</param>
        /// <returns>The estimated cost of the cheapest solution through the given node.</returns>
        public double Evaluate(INode<TState, TAction> node)
        {
            return node.PathCost + _heuristicFunction.Heuristic(node.State);
        }
    }
}
