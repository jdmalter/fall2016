﻿using System.Collections.Generic;
using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Chapter_3.Search.QSearch;
using Artificial_Intelligence.Collections;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Chapter_3.Search.Uninformed
{
    /// <summary>
    /// An uninformed priority queue search using path cost.
    /// </summary>
    /// <typeparam name="TProblem">Any problem of TState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public class UniformCostSearch<TProblem, TState, TAction> : ISearch<TProblem, TState, TAction>
          where TProblem : IProblem<TState, TAction>
          where TState : IState
          where TAction : IAction
    {
        /// <summary>
        /// A priority queue search that stores explored nodes.
        /// </summary>
        private readonly PriorityQueueSearch<IPriorityQueue<INode<TState, TAction>>, TProblem, TState, TAction> _priorityQueueSearch;

        /// <summary>
        /// Specifies a priority queue search.
        /// </summary>
        /// <param name="priorityQueueSearch">A priority queue search that stores explored nodes.</param>
        public UniformCostSearch(PriorityQueueSearch<IPriorityQueue<INode<TState, TAction>>, TProblem, TState, TAction> priorityQueueSearch)
        {
            _priorityQueueSearch = priorityQueueSearch.NonNull();
        }

        /// <summary>
        /// Returns a sequence of actions that reaches the goal.
        /// </summary>
        /// <param name="problem">A problem.</param>
        /// <returns>A sequence of actions that reaches the goal.</returns>
        public IList<TAction> Search(TProblem problem)
        {
            IComparer<INode<TState, TAction>> comparer = new PathCostComparer();
            IPriorityQueue<INode<TState, TAction>> frontier = new PriorityQueue<INode<TState, TAction>>(comparer);
            return _priorityQueueSearch.Search(problem, frontier);
        }

        /// <summary>
        /// Defines a method that compares two nodes using an evaluation function.
        /// </summary>
        private class PathCostComparer : IComparer<INode<TState, TAction>>
        {
            /// <summary>
            /// Compares two nodes and returns an int indicating whether x is less than, equal to, or greater than y.
            /// </summary>
            /// <param name="x">The first node.</param>
            /// <param name="y">The second node.</param>
            /// <returns>An int indicating whether x is less than, equal to, or greater than y.</returns>
            public int Compare(INode<TState, TAction> x, INode<TState, TAction> y)
            {
                return x.PathCost.CompareTo(y.PathCost);
            }
        }
    }
}
