namespace Artificial_Intelligence.Chapter_2.Agent
{
    /// <summary>
    /// A description of how the next state depends on current state, percept, and action.
    /// </summary>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TPercept">Any percept.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public interface IModel<TState, TPercept, TAction>
        where TState : IState
        where TPercept : IPercept
        where TAction : IAction
    {
        /// <summary>
        /// Creates the new internal state description.
        /// </summary>
        /// <param name="state">The agent's current conception of the world state.</param>
        /// <param name="percept">New percept.</param>
        /// <param name="action">The most recent action.</param>
        /// <returns>The updated conception for the world state.</returns>
        TState UpdateState(TState state, TPercept percept, TAction action);
    }
}
