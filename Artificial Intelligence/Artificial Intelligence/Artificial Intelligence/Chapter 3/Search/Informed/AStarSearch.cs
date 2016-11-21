using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Chapter_3.Search.Informed.Function;
using Artificial_Intelligence.Chapter_3.Search.QSearch;

namespace Artificial_Intelligence.Chapter_3.Search.Informed
{
    /// <summary>
    /// An abstract informed queue search with an update priority queue using an A* evaluation function.
    /// </summary>
    /// <typeparam name="TProblem">Any problem of TState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public class AStarSearch<TProblem, TState, TAction> : BestFirstSearch<TProblem, TState, TAction>
           where TProblem : IProblem<TState, TAction>
           where TState : IState
           where TAction : IAction
    {
        /// <summary>
        /// Specifies an update priority queue search and a heuristic.
        /// </summary>
        /// <param name="updatePrioritySearch">An update priority queue search that stores explored nodes.</param>
        /// <param name="heuristicFunction">A functional interface for Heuristic.</param>
        public AStarSearch(UpdatePrioritySearch<TProblem, TState, TAction> updatePrioritySearch,
            IHeuristicFunction<TState> heuristicFunction)
            : base(updatePrioritySearch,
                  new AStarEvaluationFunction<TState, TAction>(heuristicFunction))
        {

        }
    }
}
