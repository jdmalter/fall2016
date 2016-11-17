namespace Artificial_Intelligence.Environment.VacuumWorld
{
    /// <summary>
    /// The abstraction for a single location in an environment. 
    /// </summary>
    public class Location
    {
        public static readonly Location A = new Location("A");
        public static readonly Location B = new Location("B");

        /// <summary>
        /// Specifies the string representation.
        /// </summary>
        /// <param name="name">The string representation.</param>
        private Location(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Location's string representation.
        /// </summary>
        public string Name { get; }
    }
}
