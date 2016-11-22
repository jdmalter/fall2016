using Artificial_Intelligence.Guard;
using System;
using System.Collections.Generic;

namespace Artificial_Intelligence.List
{
    /// <summary>
    /// A priority queue which supports duplicate items.
    /// </summary>
    /// <typeparam name="T">Any type.</typeparam>
    public class PriorityQueue<T> : IPriorityQueue<T>
    {
        /// <summary>
        /// Backing data structure.
        /// </summary>
        private readonly IList<T> _list = new List<T>();

        /// <summary>
        /// Specifes a method that compares two objects.
        /// </summary>
        /// <param name="comparer">A method that compares two objects.</param>
        public PriorityQueue(IComparer<T> comparer)
        {
            Comparer = comparer.NonNull();
        }

        /// <summary>
        /// A method that compares two objects.
        /// </summary>
        public IComparer<T> Comparer { get; }

        /// <summary>
        /// Inserts the given item into list at the given index.
        /// </summary>
        /// <param name="index">An index at which the given item is inserted.</param>
        /// <param name="item">Inserted item.</param>
        private void Insert(int index, T item)
        {
            _list.Insert(index, item);
        }

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
                Swap(0, _list.Count - 1);

                // Bubble down
                for (int index = 0, left = 2 * index + 1, smaller = left;
                    2 * index + 1 < _list.Count;
                    index = smaller, left = 2 * index + 1, smaller = left)
                {
                    smaller += left + 1 < _list.Count && Comparer.Compare(_list[left], _list[left + 1]) > 0 ? 1 : 0;
                    Swap(index, smaller);
                }

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
            Insert(_list.Count, item);

            // Bubble up
            for (int index = _list.Count - 1, parent = (index - 1) / 2;
                index > 0 && Comparer.Compare(_list[index], _list[parent]) > 0;
                index = parent, parent = (index - 1) / 2)
            {
                Swap(index, parent);
            }

            return true;
        }

        /// <summary>
        /// Swaps the given items.
        /// </summary>
        /// <param name="a">An item to swap.</param>
        /// <param name="b">An item to swap.</param>
        private void Swap(int a, int b)
        {
            _list.Swap(a, b);
        }
    }
}
