using System.Collections.Generic;
using Artificial_Intelligence.Chapter_3.Problem;

namespace Artificial_Intelligence.Environment.VacuumWorld
{
    /// <summary>
    /// A functional interface for Actions.
    /// </summary>
    public class VacuumActionsFunction : IActionsFunction<VacuumState, VacuumAction>
    {
        /// <summary>
        /// Returns the set of actions that can be executed in the given state.
        /// </summary>
        /// <param name="state">A particular state.</param>
        /// <returns>The set of actions that can be executed in the given state.</returns>
        public ISet<VacuumAction> Actions(VacuumState state)
        {
            return new HashSet<VacuumAction>()
            {
                VacuumAction.NULL,
                VacuumAction.LEFT,
                VacuumAction.RIGHT,
                VacuumAction.SUCK,
            };
        }
    }
}
