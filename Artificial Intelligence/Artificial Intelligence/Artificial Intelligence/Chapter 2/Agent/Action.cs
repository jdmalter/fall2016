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
        /// Action's string representation. 
        /// </summary>
        public string Name { get; }
    }
}
