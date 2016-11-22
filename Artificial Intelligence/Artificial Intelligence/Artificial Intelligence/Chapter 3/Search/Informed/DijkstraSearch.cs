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
        /// Specifies a queue search.
        /// </summary>
        /// <param name="queueSearch">A search using a queue of all leaf nodes available for expansion at any given point.</param>
        public DijkstraSearch(QueueSearch<IPriorityQueue<INode<TState, TAction>>, TProblem, TState, TAction> queueSearch)
            : base(queueSearch, new DijkstraEvaluationFunction<TState, TAction>())
        {

        }
    }
}
