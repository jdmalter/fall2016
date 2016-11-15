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
            if (percept.Status == VacuumEnvironment.DIRTY)
            {
                return VacuumEnvironment.SUCK;
            }
            else if (percept.Location == VacuumEnvironment.A)
            {
                return VacuumEnvironment.RIGHT;
            }
            else if (percept.Location == VacuumEnvironment.B)
            {
                return VacuumEnvironment.LEFT;
            }
            else
            {
                return VacuumEnvironment.NULL;
            }
        }
    }
}
