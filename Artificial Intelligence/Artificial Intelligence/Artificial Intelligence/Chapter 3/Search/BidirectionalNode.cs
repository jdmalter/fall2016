using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using System.Collections.Generic;
using System.Linq;

namespace Artificial_Intelligence.Chapter_3.Search
{
    /// <summary>
    /// An abstract structure of five components: state, parent, action, path cost, and originality.
    /// </summary>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public class BidirectionalNode<TState, TAction> : Node<TState, TAction>, IBidirectionalNode<TState, TAction>
        where TState : IState
        where TAction : IAction
    {
        /// <summary>
        /// Specifies state and originality.
        /// </summary>
        /// <param name="state">The state in the state space to which the node corresponds.</param>
        /// <param name="isOriginal">Whether this node is generated from the original problem.</param>
        public BidirectionalNode(TState state, bool isOriginal)
            : base(state)
        {
            IsOriginal = isOriginal;
        }

        /// <summary>
        /// Specifies state, parent, action, path cost, and originality.
        /// </summary>
        /// <param name="state">The state in the state space to which the node corresponds.</param>
        /// <param name="parent">The node in the search tree that generated this node.</param>
        /// <param name="action">The action that was applied to the parent to generate the node.</param>
        /// <param name="pathCost">The cost of the path from the initial state to the node.</param>
        /// <param name="isOriginal">Whether this node is generated from the original problem.</param>
        public BidirectionalNode(TState state, INode<TState, TAction> parent, TAction action, double pathCost, bool isOriginal)
            : base(state, parent, action, pathCost)
        {
            IsOriginal = isOriginal;
        }

        /// <summary>
        /// Whether this node is generated from the original problem.
        /// </summary>
        public bool IsOriginal { get; }

        /// <summary>
        /// Determines whether the given object is equal to the current object.
        /// </summary>
        /// <param name="obj">Any object.</param>
        /// <returns>Whether the given object is equal to the current object.</returns>
        public override bool Equals(object obj)
        {
            BidirectionalNode<TState, TAction> node = obj as BidirectionalNode<TState, TAction>;

            return base.Equals(node) && IsOriginal == node.IsOriginal;
        }

        /// <summary>
        /// Uses hash function of the state in the state space to which the node corresponds.
        /// </summary>
        /// <returns>A hash code for the state in the state space to which the node corresponds.</returns>
        public override int GetHashCode()
        {
            int hashCode = base.GetHashCode();

            hashCode = (IsOriginal ? 951847 : 658286 * hashCode);

            return hashCode;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return "Bidirectional" + base.ToString();
        }
    }

    /// <summary>
    /// An extension of genereic Node.
    /// </summary>
    public static class BidirectionalNode
    {
        /// <summary>
        /// Returns a list of nodes by creating a child node for each action in the set of actions
        /// that can be executed in the parent's state.
        /// </summary>
        /// <typeparam name="TState">Any state.</typeparam>
        /// <typeparam name="TAction">Any action.</typeparam>
        /// <param name="parent">The node in the search tree that generated this node.</param>
        /// <param name="problem">Components that provide the children's states and the step costs.</param>
        /// <returns>A list of nodes by creating a child node for each action in the set of actions
        /// that can be executed in the parent's state.</returns>
        public static IEnumerable<IBidirectionalNode<TState, TAction>> Expand<TState, TAction>(
            this IBidirectionalNode<TState, TAction> parent,
            IProblem<TState, TAction> problem)
            where TState : IState
            where TAction : IAction
        {
            return problem
                .ActionsFunction
                .Actions(parent.State)
                .Select(action =>
                {
                    TState state = problem.ResultFunction.Result(parent.State, action);
                    double stepCost = problem.StepCostFunction.StepCost(parent.State, action, state);
                    return new BidirectionalNode<TState, TAction>(state, parent, action, parent.PathCost + stepCost, parent.IsOriginal);
                });
        }
    }
}
