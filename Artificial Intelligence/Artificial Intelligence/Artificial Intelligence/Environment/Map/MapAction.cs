using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Environment.Map
{
    /// <summary>
    /// A map agents's actions through actuators on an environment. 
    /// </summary>
    /// <typeparam name="TState">Any map state.</typeparam>
    public abstract class MapAction<TState> : Action
        where TState : IMapState
    {
        /// <summary>
        /// Specifies a map agent's memory of its environment.
        /// </summary>
        /// <param name="state">A map agent's memory of its environment.</param>
        public MapAction(TState state) : base("Go (" + state.NonNull().Name + ")")
        {
            State = state;
        }

        /// <summary>
        /// A map agent's memory of its environment.
        /// </summary>
        public virtual TState State { get; }
    }
}
