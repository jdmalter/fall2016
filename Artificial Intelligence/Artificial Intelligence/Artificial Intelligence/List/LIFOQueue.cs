using System;
using System.Collections.Generic;

namespace Artificial_Intelligence.List
{
    /// <summary>
    /// A last in first out queue.
    /// </summary>
    /// <typeparam name="T">Any type.</typeparam>
    public class LIFOQueue<T> : ILIFOQueue<T>
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
                return _list[_list.Count - 1];
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
                T first = _list[_list.Count - 1];
                _list.RemoveAt(_list.Count - 1);
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

        /// <summary>
        /// Unfortunately, this method needs to exist otherwise priority search would not work.
        /// Removes and returns whether the given item was removed from the queue.
        /// </summary>
        /// <param name="item">Removed item.</param>
        /// <returns>Whether the given item was removed from the queue.</returns>
        public bool Remove(T item)
        {
            return _list.Remove(item);
        }
    }
}
