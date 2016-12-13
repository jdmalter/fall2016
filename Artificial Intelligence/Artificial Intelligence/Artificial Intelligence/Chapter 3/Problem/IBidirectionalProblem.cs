using Artificial_Intelligence.Chapter_2.Agent;

namespace Artificial_Intelligence.Chapter_3.Problem
{
    /// <summary>
    /// A problem that searches forward from the initial state and backward from the goal state.
    /// </summary>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public interface IBidirectionalProblem<TState, TAction> : IProblem<TState, TAction>
        where TState : IState
        where TAction : IAction
    {
        /// <summary>
        /// The singular goal state and initial state of the reverse problem.
        /// </summary>
        TState GoalState { get; }

        /// <summary>
        /// A problem whose initial state and goal state are reverse of the original problem.
        /// </summary>
        IBidirectionalProblem<TState, TAction> Reverse { get; }
    }
}
