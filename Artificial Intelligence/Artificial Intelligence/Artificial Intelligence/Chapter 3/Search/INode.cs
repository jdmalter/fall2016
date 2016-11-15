using Artificial_Intelligence.Chapter_2.Agent;

namespace Artificial_Intelligence.Chapter_3.Search
{
    /// <summary>
    /// A structure of four components: state, parent, action, and path cost.
    /// </summary>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public interface INode<TState, TAction>
        where TState : IState
        where TAction : IAction
    {
        /// <summary>
        /// The state in the state space to which the node corresponds.
        /// </summary>
        TState State { get; }

        /// <summary>
        /// The node in the search tree that generated this node.
        /// </summary>
        INode<TState, TAction> Parent { get; }

        /// <summary>
        /// The action that was applied to the parent to generate the node.
        /// </summary>
        TAction Action { get; }

        /// <summary>
        /// The cost of the path from the initial state to the node.
        /// </summary>
        double PathCost { get; }
    }
}
