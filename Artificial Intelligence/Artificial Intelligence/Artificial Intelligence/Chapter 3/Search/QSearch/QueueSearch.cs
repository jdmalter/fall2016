using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Collections;
using System.Collections.Generic;

namespace Artificial_Intelligence.Chapter_3.Search.QSearch
{
    /// <summary>
    /// A abstract search using a queue of all leaf nodes available for expansion at any given point.
    /// </summary>
    /// <typeparam name="TQueue">Any queue of TNode.</typeparam>
    /// <typeparam name="TNode">Any INode of TState and TAction.</typeparam>
    /// <typeparam name="TProblem">Any problem of TState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public abstract class QueueSearch<TQueue, TNode, TProblem, TState, TAction>
        where TQueue : IQueue<TNode>
        where TNode : INode<TState, TAction>
        where TProblem : IProblem<TState, TAction>
        where TState : IState
        where TAction : IAction
    {
        /// <summary>
        /// Returns a sequence of actions that reaches the goal.
        /// </summary>
        /// <param name="problem">A problem.</param>
        /// <param name="frontier">A queue of all leaf nodes available for expansion at any given point.</param>
        /// <returns>A sequence of actions that reaches the goal.</returns>
        public virtual IList<TAction> Search(TProblem problem, TQueue frontier)
        {
            TNode root = Root(problem.InitialState);
            frontier.Clear().Push(root);

            while (!IsEmpty(frontier))
            {
                TNode node = Remove(frontier);

                if (problem.GoalTestFunction.GoalTest(node.State))
                {
                    return node.Solution();
                }

                foreach (TNode child in node.Expand(problem))
                {
                    Add(frontier, child);
                }
            }

            return new List<TAction>();
        }

        /// <summary>
        /// Adds a new leaf node available for expansion to the frontier.
        /// </summary>
        /// <param name="frontier">A queue of all leaf nodes available for expansion at any given point.</param>
        /// <param name="node">A new leaf node available for expansion.</param>
        public abstract void Add(TQueue frontier, TNode node);

        /// <summary>
        /// Determines whether the frontier contains any nodes available for expansion.
        /// </summary>
        /// <param name="frontier">A queue of all leaf nodes available for expansion at any given point.</param>
        /// <returns>Whether the frontier contains any nodes available for expansion.</returns>
        public abstract bool IsEmpty(TQueue frontier);

        /// <summary>
        /// Removes and returns a node for expansion.
        /// </summary>
        /// <param name="frontier">A queue of all leaf nodes available for expansion at any given point.</param>
        /// <returns>A node for expansion.</returns>
        public abstract TNode Remove(TQueue frontier);

        /// <summary>
        /// Returns a new root noot available for expansion.
        /// </summary>
        /// <param name="state">The initial state in which the seach starts.</param>
        /// <returns>A new root node available for expansion.</returns>
        public abstract TNode Root(TState state);
    }
}
