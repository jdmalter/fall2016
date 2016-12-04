using System;
using System.Collections.Generic;

namespace Artificial_Intelligence.Collections
{
    /// <summary>
    /// An extension of genereic IList.
    /// </summary>
    public static class IListExtension
    {
        /// <summary>
        /// Determines whether the given list contains any elements.
        /// </summary>
        /// <typeparam name="T">Any type.</typeparam>
        /// <param name="list">A list possibily containing elements.</param>
        /// <returns>Whether the given list contains any elements.</returns>
        public static bool IsEmpty<T>(this IList<T> list)
        {
            return list.Count == 0;
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
        /// Swaps the given items.
        /// </summary>
        /// <typeparam name="T">Any type.</typeparam>
        /// <param name="list">A list consisting of unswapped items.</param>
        /// <param name="a">An item to swap.</param>
        /// <param name="b">An item to swap.</param>
        public static void Swap<T>(this IList<T> list, int a, int b)
        {
            if (a >= list.Count || b >= list.Count)
            {
                throw new IndexOutOfRangeException("indexes must be less than " + list.Count);
            }
            else
            {
                T temporary = list[a];
                list[a] = list[b];
                list[b] = temporary;
            }
        }
    }
}
