using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Chapter_3.Search.Informed.Function;
using Artificial_Intelligence.Chapter_3.Search.QSearch;
using Artificial_Intelligence.List;

namespace Artificial_Intelligence.Chapter_3.Search.Informed
{
    /// <summary>
    /// An informed priority queue search using a greedy best first evaluation function.
    /// </summary>
    /// <typeparam name="TProblem">Any problem of TState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public class GreedyBestFirstSearch<TProblem, TState, TAction> : BestFirstSearch<TProblem, TState, TAction>
              where TProblem : IProblem<TState, TAction>
              where TState : IState
              where TAction : IAction
    {
        /// <summary>
        /// Specifies a queue search and a heuristic function.
        /// </summary>
        /// <param name="queueSearch">A search using a queue of all leaf nodes available for expansion at any given point.</param>
        /// <param name="heuristicFunction">A functional interface for Heuristic.</param>
        public GreedyBestFirstSearch(QueueSearch<IPriorityQueue<INode<TState, TAction>>, TProblem, TState, TAction> queueSearch,
              IHeuristicFunction<TState> heuristicFunction)
            : base(queueSearch, new GreedyBestFirstEvaluationFunction<TState, TAction>(heuristicFunction))
        {

        }
    }
}
