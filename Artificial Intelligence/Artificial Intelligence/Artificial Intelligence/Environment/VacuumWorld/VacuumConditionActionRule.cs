using Artificial_Intelligence.Chapter_2.Agent;
using System;

namespace Artificial_Intelligence.Environment.VacuumWorld
{
    /// <summary>
    /// A pair of VacuumState and VacuumAction.
    /// </summary>
    public class VacuumConditionActionRule : ConditionActionRule<VacuumState, VacuumAction>
    {
        /// <summary>
        /// Specifies a condition and action.
        /// </summary>
        /// <param name="condition">A method that defines whether or not a particular state meets the criteria
        /// to invoke an action.</param>
        /// <param name="action">An action whose criteria should be met before acting upon the environment.</param>
        public VacuumConditionActionRule(Predicate<VacuumState> condition, VacuumAction action) : base(condition, action)
        {

        }
    }
}
