using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Chapter_2.Agent
{
    /// <summary>
    /// An agents's actions through actuators on an environment. 
    /// </summary>
    public abstract class Action : IAction
    {
        /// <summary>
        /// Specifies the string representation.
        /// </summary>
        /// <param name="name">The string representation.</param>
        public Action(string name)
        {
            Name = name.NonNull();
        }

        /// <summary>
        /// The string representation. 
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Determines whether the given object is equal to the current object.
        /// </summary>
        /// <param name="obj">Any object.</param>
        /// <returns>Whether the given object is equal to the current object.</returns>
        public override bool Equals(object obj)
        {
            Action action = obj as Action;

            return action != null && ReferenceEquals(Name, action.Name);
        }

        /// <summary>
        /// Uses hash function of the string representation. 
        /// </summary>
        /// <returns>A hash code for the string representation.</returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
