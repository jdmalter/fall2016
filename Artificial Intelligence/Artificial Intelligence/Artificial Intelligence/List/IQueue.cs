namespace Artificial_Intelligence.List
{
    /// <summary>
    /// A queue with is empty, peek, pop, and push operations.
    /// </summary>
    /// <typeparam name="T">Any type.</typeparam>
    public interface IQueue<T>
    {
        /// <summary>
        /// Determines whether the current queue contains any items.
        /// </summary>
        /// <returns>Whether the current queue contains any items.</returns>
        bool IsEmpty();

        /// <summary>
        /// Returns an item from the queue.
        /// </summary>
        /// <returns>An item from the queue.</returns>
        T Peek();

        /// <summary>
        /// Removes and returns an item from the queue.
        /// </summary>
        /// <returns>An item from the queue.</returns>
        T Pop();

        /// <summary>
        /// Returns whether the given item was pushed onto the queue.
        /// </summary>
        /// <param name="item">Pushed item.</param>
        /// <returns>Whether the given item was pushed onto the queue.</returns>
        bool Push(T item);
    }
}
