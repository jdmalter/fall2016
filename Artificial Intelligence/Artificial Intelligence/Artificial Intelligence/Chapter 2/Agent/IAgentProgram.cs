namespace Artificial_Intelligence.Chapter_2.Agent
{
    /// <summary>
    /// An agent programs implements the agent function.
    /// </summary>
    /// <typeparam name="TPercept">Any percept.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public interface IAgentProgram<TPercept, TAction>
        where TPercept : IPercept
        where TAction : IAction
    {
        /// <summary>
        /// Maps percepts to actions.
        /// </summary>
        /// <param name="percept">New percept.</param>
        /// <returns>An action.</returns>
        TAction Invoke(TPercept percept);
    }
}
