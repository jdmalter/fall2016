using Artificial_Intelligence.Chapter_2.Agent;

namespace Artificial_Intelligence.Chapter_3.Search.Informed.Function
{
    /// <summary>
    /// A functional interface for Evaluate.
    /// </summary>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public interface IEvaluationFunction<TState, TAction>
        where TState : IState
        where TAction : IAction
    {
        /// <summary>
        /// Returns the estimated cost of the cheapest solution through the given node.
        /// </summary>
        /// <param name="node">A node.</param>
        /// <returns>The estimated cost of the cheapest solution through the given node.</returns>
        double Evaluate(INode<TState, TAction> node);
    }
}
