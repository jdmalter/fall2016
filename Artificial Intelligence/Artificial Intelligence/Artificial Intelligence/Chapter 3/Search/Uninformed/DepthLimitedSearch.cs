using System.Collections.Generic;
using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.List;

namespace Artificial_Intelligence.Chapter_3.Search.Uninformed
{
    /// <summary>
    /// An uninformed depth limited last in first out queue search.
    /// </summary>
    /// <typeparam name="TProblem">Any problem of TState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public class DepthLimitedSearch<TProblem, TState, TAction> : ISearch<TProblem, TState, TAction>
            where TProblem : IProblem<TState, TAction>
            where TState : IState
            where TAction : IAction
    {
        /// <summary>
        /// A depth at which node have no successors.
        /// </summary>
        private readonly int _limit;

        /// <summary>
        /// Specifies a depth at which node have no successors.
        /// </summary>
        /// <param name="limit">A depth at which node have no successors.</param>
        public DepthLimitedSearch(int limit)
        {
            _limit = limit;
        }

        /// <summary>
        /// Returns a sequence of actions that reaches the goal.
        /// </summary>
        /// <param name="problem">A problem.</param>
        /// <returns>A sequence of actions that reaches the goal or an empty sequence.</returns>
        public IList<TAction> Search(TProblem problem)
        {
            return RecursiveDLS(problem.InitialState.RootNode<TState, TAction>(), problem, _limit);
        }

        /// <summary>
        /// Returns a sequence of actions that reaches the goal.
        /// </summary>
        /// <param name="node">A node.</param>
        /// <param name="problem">A problem.</param>
        /// <param name="limit">A depth at which node have no successors.</param>
        /// <returns>A sequence of actions that reaches the goal  or an empty sequence.</returns>
        public static IList<TAction> RecursiveDLS(INode<TState, TAction> node, TProblem problem, int limit)
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
