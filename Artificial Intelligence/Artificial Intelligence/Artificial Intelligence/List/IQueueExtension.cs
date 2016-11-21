using System;

namespace Artificial_Intelligence.List
{
    /// <summary>
    /// An extension of genereic IQueue.
    /// </summary>
    public static class IQueueExtension
    {
        /// <summary>
        /// Removes every item from the current queue and returns the same empty queue.
        /// Returns the same empty queue.
        /// </summary>
        /// <typeparam name="T">Any type.</typeparam>
        /// <param name="queue">A queue.</param>
        /// <returns>The same empty queue.</returns>
        public static IQueue<T> Clear<T>(this IQueue<T> queue)
        {
            while (!queue.IsEmpty())
            {
                queue.Pop();
            }
            return queue;
        }

        /// <summary>
        /// Removes every item from the current queue while the queue is not empty
        /// and the next item meets the predicate's criteria. Returns the same queue.
        /// </summary>
        /// <typeparam name="T">Any type.</typeparam>
        /// <param name="queue">A queue.</param>
        /// <param name="predicate">A method that determines whether or not an object of T meets a criteria.</param>
        /// <returns>The same queue.</returns>
        public static IQueue<T> PopWhile<T>(this IQueue<T> queue, Predicate<T> predicate)
        {
            while (!queue.IsEmpty() && predicate(queue.Peek()))
            {
                queue.Pop();
            }
            return queue;
        }
    }
}
