namespace Artificial_Intelligence.Environment.VacuumWorld
{
    /// <summary>
    /// The abstraction for a single status in an environment. 
    /// </summary>
    public class Status
    {
        /// <summary>
        /// Specifies the string representation.
        /// </summary>
        /// <param name="name">The string representation.</param>
        public Status(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Status's string representation. 
        /// </summary>
        public string Name { get; }
    }
}
