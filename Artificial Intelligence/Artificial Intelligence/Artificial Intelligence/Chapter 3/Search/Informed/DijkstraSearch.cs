using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Chapter_3.Search.Informed.Function;
using Artificial_Intelligence.Chapter_3.Search.QSearch;

namespace Artificial_Intelligence.Chapter_3.Search.Informed
{
    /// <summary>
    /// An abstract informed queue search with an update priority queue using a dijkstra evaluation function.
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
        /// Specifies an update priority queue search.
        /// </summary>
        /// <param name="updatePrioritySearch">An update priority queue search that stores explored nodes.</param>
        public DijkstraSearch(UpdatePrioritySearch<TProblem, TState, TAction> updatePrioritySearch)
            : base(updatePrioritySearch, new DijkstraEvaluationFunction<TState, TAction>())
        {

        }
    }
}
