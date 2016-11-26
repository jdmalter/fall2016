using System;
using Artificial_Intelligence.Chapter_2.Agent;
using System.Collections.Generic;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Chapter_3.Problem
{
    /// <summary>
    /// An abstract step cost function that returns the step cost mapped by
    /// the initial state, the taken action, and the final state.
    /// </summary>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public abstract class StepCostFunction<TState, TAction> : IStepCostFunction<TState, TAction>
        where TState : IState
        where TAction : IAction
    {
        /// <summary>
        /// A mapping of the initial state, the taken action, and the final state to step cost.
        /// </summary>
        private readonly IDictionary<Tuple<TState, TAction, TState>, double> _stepCosts;

        /// <summary>
        /// Specifies a mapping of the initial state, the taken action, and the final state to step cost.
        /// </summary>
        /// <param name="stepCosts">A mapping of the initial state, the taken action, and the final state to step cost.</param>
        public StepCostFunction(IDictionary<Tuple<TState, TAction, TState>, double> stepCosts)
        {
            _stepCosts = stepCosts.NonNull();
        }

        /// <summary>
        /// Returns the cost of taking the given action in the initial state to reach the final state.
        /// </summary>
        /// <param name="initial">The initial state.</param>
        /// <param name="action">The taken action.</param>
        /// <param name="final">The final state.</param>
        /// <returns>The cost of taking the given action in the initial state to reach the final state.</returns>
        public double StepCost(TState initial, TAction action, TState final)
        {
            double stepCost;

            Tuple<TState, TAction, TState> triple = new Tuple<TState, TAction, TState>(initial, action, final);
            _stepCosts.TryGetValue(triple, out stepCost);

            return stepCost;
        }
    }
}
