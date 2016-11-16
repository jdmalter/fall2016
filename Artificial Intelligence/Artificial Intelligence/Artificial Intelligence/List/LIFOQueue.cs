using System;
using System.Collections.Generic;

namespace Artificial_Intelligence.List
{
    /// <summary>
    /// A last in first out queue with is empty, pop, and push operations.
    /// </summary>
    /// <typeparam name="T">Any type.</typeparam>
    public class LIFOQueue<T> : IQueue<T>
    {
        /// <summary>
        /// Backing data structure.
        /// </summary>
        private readonly IList<T> _list = new List<T>();

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
                T first = _list[_list.Count - 1];
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
            return this;
        }
    }
}
