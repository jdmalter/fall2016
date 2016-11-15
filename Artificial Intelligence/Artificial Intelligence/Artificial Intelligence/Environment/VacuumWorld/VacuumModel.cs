using Artificial_Intelligence.Chapter_2.Agent;

namespace Artificial_Intelligence.Environment.VacuumWorld
{
    /// <summary>
    /// A description of how the next vacuum state depends on current vacuum state and vacuum action.
    /// </summary>
    public class VacuumModel : IModel<VacuumState, VacuumPercept, VacuumAction>
    {
        /// <summary>
        /// Creates the new internal state description.
        /// </summary>
        /// <param name="state">The agent's current conception of the world state.</param>
        /// <param name="percept">New percept.</param>
        /// <param name="action">The most recent action.</param>
        /// <returns>The updated conception for the world state.</returns>
        public VacuumState UpdateState(VacuumState state, VacuumPercept percept, VacuumAction action)
        {
            state = state ?? new VacuumState(percept.Location);
            state.SetLocationStatus(percept.Location, percept.Status);

            if (VacuumEnvironment.LEFT == action)
            {
                state.Location = VacuumEnvironment.A;
            }
            else if (VacuumEnvironment.RIGHT == action)
            {
                state.Location = VacuumEnvironment.B;
            }
            else if (VacuumEnvironment.SUCK == action)
            {
                state.SetLocationStatus(percept.Location, percept.Status);
            }

            return state;
        }
    }
}
