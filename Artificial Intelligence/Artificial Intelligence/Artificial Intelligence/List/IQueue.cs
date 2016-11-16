namespace Artificial_Intelligence.List
{
    /// <summary>
    /// A queue with clear, is empty, pop, and push operations.
    /// </summary>
    /// <typeparam name="T">Any type.</typeparam>
    public interface IQueue<T>
    {
        /// <summary>
        /// Determines whether the current queue contains any elements.
        /// </summary>
        /// <returns>Whether the current queue contains any elements.</returns>
        bool IsEmpty();

        /// <summary>
        /// Removes and returns an element from the queue.
        /// </summary>
        /// <param name="list">A list consisting of all elements.</param>
        /// <returns>An element from the queue.</returns>
        T Pop();

        /// <summary>
        /// Returns a queue containing the given item.
        /// </summary>
        /// <param name="item">New element.</param>
        /// <returns>A queue containing the given item.</returns>
        IQueue<T> Push(T item);
    }
}
