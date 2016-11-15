using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Environment.VacuumWorld
{
    /// <summary>
    /// A functional interface for Result.
    /// </summary>
    public class VacuumResultFunction : IResultFunction<VacuumState, VacuumAction>
    {
        /// <summary>
        /// Returns the state that results from doing the given action in the given state.
        /// </summary>
        /// <param name="state">A particular state.</param>
        /// <param name="action">An action being executed in a particular state.</param>
        /// <returns>The state that results from doing the given action in the given state.</returns>
        public VacuumState Result(VacuumState state, VacuumAction action)
        {
            state.NonNull();

            if (VacuumEnvironment.LEFT == action)
            {
                state.Location = VacuumEnvironment.A;
            }
            else if (VacuumEnvironment.RIGHT == action)
            {
                state.Location = VacuumEnvironment.B;
            }
            else if (VacuumEnvironment.SUCK == action)
            {
                state.SetLocationStatus(state.Location, VacuumEnvironment.CLEAN);
            }

            return state;
        }
    }
}
