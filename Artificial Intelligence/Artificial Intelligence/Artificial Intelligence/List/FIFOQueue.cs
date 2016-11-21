using System;
using System.Collections.Generic;

namespace Artificial_Intelligence.List
{
    /// <summary>
    /// A first in first out queue.
    /// </summary>
    /// <typeparam name="T">Any type.</typeparam>
    public class FIFOQueue<T> : IFIFOQueue<T>
    {
        /// <summary>
        /// Backing data structure.
        /// </summary>
        private readonly IList<T> _list = new List<T>();

        /// <summary>
        /// Determines whether the current queue contains any items.
        /// </summary>
        /// <returns>Whether the current queue contains any items.</returns>
        public bool IsEmpty()
        {
            return _list.IsEmpty();
        }

        /// <summary>
        /// Returns an item from the queue.
        /// </summary>
        /// <returns>An item from the queue.</returns>
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("queue is empty");
            }
            else
            {
                return _list[0];
            }
        }

        /// <summary>
        /// Removes and returns an item from the queue.
        /// </summary>
        /// <returns>An item from the queue.</returns>
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("queue is empty");
            }
            else
            {
                T first = _list[0];
                _list.RemoveAt(0);
                return first;
            }
        }

        /// <summary>
        /// Returns whether the given item was pushed onto the queue.
        /// </summary>
        /// <param name="item">Pushed item.</param>
        /// <returns>Whether the given item was pushed onto the queue.</returns>
        public bool Push(T item)
        {
            _list.Insert(_list.Count, item);
            return true;
        }
    }
}
