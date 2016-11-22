using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Chapter_3.Search.Informed.Function;
using Artificial_Intelligence.Chapter_3.Search.QSearch;
using Artificial_Intelligence.Collections;
using System.Collections.Generic;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Chapter_3.Search.Informed
{
    /// <summary>
    /// An abstract informed priority queue search using an evaluation function.
    /// </summary>
    /// <typeparam name="TProblem">Any problem of TState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public abstract class BestFirstSearch<TProblem, TState, TAction> : PrioritySearch<TProblem, TState, TAction>
        where TProblem : IProblem<TState, TAction>
        where TState : IState
        where TAction : IAction
    {
        /// <summary>
        /// Specifies a priority queue search and an evaluation function.
        /// </summary>
        /// <param name="priorityQueueSearch">A priority queue search that stores explored nodes.</param>
        /// <param name="evaluationFunction">A functional interface for Evaluate.</param>
        public BestFirstSearch(PriorityQueueSearch<IPriorityQueue<INode<TState, TAction>>, TProblem, TState, TAction> priorityQueueSearch,
           IEvaluationFunction<TState, TAction> evaluationFunction)
            : base(priorityQueueSearch, new EvaluationFunctionComparer(evaluationFunction))
        {

        }

        /// <summary>
        /// Defines a method that compares two nodes using an evaluation function.
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
            /// Compares two nodes and returns an int indicating whether x is less than, equal to, or greater than y.
            /// </summary>
            /// <param name="x">The first node.</param>
            /// <param name="y">The second node.</param>
            /// <returns>An int indicating whether x is less than, equal to, or greater than y.</returns>
            public int Compare(INode<TState, TAction> x, INode<TState, TAction> y)
            {
                double fx = _evaluationFunction.Evaluate(x);
                double fy = _evaluationFunction.Evaluate(y);
                return fx.CompareTo(fy);
            }
        }
    }
}
