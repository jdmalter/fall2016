using System.Collections.Generic;

namespace Artificial_Intelligence.Collections
{
    /// <summary>
    /// A priority queue which may or may not support duplicate item.
    /// </summary>
    /// <typeparam name="T">Any type.</typeparam>
    public interface IPriorityQueue<T> : IQueue<T>
    {
        /// <summary>
        /// A method that compares two objects.
        /// </summary>
        IComparer<T> Comparer { get; }
    }
}
