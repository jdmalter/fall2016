using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.List;
using System.Collections.Generic;

namespace Artificial_Intelligence.Chapter_3.Search.Uninformed.DepthLimitedSearch
{
    /// <summary>
    /// An uninformed depth limited last in first out queue search.
    /// </summary>
    /// <typeparam name="TProblem">Any problem of TState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public abstract class DepthLimitedSearch<TProblem, TState, TAction> : ISearch<TProblem, TState, TAction>
            where TProblem : IProblem<TState, TAction>
            where TState : IState
            where TAction : IAction
    {
        /// <summary>
        /// Specifies a depth at which node have no successors.
        /// </summary>
        /// <param name="limit">A depth at which node have no successors.</param>
        public DepthLimitedSearch(int limit)
        {
            Limit = limit;
        }

        /// <summary>
        /// A depth at which node have no successors.
        /// </summary>
        public int Limit { get; }

        /// <summary>
        /// Returns a new instance of depth limited search whose deep limit is increased by one.
        /// </summary>
        /// <returns>A new instance of depth limited search whose deep limit is increased by one.</returns>
        public abstract DepthLimitedSearch<TProblem, TState, TAction> Deepen();

        /// <summary>
        /// Returns a sequence of actions that reaches the goal.
        /// </summary>
        /// <param name="problem">A problem.</param>
        /// <returns>A sequence of actions that reaches the goal or an empty sequence.</returns>
        public virtual IList<TAction> Search(TProblem problem)
        {
            INode<TState, TAction> root = problem.InitialState.RootNode<TState, TAction>();
            return RecursiveDLS(root, problem, Limit);
        }

        /// <summary>
        /// Returns a sequence of actions that reaches the goal.
        /// </summary>
        /// <param name="node">A node.</param>
        /// <param name="problem">A problem.</param>
        /// <param name="limit">A depth at which node have no successors.</param>
        /// <returns>A sequence of actions that reaches the goal  or an empty sequence.</returns>
        public virtual IList<TAction> RecursiveDLS(INode<TState, TAction> node, TProblem problem, int limit)
        {
            if (problem.GoalTestFunction.GoalTest(node.State))
            {
                return node.Solution();
            }
            else if (limit == 0)
            {
                return new List<TAction>();
            }
            else
            {
                foreach (INode<TState, TAction> child in node.Expand(problem))
                {
                    IList<TAction> result = RecursiveDLS(child, problem, limit - 1);
                    if (!result.IsEmpty())
                    {
                        return result;
                    }
                }
                return new List<TAction>();
            }
        }
    }
}
