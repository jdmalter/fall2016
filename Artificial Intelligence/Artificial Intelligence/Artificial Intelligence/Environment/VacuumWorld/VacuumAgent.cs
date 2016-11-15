using Artificial_Intelligence.Chapter_2.Agent;

namespace Artificial_Intelligence.Environment.VacuumWorld
{
    /// <summary>
    /// An vacuum agent interacts with a vacuum environment.
    /// </summary>
    public class VacuumAgent : Agent<VacuumPercept, VacuumAction>
    {
        /// <summary>
        /// Specifies an agent program.
        /// </summary>
        /// <param name="agentProgram">An agent program.</param>
        public VacuumAgent(IAgentProgram<VacuumPercept, VacuumAction> agentProgram) : base(agentProgram)
        {

        }
    }
}
