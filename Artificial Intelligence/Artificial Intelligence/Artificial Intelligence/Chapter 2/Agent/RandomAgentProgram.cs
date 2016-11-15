using Artificial_Intelligence.Guard;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Artificial_Intelligence.Chapter_2.Agent
{
    /// <summary>
    /// The random agent program is invoked for each new percept and returns a random action each time.
    /// </summary>
    /// <typeparam name="TPercept">Any percept.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public abstract class RandomAgentProgram<TPercept, TAction> : IAgentProgram<TPercept, TAction>
            where TPercept : IPercept
            where TAction : IAction
    {
        /// <summary>
        /// A pseudo-random number generator.
        /// </summary>
        private readonly Random _random = new Random();

        /// <summary>
        /// A set of actions.
        /// </summary>
        private readonly ISet<TAction> _actions;

        /// <summary>
        /// Specifies a set of actions.
        /// </summary>
        /// <param name="actions">A set of actions.</param>
        public RandomAgentProgram(ISet<TAction> actions)
        {
            if (actions.NonNull().Count == 0)
            {
                throw new ArgumentException("actions must contain at least one action");
            }
            _actions = actions;
        }

        /// <summary>
        /// Randomly selects an action.
        /// </summary>
        /// <param name="percept">New percept.</param>
        /// <returns>An action.</returns>
        public TAction Invoke(TPercept percept)
        {
            return _actions.ElementAt(_random.Next(_actions.Count));
        }
    }
}
