using System;

namespace Utilities.Option
{
    /// <summary>
    /// Additional methods for Option.
    /// </summary>
    public static class Option
    {
        /// <summary>
        /// Invokes someFunction on option if option is some; otherwise, invokes noneFunction.
        /// If someFunction or noneFunction is null, throws ArgumentNullException.
        /// </summary>
        /// <typeparam name="T">Any generic option type.</typeparam>
        /// <typeparam name="TResult">Any generic return type.</typeparam>
        /// <param name="option"></param>
        /// <param name="someFunction">Function invoked when IsSome.</param>
        /// <param name="noneFunction">Function invoked when IsNone.</param>
        /// <returns>The return value from invoking someFunction or noneFunction.</returns>
        public static TResult Match<T, TResult>(this Option<T> option, Func<T, TResult> someFunction, Func<TResult> noneFunction)
        {
            if (someFunction == null)
            {
                throw new ArgumentNullException("someFunction must not be null");
            }
            else if (noneFunction == null)
            {
                throw new ArgumentNullException("noneFunction must not be null");
            }
            else
            {
                return option.IsSome ? someFunction.Invoke((T)option) : noneFunction.Invoke();
            }
        }
    }
}
