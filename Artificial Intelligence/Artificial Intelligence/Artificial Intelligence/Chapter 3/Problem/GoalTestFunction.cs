using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Chapter_3.Problem
{
    /// <summary>
    /// An abstract goal test function that returns whether the given state equals a singular goal state.
    /// </summary>    
    /// <typeparam name="TState">Any state.</typeparam>
    public abstract class GoalTestFunction<TState> : IGoalTestFunction<TState>
        where TState : IState
    {
        /// <summary>
        /// A singular goal state.
        /// </summary>
        private readonly TState _goal;

        /// <summary>
        /// Specifies a singular goal state.
        /// </summary>
        /// <param name="goal">A singular goal state.</param>
        public GoalTestFunction(TState goal)
        {
            _goal = goal.NonNull();
        }

        /// <summary>
        /// Determines whether the given state is a goal state.
        /// </summary>
        /// <param name="state">A particular state.</param>
        /// <returns>Whether the given state is a goal state.</returns>
        public bool GoalTest(TState state)
        {
            state.NonNull();
            return _goal.Equals(state);
        }
    }
}
