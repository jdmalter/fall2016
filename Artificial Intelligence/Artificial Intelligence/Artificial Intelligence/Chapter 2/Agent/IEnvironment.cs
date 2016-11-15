using System.Collections.Generic;

namespace Artificial_Intelligence.Chapter_2.Agent
{
    /// <summary>
    /// An agent's envrionment which provides sensors and actuators to the agent.
    /// </summary>
    /// <typeparam name="TAgent">Any agent of TPercept and TAction.</typeparam>
    /// <typeparam name="TPercept">Any percept.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public interface IEnvironment<TAgent, TPercept, TAction>
        where TAgent : IAgent<TPercept, TAction>
        where TPercept : IPercept
        where TAction : IAction
    {
        /// <summary>
        /// A simple view of the environment's agents.
        /// </summary>
        IEnumerable<TAgent> Agents { get; }

        /// <summary>
        /// Whether or not the environment is finished being actuated upon.
        /// </summary>
        bool IsDone { get; }

        /// <summary>
        /// Performs agent's action on the environment.
        /// </summary>
        /// <param name="agent">An agent.</param>
        /// <param name="action">An action.</param>
        void Actuate(TAgent agent, TAction action);

        /// <summary>
        /// Adds an agent to the environment's agents.
        /// </summary>
        /// <param name="agent">New agent.</param>
        void Add(TAgent agent);

        /// <summary>
        /// Maps agents to their performance measures.
        /// </summary>
        /// <param name="agent">New agent.</param>
        /// <returns>Agent's performance measure.</returns>
        double GetPerformanceMeasure(TAgent agent);

        /// <summary>
        /// Removes the first occurence of an agent from the envrionment's agents.
        /// </summary>
        /// <param name="agent">An agent.</param>
        void Remove(TAgent agent);

        /// <summary>
        /// Creates an agent's inputs at the given step.
        /// </summary>
        /// <param name="agent">An agent.</param>
        /// <returns>An agent's inputs at the given step.</returns>
        TPercept Sense(TAgent agent);

        /// <summary>
        /// Moves the environment forward by one step.
        /// </summary>
        void Step();

        /// <summary>
        /// Moves the environment forward by the number of steps.
        /// </summary>
        /// <param name="steps">The number of steps.</param>
        void Step(uint steps = 1);

        /// <summary>
        /// While the environment is not done, calls step.
        /// </summary>
        void StepUntilDone();
    }
}
