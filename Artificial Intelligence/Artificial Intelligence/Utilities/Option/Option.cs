using System;

namespace Utilities.Option
{
    /// <summary>
    /// Inspired by F# Option type. Option values can be Some or None.
    /// Some Options take a value, and None Options take no value. Every None Option is the same.
    /// </summary>
    /// <typeparam name="T">Any generic type.</typeparam>
    public struct Option<T>
    {
        /// <summary>
        /// None Option.
        /// </summary>
        public static Option<T> None { get { return default(Option<T>); } }

        /// <summary>
        /// Any generic value for Some Option.
        /// </summary>
        private readonly T _value;

        /// <summary>
        /// Takes a value and sets IsSome to true.
        /// </summary>
        /// <param name="value">Any generic value.</param>
        public Option(T value)
        {
            _value = value;
            IsSome = true;
        }

        /// <summary>
        /// Converts any generic value into Some Option.
        /// </summary>
        /// <param name="value">Any generic value.</param>
        public static implicit operator Option<T>(T value)
        {
            return new Option<T>(value);
        }

        /// <summary>
        /// Converts Some Option into any generic value. If IsNone, InvalidCastException is thrown.
        /// </summary>
        /// <param name="option">Some Option.</param>
        public static explicit operator T(Option<T> option)
        {
            if (option.IsSome)
            {
                return option._value;
            }
            else
            {
                throw new InvalidCastException("option is none");
            }
        }

        /// <summary>
        /// Determines whether Option is Some.
        /// </summary>
        public bool IsSome { get; }

        /// <summary>
        /// Determines whether Option is None.
        /// </summary>
        public bool IsNone { get { return !IsSome; } }

        /// <summary>
        /// Determines whether the specified Option is equal to the current Option.
        /// </summary>
        /// <param name="obj">The Option to compare with the current Option.</param>
        /// <returns>true if the specified Option is equal to the current Option; otherwise, false.</returns>
        public bool Equals(Option<T> obj)
        {
            return (IsSome == obj.IsSome) && (IsNone || Equals(_value, obj._value));
        }

        /// <summary>
        /// Determines whether the specified Object is equal to the current Object.
        /// </summary>
        /// <param name="obj">The object to compare with the current Object.</param>
        /// <returns>true if the specified Object is equal to the current Object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Option<T> && Equals((Option<T>)obj);
        }

        /// <summary>
        /// Serves as a hash function for Option. None Options hash to int.Minvalue. Some Options with null value hash to int.MaxValue.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return IsSome ? (_value != null ? _value.GetHashCode() : int.MaxValue) : int.MinValue;
        }
    }

}