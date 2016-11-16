using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Chapter_3.Search.QSearch;
using Artificial_Intelligence.List;
using System.Collections.Generic;

namespace Artificial_Intelligence.Chapter_3.Search.Uninformed
{
    /// <summary>
    /// An uninformed first in first out queue search.
    /// </summary>
    /// <typeparam name="TProblem">Any problem of TState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public class UniformCostSearch<TProblem, TState, TAction> : UninformedQueueSearch<TProblem, TState, TAction>
          where TProblem : IProblem<TState, TAction>
          where TState : IState
          where TAction : IAction
    {
        /// <summary>
        /// Defines a method that a type implements to compare two nodes.
        /// </summary>
        private class INodeComparer : IComparer<INode<TState, TAction>>
        {
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
                return x.PathCost.CompareTo(y.PathCost);
            }
        }

        /// <summary>
        /// Specifies a queue search.
        /// </summary>
        /// <param name="queueSearch">A search using a queue of all leaf nodes available for expansion at any given point.</param>
        public UniformCostSearch(QueueSearch<TProblem, TState, TAction> queueSearch)
            : base(queueSearch, new PriorityQueue<INode<TState, TAction>>(new INodeComparer()))
        {

        }
    }
}
