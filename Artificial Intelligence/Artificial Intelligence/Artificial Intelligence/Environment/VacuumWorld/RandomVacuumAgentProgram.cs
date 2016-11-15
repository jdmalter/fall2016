using Artificial_Intelligence.Chapter_2.Agent;
using System.Collections.Generic;

namespace Artificial_Intelligence.Environment.VacuumWorld
{
    /// <summary>
    /// A random agent for vacuum world.
    /// </summary>
    public class RandomVacuumAgentProgram : RandomAgentProgram<VacuumPercept, VacuumAction>
    {
        /// <summary>
        /// Specifies a set of vacuum actions.
        /// </summary>
        /// <param name="actions">A set of vacuum actions.</param>
        public RandomVacuumAgentProgram(ISet<VacuumAction> actions) : base(actions)
        {

        }
    }
}
