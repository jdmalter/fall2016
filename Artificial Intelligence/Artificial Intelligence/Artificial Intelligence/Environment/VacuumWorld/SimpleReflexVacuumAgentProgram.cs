using System.Collections.Generic;
using Artificial_Intelligence.Chapter_2.Agent;

namespace Artificial_Intelligence.Environment.VacuumWorld
{
    /// <summary>
    /// A simple reflex agent for vacuum world.
    /// </summary>
    public class SimpleReflexVacuumAgentProgram : SimpleReflexAgentProgram<VacuumPercept, VacuumConditionActionRule, VacuumState, VacuumAction>
    {
        /// <summary>
        /// Specifies a set of condition action rules.
        /// </summary>
        /// <param name="rules">A set of condition action rules.</param>
        /// <param name="rule">An alternative rule if rules does not contain a matching rule.</param>
        public SimpleReflexVacuumAgentProgram(ISet<VacuumConditionActionRule> rules, VacuumConditionActionRule rule) : base(rules, rule)
        {

        }

        /// <summary>
        ///  Generates an agent state from the percept.
        /// </summary>
        /// <param name="percept">New percept.</param>
        /// <returns>An abstract state.</returns>
        public override VacuumState InterpretInput(VacuumPercept percept)
        {
            VacuumState state = new VacuumState(percept.Location);
            state.SetLocationStatus(percept.Location, percept.Status);
            return state;
        }
    }
}
