using Artificial_Intelligence.Chapter_3.Problem;

namespace Artificial_Intelligence.Environment.VacuumWorld
{
    /// <summary>
    /// A vacuum goal test function that returns whether both locations are clean.
    /// </summary> 
    public class VacuumGoalTestFunction : IGoalTestFunction<VacuumState>
    {
        /// <summary>
        /// Determines whether the given state is a goal state.
        /// </summary>
        /// <param name="state">A particular state.</param>
        /// <returns>Whether the given state is a goal state.</returns>
        public bool GoalTest(VacuumState state)
        {
            return state.GetLocationStatus(VacuumEnvironment.A) == VacuumEnvironment.CLEAN
                 && state.GetLocationStatus(VacuumEnvironment.B) == VacuumEnvironment.CLEAN;
        }
    }
}
