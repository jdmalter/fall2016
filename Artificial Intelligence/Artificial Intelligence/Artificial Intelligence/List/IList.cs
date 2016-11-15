using System.Collections.Generic;

namespace Artificial_Intelligence.List
{
    /// <summary>
    /// An extension of genereic IList.
    /// </summary>
    public static class IList
    {
        /// <summary>
        /// Creates an empty list.
        /// </summary>
        /// <typeparam name="T">Any type.</typeparam>
        /// <returns>An empty list.</returns>
        public static IList<T> Empty<T>()
        {
            return new List<T>();
        }

        /// <summary>
        /// Determines whether the given list contains any elements.
        /// </summary>
        /// <typeparam name="T">Any type.</typeparam>
        /// <param name="list">A list possibily containing elements.</param>
        /// <returns>Whether the given list contains any elements.</returns>
        public static bool IsEmpty<T>(this IList<T> list)
        {
            return 0 == list.Count;
        }

        /// <summary>
        /// Returns the first element.
        /// </summary>
        /// <typeparam name="T">Any type.</typeparam>
        /// <param name="list">A list consisting of at least the first element.</param>
        /// <returns>The first element.</returns>
        public static T First<T>(this IList<T> list)
        {
            return list[0];
        }

        /// <summary>
        /// Returns a list consisting of all but the first element.
        /// </summary>
        /// <typeparam name="T">Any type.</typeparam>
        /// <param name="list">A list consisting of all elements.</param>
        /// <returns>A list consisting of all but the first element.</returns>
        public static IList<T> Rest<T>(this IList<T> list)
        {
            list.RemoveAt(0);
            return list;
        }

        /// <summary>
        /// Returns a list with the given item as its first element
        /// and the given list as its remaining elements.
        /// </summary>
        /// <typeparam name="T">Any type.</typeparam>
        /// <param name="item">New first element.</param>
        /// <param name="list">New remaining elements.</param>
        /// <returns>A list with the given item as its first element
        /// and the given list as its remaining elements.</returns>
        public static IList<T> Cons<T>(this T item, IList<T> list)
        {
            list.Insert(0, item);
            return list;
        }
    }
}
