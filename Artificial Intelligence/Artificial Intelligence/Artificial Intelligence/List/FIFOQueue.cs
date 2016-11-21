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
        private readonly Queue<T> _queue = new Queue<T>();

        /// <summary>
        /// Determines whether the current queue contains any items.
        /// </summary>
        /// <returns>Whether the current queue contains any items.</returns>
        public bool IsEmpty()
        {
            return _queue.Count == 0;
        }

        /// <summary>
        /// Returns an item from the queue.
        /// </summary>
        /// <returns>An item from the queue.</returns>
        public T Peek()
        {
            return _queue.Peek();
        }

        /// <summary>
        /// Removes and returns an item from the queue.
        /// </summary>
        /// <returns>An item from the queue.</returns>
        public T Pop()
        {
            return _queue.Dequeue();
        }

        /// <summary>
        /// Returns whether the given item was pushed onto the queue.
        /// </summary>
        /// <param name="item">Pushed item.</param>
        /// <returns>Whether the given item was pushed onto the queue.</returns>
        public bool Push(T item)
        {
            _queue.Enqueue(item);
            return true;
        }
    }
}
