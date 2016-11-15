using Artificial_Intelligence.Chapter_3.Problem;

namespace Artificial_Intelligence.Environment.VacuumWorld
{
    /// <summary>
    /// A vacuum problem can be defined by five components:
    /// initial state, actions, transition model, goal test, and path cost.
    /// </summary>
    public class VacuumProblem : Problem<VacuumState, VacuumAction>
    {
        /// <summary>
        /// Specifies initial state, actions, transition model, goal test, and path cost.
        /// </summary>
        /// <param name="initialState">The initial state that the agent starts in.</param>
        /// <param name="actionsFunction">A functional interface for Actions.</param>
        /// <param name="resultFunction">A functional interface for Result.</param>
        /// <param name="goalTestFunction">A functional interface for GoalTest.</param>
        public VacuumProblem(VacuumState initialState,
            IActionsFunction<VacuumState, VacuumAction> actionsFunction,
            IResultFunction<VacuumState, VacuumAction> resultFunction,
            IGoalTestFunction<VacuumState> goalTestFunction)
            : base(initialState,
                  actionsFunction,
                  resultFunction,
                  goalTestFunction,
                  ConstantStepCostFunction<VacuumState, VacuumAction>.ONE)
        {

        }
    }
}
