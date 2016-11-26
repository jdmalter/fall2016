using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Chapter_3.Search;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Environment.Map
{
    /// <summary>
    /// A map problem solving agent program that searches for actions and ignores percepts.
    /// </summary>
    /// <typeparam name="TState">Any map state.</typeparam>
    /// <typeparam name="TAction">Any map action of TState.</typeparam>
    public class MapProblemSolvingAgentProgram<TState, TAction>
        : SearchProblemSolvingAgentProgram<MapProblem<TState, TAction>, TState, TAction>
        where TState : IMapState
        where TAction : MapAction<TState>
    {
        /// <summary>
        /// A singular goal state.
        /// </summary>
        private TState _goal;

        /// <summary>
        /// Specifies the agent's current conception of the world state,
        /// a functional interface for search, and a singular goal state.
        /// </summary>
        /// <param name="state">The agent's current conception of the world state.</param>
        /// <param name="search">A functional interface for search.</param>
        /// <param name="goal">A singular goal state.</param>
        public MapProblemSolvingAgentProgram(TState state,
            ISearch<MapProblem<TState, TAction>, TState, TAction> search,
            TState goal)
            : base(state, null, search)
        {
            _goal = goal.NonNull();
        }

        /// <summary>
        /// Returns a possible goal state.
        /// </summary>
        /// <param name="state">The agent's current conception of the world state.</param>
        /// <returns>A possible goal state.</returns>
        public override TState FormulateGoal(TState state)
        {
            return _goal;
        }

        /// <summary>
        /// Specifies an initial state and a goal state. Returns a new problem.
        /// </summary>
        /// <param name="state">The agent's current conception of the world state.</param>
        /// <param name="goal">A possible goal state.</param>
        /// <returns>A new problem.</returns>
        public override MapProblem<TState, TAction> FormulateProblem(TState state, TState goal)
        {
            return new MapProblem<TState, TAction>(state,
                new MapActionsFunction<TState, TAction>(null),
                new MapResultFunction<TState, TAction>(),
                new MapGoalTestFunction<TState>(goal),
                new MapStepCostFunction<TState, TAction>(null));
        }
    }
}
