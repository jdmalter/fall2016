using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Chapter_3.Search;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Environment.SlidingPuzzle
{
    /// <summary>
    /// An sliding puzzle problem solving agent program that searches for actions and ignores percepts.
    /// </summary>
    public class SlidingPuzzleProblemSolvingAgentProgram
          : SearchProblemSolvingAgentProgram<SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction>
    {
        /// <summary>
        /// A singular goal state.
        /// </summary>
        private ISlidingPuzzleState _goal;

        /// <summary>
        /// Specifies the agent's current conception of the world state,
        /// a functional interface for search, and a singular goal state.
        /// </summary>
        /// <param name="state">The agent's current conception of the world state.</param>
        /// <param name="search">A functional interface for search.</param>
        /// <param name="goal">A singular goal state.</param>
        public SlidingPuzzleProblemSolvingAgentProgram(ISlidingPuzzleState state,
            ISearch<SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction> search,
            ISlidingPuzzleState goal)
            : base(state, SlidingPuzzleAction.NULL, search)
        {
            _goal = goal.NonNull();
        }

        /// <summary>
        /// Returns a possible goal state.
        /// </summary>
        /// <param name="state">The agent's current conception of the world state.</param>
        /// <returns>A possible goal state.</returns>
        public override ISlidingPuzzleState FormulateGoal(ISlidingPuzzleState state)
        {
            return _goal;
        }

        /// <summary>
        /// Specifies an initial state and a goal state. Returns a new problem.
        /// </summary>
        /// <param name="state">The agent's current conception of the world state.</param>
        /// <param name="goal">A possible goal state.</param>
        /// <returns>A new problem.</returns>
        public override SlidingPuzzleProblem FormulateProblem(ISlidingPuzzleState state, ISlidingPuzzleState goal)
        {
            return new SlidingPuzzleProblem(state,
                new SlidingPuzzleActionsFunction(),
                new SlidingPuzzleResultFunction(),
                goal);
        }
    }
}
