using System;
using System.Collections.Generic;
using Artificial_Intelligence.Chapter_3.Problem;

namespace Artificial_Intelligence.Environment.Map
{
    /// <summary>
    /// A map step cost function that returns the step cost mapped by
    /// the initial state, the taken action, and the final state.
    /// </summary>
    /// <typeparam name="TState">Any map state.</typeparam>
    /// <typeparam name="TAction">Any map action of TState.</typeparam>
    public class MapStepCostFunction<TState, TAction> : StepCostFunction<TState, TAction>
        where TState : IMapState
        where TAction : MapAction<TState>
    {
        /// <summary>
        /// Specifies a mapping of the initial state, the taken action, and the final state to step cost.
        /// </summary>
        /// <param name="stepCosts">A mapping of the initial state, the taken action, and the final state to step cost.</param>
        public MapStepCostFunction(IDictionary<Tuple<TState, TAction, TState>, double> stepCosts)
            : base(stepCosts)
        {

        }
    }
}
