namespace Artificial_Intelligence.List
{
    /// <summary>
    /// A priority queue which does not support duplicate items.
    /// </summary>
    /// <typeparam name="T">Any type.</typeparam>
    public interface IUpdatePriorityQueue<T> : IPriorityQueue<T>
    {
        /// <summary>
        /// Decrease the item if the given item is less than an equal item in the queue.
        /// Returns the queue with the decreased item.
        /// </summary>
        /// <param name="item">Removed item.</param>
        /// <returns>The queue with the decreased item.</returns>
        IUpdatePriorityQueue<T> Decrease(T item);

        /// <summary>
        /// Decrease the item if the given item is greater than an equal item in the queue.
        /// Returns the queue with the increased item.
        /// </summary>
        /// <param name="item">Removed item.</param>
        /// <returns>The queue with the increased item.</returns>
        IUpdatePriorityQueue<T> Increase(T item);

        /// <summary>
        /// Decreases or increases the item if the given item is equal to an item in the queue.
        /// Returns the queue with the updated item.
        /// </summary>
        /// <param name="item">Updated item.</param>
        /// <returns>The queue with the updated item.</returns>
        IUpdatePriorityQueue<T> Update(T item);
    }
}
