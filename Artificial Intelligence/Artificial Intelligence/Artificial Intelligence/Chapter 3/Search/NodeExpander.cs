using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.List;
using System.Collections.Generic;
using System.Linq;

namespace Artificial_Intelligence.Chapter_3.Search
{
    /// <summary>
    /// An extension of genereic INode.
    /// </summary>
    public static class NodeExpander
    {
        /// <summary>
        /// Creates and returns node with state.
        /// </summary>
        /// <typeparam name="TState">Any state.</typeparam>
        /// <typeparam name="TAction">Any action.</typeparam>
        /// <param name="state">The state in the state space to which the node corresponds.</param>
        /// <returns>Node with state.</returns>
        public static INode<TState, TAction> RootNode<TState, TAction>(this TState state)
            where TState : IState
            where TAction : IAction
        {
            return new Node<TState, TAction>(state);
        }

        /// <summary>
        /// Returns a node with the state that results from doing the given action in the parent's state,
        /// the parent, the action, and the parent's path cost plus the cost of taking the given action
        /// in the parent's state to reach the child state.
        /// </summary>
        /// <typeparam name="TState">Any state.</typeparam>
        /// <typeparam name="TAction">Any action.</typeparam>
        /// <param name="parent">The node in the search tree that generated this node.</param>
        /// <param name="problem">Components that provide the child state and the step cost.</param>
        /// <param name="action">The action that was applied to the parent to generate the node.</param>
        /// <returns>A node with the state that results from doing the given action in the parent's state,
        /// the parent, the action, and the parent's path cost plus the cost of taking the given action
        /// in the parent's state to reach the child state.</returns>
        public static INode<TState, TAction> ChildNode<TState, TAction>(
            this INode<TState, TAction> parent,
            IProblem<TState, TAction> problem,
            TAction action)
            where TState : IState
            where TAction : IAction
        {
            TState state = problem.ResultFunction.Result(parent.State, action);
            double stepCost = problem.StepCostFunction.StepCost(parent.State, action, state);
            return new Node<TState, TAction>(state, parent, action, parent.PathCost + stepCost);
        }

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
        public static IEnumerable<INode<TState, TAction>> Expand<TState, TAction>(
            this INode<TState, TAction> parent,
            IProblem<TState, TAction> problem)
            where TState : IState
            where TAction : IAction
        {
            return problem
                .ActionsFunction
                .Actions(parent.State)
                .Select(action => parent.ChildNode(problem, action));
        }

        /// <summary>
        /// Returns a list of nodes from the root node to the child node.
        /// </summary>
        /// <typeparam name="TState">Any state.</typeparam>
        /// <typeparam name="TAction">Any action.</typeparam>
        /// <param name="child">The node at the bottom of the search tree that generated this node.</param>
        /// <returns>A list of nodes from the root node to the child node.</returns>
        public static IList<INode<TState, TAction>> RootToChild<TState, TAction>(
            this INode<TState, TAction> child)
            where TState : IState
            where TAction : IAction
        {
            IList<INode<TState, TAction>> path = IList.Empty<INode<TState, TAction>>();
            for (INode<TState, TAction> current = child; child != null; child = child.Parent)
            {
                path = child.Cons(path);
            }
            return path;
        }

        /// <summary>
        /// Returns a list of actions taken from the root node which generate this node.
        /// </summary>
        /// <typeparam name="TState">Any state.</typeparam>
        /// <typeparam name="TAction">Any action.</typeparam>
        /// <param name="child">The node at the bottom of the search tree that generated this node.</param>
        /// <returns>A list of actions taken from the root node which generate this node.</returns>
        public static IList<TAction> Solution<TState, TAction>(this INode<TState, TAction> child)
            where TState : IState
            where TAction : IAction
        {
            return child.RootToChild().Select(node => node.Action).ToList();
        }
    }
}
