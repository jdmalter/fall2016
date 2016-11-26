using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Chapter_3.Search;

namespace Artificial_Intelligence.Environment.Queens
{
    /// <summary>
    /// A queens problem solving agent program that searches for actions and ignores percepts.
    /// </summary>
    public class QueensProblemSolvingAgentProgram
        : SearchProblemSolvingAgentProgram<QueensProblem, IQueensState, QueensAction>
    {
        /// <summary>
        /// Specifies the agent's current conception of the world state and
        /// a functional interface for search.
        /// </summary>
        /// <param name="state">The agent's current conception of the world state.</param>
        /// <param name="search">A functional interface for search.</param>
        public QueensProblemSolvingAgentProgram(IQueensState state,
            ISearch<QueensProblem, IQueensState, QueensAction> search)
            : base(state, QueensAction.NULL, search)
        {

        }

        /// <summary>
        /// Returns a possible goal state.
        /// </summary>
        /// <param name="state">The agent's current conception of the world state.</param>
        /// <returns>A possible goal state.</returns>
        public override IQueensState FormulateGoal(IQueensState state)
        {
            return null; // It is okay to return null since goal is not used in FormulateProblem
        }

        /// <summary>
        /// Specifies an initial state and a goal state. Returns a new problem.
        /// </summary>
        /// <param name="state">The agent's current conception of the world state.</param>
        /// <param name="goal">A possible goal state.</param>
        /// <returns>A new problem.</returns>
        public override QueensProblem FormulateProblem(IQueensState state, IQueensState goal)
        {
            return new QueensProblem(state,
                new QueensActionsFunction(),
                new QueensResultFunction(),
                new QueensGoalTestFunction());
        }
    }
}
