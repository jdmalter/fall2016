using System;

namespace Artificial_Intelligence.Guard
{
    /// <summary>
    /// An extension class for parameter validation.
    /// </summary>
    public static class ParameterGuard
    {
        /// <summary>
        /// Throws ArgumentNullException if t == null.
        /// </summary>
        /// <typeparam name="T">Any type.</typeparam>
        /// <param name="t">An object of any type.</param>
        /// <param name="paramName">The name of t that might an exception.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <returns>The same parameter.</returns>
        public static T NonNull<T>(this T t, string paramName = "", string message = "")
        {
            if (t == null)
            {
                throw new ArgumentNullException(paramName, message);
            }
            else
            {
                return t;
            }
        }
    }
}
