using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Environment.VacuumWorld
{
    /// <summary>
    /// A pair of location and status.
    /// </summary>
    public class VacuumPercept : IPercept
    {
        /// <summary>
        /// Specifies location and status.
        /// </summary>
        /// <param name="location">A single location in a vacuum environment.</param>
        /// <param name="status">A single status in a vacuum environment.</param>
        public VacuumPercept(Location location, Status status)
        {
            Location = location.NonNull();
            Status = status.NonNull();
        }

        /// <summary>
        /// A single location in a vacuum environment.
        /// </summary>
        public Location Location { get; }

        /// <summary>
        /// A single status in a vacuum environment.
        /// </summary>
        public Status Status { get; }

        /// <summary>
        /// Serves as hash for VacuumPercept.
        /// </summary>
        /// <returns>A hash for location and status.</returns>
        public override int GetHashCode()
        {
            return Location.GetHashCode() ^ Status.GetHashCode();
        }

        /// <summary>
        /// Determines whether the given object is equal to the current object.
        /// </summary>
        /// <param name="obj">Any object.</param>
        /// <returns>Whether the given object is equal to the current object.</returns>
        public override bool Equals(object obj)
        {
            VacuumPercept percept = obj as VacuumPercept;
            return percept != null
                && ReferenceEquals(Location, percept.Location)
                && ReferenceEquals(Status, percept.Status);
        }
    }
}
