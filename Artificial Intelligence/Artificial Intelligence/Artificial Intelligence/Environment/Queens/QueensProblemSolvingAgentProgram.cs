using System.Collections.Generic;
using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Chapter_3.Search;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Environment.Queens
{
    /// <summary>
    /// A queens problem solving agent program that implements the agent function.
    /// </summary>
    public class QueensProblemSolvingAgentProgram
        : SimpleProblemSolvingAgentProgram<IPercept, QueensProblem, IQueensState, QueensAction>
    {
        /// <summary>
        /// A functional interface for search.
        /// </summary>
        private readonly ISearch<QueensProblem, IQueensState, QueensAction> _search;

        /// <summary>
        /// Specifies the agent's current conception of the world state and
        /// a functional interface for search.
        /// </summary>
        /// <param name="state">The agent's current conception of the world state.</param>
        /// <param name="search">A functional interface for search.</param>
        public QueensProblemSolvingAgentProgram(IQueensState state,
            ISearch<QueensProblem, IQueensState, QueensAction> search)
            : base(state, QueensAction.NULL)
        {
            _search = search.NonNull();
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

        /// <summary>
        /// Returns a sequence of actions that reaches the goal.
        /// </summary>
        /// <param name="problem">A problem.</param>
        /// <returns>A sequence of actions that reaches the goal.</returns>
        public override IList<QueensAction> Search(QueensProblem problem)
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
        public override IQueensState UpdateState(IQueensState state, IPercept percept)
        {
            return state;
        }
    }
}
