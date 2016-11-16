using Artificial_Intelligence.Guard;
using System;
using System.Collections.Generic;

namespace Artificial_Intelligence.List
{
    /// <summary>
    /// A priority queue with is empty, pop, and push operations.
    /// </summary>
    /// <typeparam name="T">Any type.</typeparam>
    public class PriorityQueue<T> : IQueue<T>
    {
        /// <summary>
        /// Backing data structure.
        /// </summary>
        private readonly IList<T> _list = new List<T>();

        /// <summary>
        /// A method that compares two objects.
        /// </summary>
        private readonly IComparer<T> _comparer;

        /// <summary>
        /// Specifes a method that compares two objects.
        /// </summary>
        /// <param name="comparer">A method that compares two objects.</param>
        public PriorityQueue(IComparer<T> comparer)
        {
            _comparer = comparer.NonNull();
        }

        /// <summary>
        /// Determines whether the current queue contains any elements.
        /// </summary>
        /// <returns>Whether the current queue contains any elements.</returns>
        public bool IsEmpty()
        {
            return _list.IsEmpty();
        }

        /// <summary>
        /// Removes and returns an element from the queue.
        /// </summary>
        /// <param name="list">A list consisting of all elements.</param>
        /// <returns>An element from the queue.</returns>
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("queue is empty");
            }
            else
            {
                T first = _list[0];
                _list.Swap(0, _list.Count - 1);

                for (int index = 0, left = 2 * index + 1, smaller = left;
                    2 * index + 1 < _list.Count;
                    index = smaller, left = 2 * index + 1, smaller = left)
                {
                    smaller += left + 1 < _list.Count && _comparer.Compare(_list[left], _list[left + 1]) >= 0 ? 1 : 0;
                    _list.Swap(index, smaller);
                }

                _list.RemoveAt(_list.Count - 1);
                return first;
            }
        }

        /// <summary>
        /// Returns a queue containing the given item.
        /// </summary>
        /// <param name="item">New element.</param>
        /// <returns>A queue containing the given item.</returns>
        public IQueue<T> Push(T item)
        {
            _list.Insert(_list.Count, item);

            for (int index = _list.Count - 1, parent = (index - 1) / 2;
                index > 0 && _comparer.Compare(_list[index], _list[parent]) >= 0;
                index = parent, parent = (index - 1) / 2)
            {
                _list.Swap(index, parent);
            }

            return this;
        }
    }
}
