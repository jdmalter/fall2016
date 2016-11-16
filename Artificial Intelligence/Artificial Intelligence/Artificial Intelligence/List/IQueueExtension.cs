namespace Artificial_Intelligence.List
{
    /// <summary>
    /// An extension of genereic IQueue.
    /// </summary>
    public static class IQueueExtension
    {
        /// <summary>
        /// Removes every element from the current queue and returns the same empty queue.
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
    }
}
