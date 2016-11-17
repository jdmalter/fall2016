using Artificial_Intelligence.Chapter_2.Agent;

namespace Artificial_Intelligence.Environment.VacuumWorld
{
    /// <summary>
    /// A reflex agent for vacuum world.
    /// </summary>
    public class ReflexVacuumAgentProgram : IAgentProgram<VacuumPercept, VacuumAction>
    {
        /// <summary>
        /// Maps percepts to actions.
        /// </summary>
        /// <param name="percept">New percept.</param>
        /// <returns>An action.</returns>
        public VacuumAction Invoke(VacuumPercept percept)
        {
            if (percept.Status == Status.DIRTY)
            {
                return VacuumAction.SUCK;
            }
            else if (percept.Location == Location.A)
            {
                return VacuumAction.RIGHT;
            }
            else if (percept.Location == Location.B)
            {
                return VacuumAction.LEFT;
            }
            else
            {
                return VacuumAction.NULL;
            }
        }
    }
}
