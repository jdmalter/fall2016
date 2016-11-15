using Artificial_Intelligence.Guard;
using System;

namespace Artificial_Intelligence.Chapter_2.Agent
{
    /// <summary>
    /// An abstract agent interacts with an environment.
    /// </summary>
    /// <typeparam name="TPercept">Any percept.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public abstract class Agent<TPercept, TAction> : IAgent<TPercept, TAction>
        where TPercept : IPercept
        where TAction : IAction
    {
        /// <summary>
        /// The implementation of the agent function.
        /// </summary>
        private readonly IAgentProgram<TPercept, TAction> _agentProgram;

        /// <summary>
        /// Specifies the implementation of the agent function.
        /// </summary>
        /// <param name="agentProgram">The implementation of the agent function.</param>
        public Agent(IAgentProgram<TPercept, TAction> agentProgram)
        {
            _agentProgram = agentProgram.NonNull();
        }

        /// <summary>
        /// Maps percepts to actions.
        /// </summary>
        /// <param name="percept">New percept.</param>
        /// <returns>An action.</returns>
        public TAction Invoke(TPercept percept)
        {
            return _agentProgram.Invoke(percept);
        }
    }
}
