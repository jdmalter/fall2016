using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Chapter_3.Search.Informed.Function;
using Artificial_Intelligence.Chapter_3.Search.QSearch;
using Artificial_Intelligence.Collections;

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
        /// Specifies a priority queue search and a heuristic function.
        /// </summary>
        /// <param name="priorityQueueSearch">A priority queue search that stores explored nodes.</param>
        /// <param name="heuristicFunction">A functional interface for Heuristic.</param>
        public GreedyBestFirstSearch(PriorityQueueSearch<IPriorityQueue<INode<TState, TAction>>, TProblem, TState, TAction> priorityQueueSearch,
              IHeuristicFunction<TState> heuristicFunction)
            : base(priorityQueueSearch, new GreedyBestFirstEvaluationFunction<TState, TAction>(heuristicFunction))
        {

        }
    }
}
