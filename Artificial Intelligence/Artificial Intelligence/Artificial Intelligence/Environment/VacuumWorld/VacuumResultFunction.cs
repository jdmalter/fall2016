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

            if (VacuumAction.LEFT == action)
            {
                state.Location = Location.A;
            }
            else if (VacuumAction.RIGHT == action)
            {
                state.Location = Location.B;
            }
            else if (VacuumAction.SUCK == action)
            {
                state.SetLocationStatus(state.Location, Status.CLEAN);
            }

            return state;
        }
    }
}
