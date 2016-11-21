using System.Collections.Generic;
using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Guard;
using Artificial_Intelligence.Chapter_3.Search.Informed.Function;
using Artificial_Intelligence.Chapter_3.Search.QSearch;
using Artificial_Intelligence.List;

namespace Artificial_Intelligence.Chapter_3.Search.Informed
{
    /// <summary>
    /// An abstract informed queue search with an update priority queue using an evaluation function.
    /// </summary>
    /// <typeparam name="TProblem">Any problem of TState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public abstract class BestFirstSearch<TProblem, TState, TAction> : ISearch<TProblem, TState, TAction>
          where TProblem : IProblem<TState, TAction>
          where TState : IState
          where TAction : IAction
    {
        /// <summary>
        /// An update priority queue search that stores explored nodes.
        /// </summary>
        private readonly UpdatePrioritySearch<TProblem, TState, TAction> _updatePrioritySearch;

        /// <summary>
        /// A queue of all leaf nodes available for expansion at any given point.
        /// </summary>
        private readonly IUpdatePriorityQueue<INode<TState, TAction>> _frontier;

        /// <summary>
        /// Defines a method that a type implements to compare two nodes.
        /// </summary>
        private class EvaluationFunctionComparer : IComparer<INode<TState, TAction>>
        {
            /// <summary>
            /// A functional interface for Evaluate.
            /// </summary>
            private readonly IEvaluationFunction<TState, TAction> _evaluationFunction;

            /// <summary>
            /// Specifies a functional interface for Evaluate.
            /// </summary>
            /// <param name="evaluationFunction">A functional interface for Evaluate.</param>
            public EvaluationFunctionComparer(IEvaluationFunction<TState, TAction> evaluationFunction)
            {
                _evaluationFunction = evaluationFunction.NonNull();
            }

            /// <summary>
            /// Compares two objects and returns a value indicating whether one is less than,
            /// equal to, or greater than the other.
            /// </summary>
            /// <param name="x">The first object to compare.</param>
            /// <param name="y">The second object to compare.</param>
            /// <returns>A signed integer that indicates the relative values of x and y, as shown in the 
            /// following table. Value Meaning Less than zero: x is less than y. Zero: x equals y. Greater
            /// than zero: x is greater than y.</returns>
            public int Compare(INode<TState, TAction> x, INode<TState, TAction> y)
            {
                double xCost = _evaluationFunction.Evaluate(x);
                double yCost = _evaluationFunction.Evaluate(y);
                return xCost.CompareTo(yCost);
            }
        }

        /// <summary>
        /// Specifies an update queue search and an evaluation function.
        /// </summary>
        /// <param name="updatePrioritySearch">An update priority queue search that stores explored nodes.</param>
        /// <param name="evaluationFunction">A functional interface for Evaluate.</param>
        public BestFirstSearch(UpdatePrioritySearch<TProblem, TState, TAction> updatePrioritySearch,
            IEvaluationFunction<TState, TAction> evaluationFunction)
        {
            _updatePrioritySearch = updatePrioritySearch;
            _frontier = new UpdatePriorityQueue<INode<TState, TAction>>(new EvaluationFunctionComparer(evaluationFunction.NonNull()));
        }

        /// <summary>
        /// Returns a sequence of actions that reaches the goal.
        /// </summary>
        /// <param name="problem">A problem.</param>
        /// <returns>A sequence of actions that reaches the goal.</returns>
        public IList<TAction> Search(TProblem problem)
        {
            return _updatePrioritySearch.Search(problem, _frontier);
        }
    }
}
