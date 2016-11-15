using Artificial_Intelligence.Chapter_2.Agent;
using System.Collections.Generic;

namespace Artificial_Intelligence.Environment.VacuumWorld
{
    /// <summary>
    ///  A model reflex agent for vacuum world.
    /// </summary>
    public class ModelReflexVacuumAgentProgram : ModelReflexAgentProgram<VacuumModel, VacuumPercept, VacuumConditionActionRule, VacuumState, VacuumAction>
    {
        /// <summary>
        /// Specifies a description of how the next state depends on current state, percept, and action,
        /// a set of condition action rules, and an alternative rule if rules does not contain a matching rule.
        /// </summary>
        /// <param name="model">A description of how the next state depends on current state and action.</param>
        /// <param name="rules">A set of condition action rules.</param>
        /// <param name="rule">An alternative rule if rules does not contain a matching rule.</param>
        public ModelReflexVacuumAgentProgram(VacuumModel model, ISet<VacuumConditionActionRule> rules, VacuumConditionActionRule rule) : base(model, rules, rule)
        {

        }

        /// <summary>
        /// Creates the new internal state description.
        /// </summary>
        /// <param name="state">The agent's current conception of the world state.</param>
        /// <param name="percept">New percept.</param>
        /// <param name="action">The most recent action.</param>
        /// <param name="model">A description of how the next state depends on current state and action.</param>
        /// <returns>The agent's updated conception of the world state.</returns>
        public override VacuumState UpdateState(VacuumState state, VacuumPercept percept, VacuumAction action, VacuumModel model)
        {
            return model.UpdateState(state, percept, action);
        }
    }
}
