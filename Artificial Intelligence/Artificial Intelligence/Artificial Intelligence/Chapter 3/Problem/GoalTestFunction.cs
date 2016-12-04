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
        /// Specifies a singular goal state.
        /// </summary>
        /// <param name="goalState">A singular goal state.</param>
        public GoalTestFunction(TState goalState)
        {
            GoalState = goalState.NonNull();
        }

        /// <summary>
        /// A singular goal state.
        /// </summary>
        public TState GoalState { get; }

        /// <summary>
        /// Determines whether the given state is a goal state.
        /// </summary>
        /// <param name="state">A particular state.</param>
        /// <returns>Whether the given state is a goal state.</returns>
        public bool GoalTest(TState state)
        {
            state.NonNull();
            return GoalState.Equals(state);
        }
    }
}
