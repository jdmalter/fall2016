using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Guard;
using System.Collections.Generic;

namespace Artificial_Intelligence.Environment.VacuumWorld
{
    /// <summary>
    /// An agent's memory of its environment.
    /// </summary>
    public class VacuumState : IState
    {
        /// <summary>
        /// An agent's current location.
        /// </summary>
        private Location _location;

        /// <summary>
        /// A mapping of locations to statuses.
        /// </summary>
        private readonly IDictionary<Location, Status> _statuses = new Dictionary<Location, Status>();

        /// <summary>
        /// Specifies an agent's current location.
        /// </summary>
        /// <param name="location">An agent's current location.</param>
        public VacuumState(Location location)
        {
            Location = location;
        }

        /// <summary>
        /// A simple view of the vacuum environment's locations.
        /// </summary>
        public Location Location { get { return _location; } set { _location = value.NonNull(); } }

        /// <summary>
        /// Maps locations to their statuses.
        /// </summary>
        /// <param name="location">A location.</param>
        /// <returns>Location's status.</returns>
        public Status GetLocationStatus(Location location)
        {
            Status status = default(Status);
            _statuses.TryGetValue(location.NonNull(), out status);
            return status;
        }

        /// <summary>
        /// Adds a mapping of location to status to the environment state.
        /// </summary>
        /// <param name="location">A location.</param>
        /// <param name="status">New status.</param>
        public void SetLocationStatus(Location location, Status status)
        {
            _statuses[location.NonNull()] = status;
        }
    }
}
