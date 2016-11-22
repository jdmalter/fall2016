using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Chapter_3.Search.Informed.Function;
using Artificial_Intelligence.Chapter_3.Search.QSearch;
using Artificial_Intelligence.List;

namespace Artificial_Intelligence.Chapter_3.Search.Informed
{
    /// <summary>
    /// An informed priority queue search using a dijkstra evaluation function.
    /// </summary>
    /// <typeparam name="TProblem">Any problem of TState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public class DijkstraSearch<TProblem, TState, TAction> : BestFirstSearch<TProblem, TState, TAction>
           where TProblem : IProblem<TState, TAction>
           where TState : IState
           where TAction : IAction
    {
        /// <summary>
        /// Specifies a priority queue search.
        /// </summary>
        /// <param name="priorityQueueSearch">A priority queue search that stores explored nodes.</param>
        public DijkstraSearch(PriorityQueueSearch<IPriorityQueue<INode<TState, TAction>>, TProblem, TState, TAction> priorityQueueSearch)
            : base(priorityQueueSearch, new DijkstraEvaluationFunction<TState, TAction>())
        {

        }
    }
}
