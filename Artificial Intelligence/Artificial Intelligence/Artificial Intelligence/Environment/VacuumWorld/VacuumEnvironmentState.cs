using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Guard;
using System.Collections.Generic;

namespace Artificial_Intelligence.Environment.VacuumWorld
{
    /// <summary>
    /// A possible state of a vacuum environment.
    /// </summary>
    public class VacuumEnvironmentState : IEnvironmentState
    {
        /// <summary>
        /// A mapping of agents to locations.
        /// </summary>
        private readonly IDictionary<VacuumAgent, Location> _locations = new Dictionary<VacuumAgent, Location>();

        /// <summary>
        /// A mapping of locations to statuses.
        /// </summary>
        private readonly IDictionary<Location, Status> _statuses = new Dictionary<Location, Status>();

        /// <summary>
        /// A simple view of the vacuum environment's locations.
        /// </summary>
        public IEnumerable<Location> Locations { get { return new List<Location>(_statuses.Keys); } }

        /// <summary>
        /// Maps agents to their locations.
        /// </summary>
        /// <param name="agent">An agent.</param>
        /// <returns>Agent's location.</returns>
        public Location GetAgentLocation(VacuumAgent agent)
        {
            Location location = default(Location);
            _locations.TryGetValue(agent.NonNull(), out location);
            return location;
        }

        /// <summary>
        /// Adds a mapping of agent to location to the environment state.
        /// </summary>
        /// <param name="agent">An agent.</param>
        /// <param name="location">New location.</param>
        public void SetAgentLocation(VacuumAgent agent, Location location)
        {
            _locations[agent.NonNull()] = location;
        }

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
