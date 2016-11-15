namespace Artificial_Intelligence.Chapter_2.Agent
{
    /// <summary>
    /// An agent interacts with an environment.
    /// </summary>
    /// <typeparam name="TPercept"></typeparam>
    /// <typeparam name="TAction"></typeparam>
    public interface IAgent<TPercept, TAction>
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
