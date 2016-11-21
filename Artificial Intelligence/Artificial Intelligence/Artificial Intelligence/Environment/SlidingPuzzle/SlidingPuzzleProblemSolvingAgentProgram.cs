using System.Collections.Generic;
using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Chapter_3.Search;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Environment.SlidingPuzzle
{
    /// <summary>
    /// An sliding puzzle problem solving agent program that implements the agent function.
    /// </summary>
    public class SlidingPuzzleProblemSolvingAgentProgram
          : SimpleProblemSolvingAgentProgram<IPercept, SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction>
    {
        /// <summary>
        /// A singular goal state.
        /// </summary>
        private ISlidingPuzzleState _goal;

        /// <summary>
        /// A functional interface for search.
        /// </summary>
        private readonly ISearch<SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction> _search;

        /// <summary>
        /// Specifies the agent's current conception of the world state,
        /// a singular goal state, and a functional interface for search.
        /// </summary>
        /// <param name="state">The agent's current conception of the world state.</param>
        /// <param name="goal">A singular goal state.</param>
        /// <param name="search">A functional interface for search.</param>
        public SlidingPuzzleProblemSolvingAgentProgram(ISlidingPuzzleState state,
            ISlidingPuzzleState goal,
            ISearch<SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction> search)
            : base(state, SlidingPuzzleAction.NULL)
        {
            _goal = goal.NonNull();
            _search = search.NonNull();
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
                new SlidingPuzzleGoalTestFunction(goal));
        }

        /// <summary>
        /// Returns a sequence of actions that reaches the goal.
        /// </summary>
        /// <param name="problem">A problem.</param>
        /// <returns>A sequence of actions that reaches the goal.</returns>
        public override IList<SlidingPuzzleAction> Search(SlidingPuzzleProblem problem)
        {
            return _search.Search(problem);
        }

        /// <summary>
        /// Some implementations ignore any percepts.
        /// Returns the agent's updated conception of the world state.
        /// </summary>
        /// <param name="state">The agent's current conception of the world state.</param>
        /// <param name="percept">An agent's input at any given instant.</param>
        /// <returns>The agent's updated conception of the world state.</returns>
        public override ISlidingPuzzleState UpdateState(ISlidingPuzzleState state, IPercept percept)
        {
            return state;
        }
    }
}
