using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Chapter_3.Search.QSearch;
using Artificial_Intelligence.List;
using System.Collections.Generic;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Chapter_3.Search.Uninformed
{
    /// <summary>
    /// An uninformed priority queue search.
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
        private class PathCostComparer : IComparer<INode<TState, TAction>>
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
        /// Specifies an update priority queue search.
        /// </summary>
        /// <param name="_updatePrioritySearch">An update priority queue search that stores explored nodes.</param>
        public UniformCostSearch(UpdatePrioritySearch<TProblem, TState, TAction> updatePrioritySearch)
        {
            _updatePrioritySearch = updatePrioritySearch.NonNull();
            _frontier = new UpdatePriorityQueue<INode<TState, TAction>>(new PathCostComparer());
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
