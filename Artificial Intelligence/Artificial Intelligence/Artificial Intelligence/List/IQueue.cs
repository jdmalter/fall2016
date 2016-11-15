using System.Collections.Generic;

namespace Artificial_Intelligence.List
{
    /// <summary>
    /// An extension of genereic IList.
    /// </summary>
    public static class IQueue
    {
        /// <summary>
        /// Removes and returns the oldest element in the list.
        /// </summary>
        /// <typeparam name="T">Any type.</typeparam>
        /// <param name="list">A list consisting of all elements.</param>
        /// <returns>The oldest element in the list.</returns>
        public static T PopFirstIn<T>(this IList<T> list)
        {
            T first = list[0];
            list.RemoveAt(0);
            return first;
        }

        /// <summary>
        /// Removes and returns the newest element in the list.
        /// </summary>
        /// <typeparam name="T">Any type.</typeparam>
        /// <param name="list">A list consisting of all elements.</param>
        /// <returns>The newest element in the list.</returns>
        public static T PopLastIn<T>(this IList<T> list)
        {
            T last = list[list.Count];
            list.RemoveAt(list.Count);
            return last;
        }

        /// <summary>
        /// Returns a list with the given item as its last element.
        /// </summary>
        /// <typeparam name="T">Any type.</typeparam>
        /// <param name="list">A list.</param>
        /// <param name="item">New last element.</param>
        /// <returns>A list with the given item as its last element.</returns>
        public static IList<T> Push<T>(this IList<T> list, T item)
        {
            list.Insert(list.Count, item);
            return list;
        }
    }
}
