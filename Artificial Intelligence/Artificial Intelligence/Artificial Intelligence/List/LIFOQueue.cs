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
        private readonly Stack<T> _stack = new Stack<T>();

        /// <summary>
        /// Determines whether the current queue contains any items.
        /// </summary>
        /// <returns>Whether the current queue contains any items.</returns>
        public bool IsEmpty()
        {
            return _stack.Count == 0;
        }

        /// <summary>
        /// Returns an item from the queue.
        /// </summary>
        /// <returns>An item from the queue.</returns>
        public T Peek()
        {
            return _stack.Peek();
        }

        /// <summary>
        /// Removes and returns an item from the queue.
        /// </summary>
        /// <returns>An item from the queue.</returns>
        public T Pop()
        {
            return _stack.Pop();
        }

        /// <summary>
        /// Returns whether the given item was pushed onto the queue.
        /// </summary>
        /// <param name="item">Pushed item.</param>
        /// <returns>Whether the given item was pushed onto the queue.</returns>
        public bool Push(T item)
        {
            _stack.Push(item);
            return true;
        }
    }
}
