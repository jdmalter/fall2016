using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.List;
using System.Collections.Generic;

namespace Artificial_Intelligence.Chapter_3.Search.QSearch
{
    /// <summary>
    /// A abstract search using a queue of all leaf nodes available for expansion at any given point.
    /// </summary>
    /// <typeparam name="TProblem">Any problem of TState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public abstract class QueueSearch<TProblem, TState, TAction>
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
        public virtual IList<TAction> Search(TProblem problem, IQueue<INode<TState, TAction>> frontier)
        {
            frontier.Clear().Push(problem.InitialState.RootNode<TState, TAction>());

            while (!frontier.IsEmpty())
            {
                INode<TState, TAction> node = Remove(frontier);

                if (problem.GoalTestFunction.GoalTest(node.State))
                {
                    return node.Solution();
                }

                foreach (INode<TState, TAction> child in node.Expand(problem))
                {
                    Add(frontier, node);
                }
            }

            return new List<TAction>();
        }

        /// <summary>
        /// Adds a new leaf node available for expansion to the frontier.
        /// </summary>
        /// <param name="frontier">A queue of all leaf nodes available for expansion at any given point.</param>
        /// <param name="node">A new leaf node available for expansion.</param>
        public abstract void Add(IQueue<INode<TState, TAction>> frontier, INode<TState, TAction> node);

        /// <summary>
        /// Removes and returns a node for expansion.
        /// </summary>
        /// <param name="frontier">A queue of all leaf nodes available for expansion at any given point.</param>
        /// <returns>A node for expansion.</returns>
        public abstract INode<TState, TAction> Remove(IQueue<INode<TState, TAction>> frontier);
    }
}
