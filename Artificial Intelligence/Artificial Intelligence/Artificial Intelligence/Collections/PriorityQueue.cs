using Artificial_Intelligence.Guard;
using System;
using System.Collections.Generic;

namespace Artificial_Intelligence.Collections
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
                _list.Swap(0, _list.Count - 1);

                // Bubble down except for _list.Count - 1 because we don't want the last element being swapped
                for (int index = 0, left = 2 * index + 1, smaller = left;
                    left < _list.Count - 1;
                    index = smaller, left = 2 * index + 1, smaller = left)
                {
                    smaller += left + 1 < _list.Count - 1 && Comparer.Compare(_list[left], _list[left + 1]) > 0 ? 1 : 0;
                    if (Comparer.Compare(_list[index], _list[smaller]) > 0) // I FOUND THE SECOND BUG!!!
                    {
                        _list.Swap(index, smaller);
                    }
                    else
                    {
                        break;
                    }
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
            _list.Insert(_list.Count, item);

            // Bubble up
            for (int index = _list.Count - 1, parent = (index - 1) / 2;
                index > 0 && Comparer.Compare(_list[index], _list[parent]) < 0; // I FOUND THE BUG!!!
                index = parent, parent = (index - 1) / 2)
            {
                _list.Swap(index, parent);
            }

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
            int index = _list.IndexOf(item);
            if (index < 0)
            {
                return false;
            }
            else
            {
                _list.Swap(index, _list.Count - 1);

                // Bubble down except for _list.Count - 1 because we don't want the last element being swapped
                for (int left = 2 * index + 1, smaller = left;
                    left < _list.Count - 1;
                    index = smaller, left = 2 * index + 1, smaller = left)
                {
                    smaller += left + 1 < _list.Count - 1 && Comparer.Compare(_list[left], _list[left + 1]) > 0 ? 1 : 0;
                    if (Comparer.Compare(_list[index], _list[smaller]) > 0) // I FOUND THE SECOND BUG!!!
                    {
                        _list.Swap(index, smaller);
                    }
                    else
                    {
                        break;
                    }
                }

                _list.RemoveAt(_list.Count - 1);
                return true;
            }
        }
    }
}
