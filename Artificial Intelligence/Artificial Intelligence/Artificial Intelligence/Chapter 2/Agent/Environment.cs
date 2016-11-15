using Artificial_Intelligence.Guard;
using System.Collections.Generic;
using System;

namespace Artificial_Intelligence.Chapter_2.Agent
{
    /// <summary>
    /// An agent's abstract envrionment which provides sensors and actuators to the agent.
    /// </summary>
    /// <typeparam name="TAgent">Any agent of TPercept and TAction.</typeparam>
    /// <typeparam name="TPercept">Any percept.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public abstract class Environment<TAgent, TPercept, TAction> : IEnvironment<TAgent, TPercept, TAction>
        where TAgent : IAgent<TPercept, TAction>
        where TPercept : IPercept
        where TAction : IAction
    {
        /// <summary>
        /// Backing field for a simple view of the environment's agents.
        /// </summary>
        private readonly ISet<TAgent> _agents = new HashSet<TAgent>();

        /// <summary>
        /// A mapping of agents to performance measures.
        /// </summary>
        private readonly IDictionary<TAgent, double> _performanceMeasures = new Dictionary<TAgent, double>();

        /// <summary>
        /// A simple view of the environment's agents.
        /// </summary>
        public IEnumerable<TAgent> Agents { get { return _agents; } }

        /// <summary>
        /// Whether or not the environment is finished being actuated upon.
        /// </summary>
        public abstract bool IsDone { get; }

        /// <summary>
        /// Performs agent's action on the environment.
        /// </summary>
        /// <param name="agent">An agent.</param>
        /// <param name="action">An action.</param>
        public abstract void Actuate(TAgent agent, TAction action);

        /// <summary>
        /// Adds an agent to the environment's agents.
        /// </summary>
        /// <param name="agent">New agent.</param>
        public virtual void Add(TAgent agent)
        {
            _agents.Add(agent.NonNull());
        }

        /// <summary>
        /// Maps agents to their performance measures.
        ///  If the environment does not contain an agent, a new mapping is added with a default value.
        /// </summary>
        /// <param name="agent">New agent.</param>
        /// <returns>Agent's performance measure.</returns>
        public virtual double GetPerformanceMeasure(TAgent agent)
        {
            if (!_performanceMeasures.ContainsKey(agent.NonNull()))
            {
                _performanceMeasures[agent] = default(double);
            }
            return _performanceMeasures[agent];
        }

        /// <summary>
        /// Removes the first occurence of an agent from the envrionment's agents.
        /// </summary>
        /// <param name="agent">An agent.</param>
        public virtual void Remove(TAgent agent)
        {
            _agents.Remove(agent);
        }

        /// <summary>
        /// Creates an agent's inputs at the current step.
        /// </summary>
        /// <param name="agent">An agent.</param>
        /// <returns>An agent's inputs at the current step.</returns>
        public abstract TPercept Sense(TAgent agent);

        /// <summary>
        /// Moves the environment forward by one step.
        /// </summary>
        public virtual void Step()
        {
            foreach (TAgent agent in _agents)
            {
                TPercept percept = Sense(agent);
                TAction action = agent.Invoke(percept);
                Actuate(agent, action);
            }
        }

        /// <summary>
        /// Moves the environment forward by the number of steps.
        /// </summary>
        /// <param name="steps">The number of steps.</param>
        public void Step(uint steps = 1)
        {
            while (steps-- > 0)
            {
                Step();
            }
        }

        /// <summary>
        /// While the environment is not done, calls step.
        /// </summary>
        public void StepUntilDone()
        {
            while (!IsDone)
            {
                Step();
            }
        }

        /// <summary>
        /// Changes an agent's mapping to performance measures by the marginal amount.
        /// If the environment does not contain an agent, a new mapping is added with a default value.
        /// </summary>
        /// <param name="agent">An agent.</param>
        /// <param name="changeInPerformanceMeasure">Change in agent's performance measure.</param>
        protected void ChangePerformanceMeasure(TAgent agent, double changeInPerformanceMeasure)
        {
            if (!_performanceMeasures.ContainsKey(agent.NonNull()))
            {
                _performanceMeasures[agent] = default(double);
            }
            _performanceMeasures[agent] += changeInPerformanceMeasure;
        }
    }
}
