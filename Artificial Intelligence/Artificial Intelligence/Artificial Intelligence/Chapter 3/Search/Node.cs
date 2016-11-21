using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Guard;
using Artificial_Intelligence.List;
using System.Collections.Generic;
using System.Linq;

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
        public Node(TState state) : this(state, default(INode<TState, TAction>), default(TAction), 0)
        {

        }

        /// <summary>
        /// Specifies state, parent, action, and path cost.
        /// </summary>
        /// <param name="state">The state in the state space to which the node corresponds.</param>
        /// <param name="parent">The node in the search tree that generated this node.</param>
        /// <param name="action">The action that was applied to the parent to generate the node.</param>
        /// <param name="pathCost">The cost of the path from the initial state to the node.</param>
        public Node(TState state, INode<TState, TAction> parent, TAction action, double pathCost)
        {
            State = state.NonNull();
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

        /// <summary>
        /// Determines whether the given object is equal to the current object.
        /// </summary>
        /// <param name="obj">Any object.</param>
        /// <returns>Whether the given object is equal to the current object.</returns>
        public override bool Equals(object obj)
        {
            Node<TState, TAction> node = obj as Node<TState, TAction>;

            return null != node && State.Equals(node.State);
        }

        /// <summary>
        /// Uses hash function of the state in the state space to which the node corresponds.
        /// </summary>
        /// <returns>A hash code for the state in the state space to which the node corresponds.</returns>
        public override int GetHashCode()
        {
            int hashCode = 0;

            hashCode = (827361 * hashCode) + State.GetHashCode();

            return hashCode;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return
                "State : " + State.ToString() +
                "Parent : " + Parent?.ToString() +
                "Action : " + Action?.ToString() +
                "PathCost : " + PathCost.ToString();
        }
    }

    /// <summary>
    /// An extension of genereic Node.
    /// </summary>
    public static class Node
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
            child.NonNull();
            IList<TAction> path = new List<TAction>();

            for (INode<TState, TAction> current = child; child.Parent != null; child = child.Parent)
            {
                path = child.Action.Cons(path);
            }

            return path;
        }
    }
}
