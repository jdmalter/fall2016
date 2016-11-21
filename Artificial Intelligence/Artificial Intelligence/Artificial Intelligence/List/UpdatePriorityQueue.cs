using Artificial_Intelligence.Guard;
using System;
using System.Collections.Generic;

namespace Artificial_Intelligence.List
{
    /// <summary>
    /// An update priority queue.
    /// </summary>
    /// <typeparam name="T">Any type.</typeparam>
    public class UpdatePriorityQueue<T> : IUpdatePriorityQueue<T>
    {
        /// <summary>
        /// Backing data structure.
        /// </summary>
        private readonly IList<T> _list = new List<T>();

        /// <summary>
        /// A mapping of items to their indexes in the list.
        /// </summary>
        private readonly IDictionary<T, int> _indexes = new Dictionary<T, int>();

        /// <summary>
        /// Specifes a method that compares two objects.
        /// </summary>
        /// <param name="comparer">A method that compares two objects.</param>
        public UpdatePriorityQueue(IComparer<T> comparer)
        {
            Comparer = comparer.NonNull();
        }

        /// <summary>
        /// A method that compares two objects.
        /// </summary>
        public IComparer<T> Comparer { get; }

        /// <summary>
        /// Decrease the item if the given item is less than an equal item in the queue.
        /// Returns the queue with the decreased item.
        /// </summary>
        /// <param name="item">Removed item.</param>
        /// <returns>The queue with the decreased item.</returns>
        public IUpdatePriorityQueue<T> Decrease(T item)
        {
            int index;

            if (_indexes.TryGetValue(item, out index) && Comparer.Compare(item, _list[index]) < 0)
            {
                _list[index] = item;

                // Bubble down
                for (int left = 2 * index + 1, smaller = left;
                    2 * index + 1 < _list.Count;
                    index = smaller, left = 2 * index + 1, smaller = left)
                {
                    smaller += left + 1 < _list.Count && Comparer.Compare(_list[left], _list[left + 1]) >= 0 ? 1 : 0;
                    Swap(index, smaller);
                }
            }

            return this;
        }

        /// <summary>
        /// Decrease the item if the given item is greater than an equal item in the queue.
        /// Returns the queue with the increased item.
        /// </summary>
        /// <param name="item">Removed item.</param>
        /// <returns>The queue with the increased item.</returns>
        public IUpdatePriorityQueue<T> Increase(T item)
        {
            int index;

            if (_indexes.TryGetValue(item, out index) && Comparer.Compare(item, _list[index]) > 0)
            {
                _list[index] = item;

                // Bubble up
                for (int parent = (index - 1) / 2;
                    index > 0 && Comparer.Compare(_list[index], _list[parent]) >= 0;
                    index = parent, parent = (index - 1) / 2)
                {
                    Swap(index, parent);
                }
            }

            return this;
        }

        /// <summary>
        /// Inserts the given item into list at the given index and adds item into indexes with index.
        /// </summary>
        /// <param name="index">An index at which the given item is inserted.</param>
        /// <param name="item">Inserted item.</param>
        private void Insert(int index, T item)
        {
            _list.Insert(index, item);
            _indexes[item] = index;
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
                    smaller += left + 1 < _list.Count && Comparer.Compare(_list[left], _list[left + 1]) >= 0 ? 1 : 0;
                    Swap(index, smaller);
                }

                _list.RemoveAt(_list.Count - 1);
                _indexes.Remove(first);
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
            if (!_indexes.ContainsKey(item))
            {
                Insert(_list.Count, item);

                // Bubble up
                for (int index = _list.Count - 1, parent = (index - 1) / 2;
                    index > 0 && Comparer.Compare(_list[index], _list[parent]) >= 0;
                    index = parent, parent = (index - 1) / 2)
                {
                    Swap(index, parent);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Swaps the given items in list and indexes.
        /// </summary>
        /// <param name="a">An item to swap.</param>
        /// <param name="b">An item to swap.</param>
        private void Swap(int a, int b)
        {
            _indexes[_list[a]] = b;
            _indexes[_list[b]] = a;
            _list.Swap(a, b);
        }

        /// <summary>
        /// Decreases/increases/resets the item if the given item is equal to an item in the queue.
        /// Returns the queue with the updated item.
        /// </summary>
        /// <param name="item">Updated item.</param>
        /// <returns>The queue with the updated item.</returns>
        public IUpdatePriorityQueue<T> Update(T item)
        {
            int index;

            if (_indexes.TryGetValue(item, out index))
            {
                _list[index] = item;

                int comparison = Comparer.Compare(item, _list[index]);
                if (comparison < 0)
                {
                    // Bubble down
                    for (int left = 2 * index + 1, smaller = left;
                        2 * index + 1 < _list.Count;
                        index = smaller, left = 2 * index + 1, smaller = left)
                    {
                        smaller += left + 1 < _list.Count && Comparer.Compare(_list[left], _list[left + 1]) >= 0 ? 1 : 0;
                        Swap(index, smaller);
                    }
                }
                else if (comparison > 0)
                {
                    // Bubble up
                    for (int parent = (index - 1) / 2;
                        index > 0 && Comparer.Compare(_list[index], _list[parent]) >= 0;
                        index = parent, parent = (index - 1) / 2)
                    {
                        Swap(index, parent);
                    }
                }
            }

            return this;
        }
    }
}
