using System.Collections.Generic;
using Artificial_Intelligence.Chapter_3.Problem;

namespace Artificial_Intelligence.Environment.Map
{
    /// <summary>
    /// An map actions function that returns a set of actions that is mapped to by the given state.
    /// </summary>
    /// <typeparam name="TState">Any map state.</typeparam>
    /// <typeparam name="TAction">Any map action of TState.</typeparam>
    public class MapActionsFunction<TState, TAction> : ActionsFunction<TState, TAction>
        where TState : IMapState
        where TAction : MapAction<TState>
    {
        /// <summary>
        /// Specifies a mapping of states to a set of actions that can be executed.
        /// </summary>
        /// <param name="actions">A mapping of states to a set of actions that can be executed.</param>
        public MapActionsFunction(IDictionary<TState, ISet<TAction>> actions)
            : base(actions)
        {

        }
    }
}
