using Artificial_Intelligence.Chapter_2.Agent;

namespace Artificial_Intelligence.Chapter_3.Problem
{
    /// <summary>
    /// A functional interface for GoalTest.
    /// </summary>    
    /// <typeparam name="TState">Any state.</typeparam>
    public interface IGoalTestFunction<TState>
        where TState : IState
    {
        /// <summary>
        /// Determines whether the given state is a goal state.
        /// </summary>
        /// <param name="state">A particular state.</param>
        /// <returns>Whether the given state is a goal state.</returns>
        bool GoalTest(TState state);
    }
}
