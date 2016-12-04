using Artificial_Intelligence.Chapter_2.Agent;

namespace Artificial_Intelligence.Chapter_3.Search
{
    /// <summary>
    /// A structure of five components: state, parent, action, path cost, and originality.
    /// </summary>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public interface IBidirectionalNode<TState, TAction> : INode<TState, TAction>
        where TState : IState
        where TAction : IAction
    {
        /// <summary>
        /// Whether this node is generated from the original problem.
        /// </summary>
        bool IsOriginal { get; }
    }
}
