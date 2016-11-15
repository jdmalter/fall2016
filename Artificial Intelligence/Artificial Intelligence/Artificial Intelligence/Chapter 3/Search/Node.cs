using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Chapter_3.Search
{
    /// <summary>
    /// An abstract structure of four components: state, parent, action, and path cost.
    /// </summary>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public class Node<TState, TAction> : INode<TState, TAction>
          where TState : IState
          where TAction : IAction
    {
        /// <summary>
        /// Specifies state.
        /// </summary>
        /// <param name="state">The state in the state space to which the node corresponds.</param>
        public Node(TState state)
        {
            State = state.NonNull();
            Parent = default(INode<TState, TAction>);
            Action = default(TAction);
            PathCost = 0;
        }

        /// <summary>
        /// Specifies state, parent, action, and path cost.
        /// </summary>
        /// <param name="state">The state in the state space to which the node corresponds.</param>
        /// <param name="parent">The node in the search tree that generated this node.</param>
        /// <param name="action">The action that was applied to the parent to generate the node.</param>
        /// <param name="pathCost">The cost of the path from the initial state to the node.</param>
        public Node(TState state, INode<TState, TAction> parent, TAction action, double pathCost) : this(state)
        {
            Parent = parent;
            Action = action;
            PathCost = pathCost;
        }

        /// <summary>
        /// The state in the state space to which the node corresponds.
        /// </summary>
        public TState State { get; }

        /// <summary>
        /// The node in the search tree that generated this node.
        /// </summary>
        public INode<TState, TAction> Parent { get; }

        /// <summary>
        /// The action that was applied to the parent to generate the node.
        /// </summary>
        public TAction Action { get; }

        /// <summary>
        /// The cost of the path from the initial state to the node.
        /// </summary>
        public double PathCost { get; }
    }
}
