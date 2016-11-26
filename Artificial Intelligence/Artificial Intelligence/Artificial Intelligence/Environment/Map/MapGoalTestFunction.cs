using Artificial_Intelligence.Chapter_3.Problem;

namespace Artificial_Intelligence.Environment.Map
{
    /// <summary>
    /// A map goal test function that returns whether the given state equals a singular goal state.
    /// </summary>
    /// <typeparam name="TState">Any map state.</typeparam>
    public class MapGoalTestFunction<TState> : GoalTestFunction<TState>
        where TState : IMapState
    {
        /// <summary>
        /// Specifies a singular goal state.
        /// </summary>
        /// <param name="goal">A singular goal state.</param>
        public MapGoalTestFunction(TState goal) : base(goal)
        {

        }
    }
}
