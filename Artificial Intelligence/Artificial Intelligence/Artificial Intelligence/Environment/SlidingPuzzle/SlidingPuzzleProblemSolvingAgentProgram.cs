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
    /// <typeparam name="TSlidingPuzzleState">Any SlidingPuzzleState.</typeparam>
    public class SlidingPuzzleProblemSolvingAgentProgram<TSlidingPuzzleState>
          : SimpleProblemSolvingAgentProgram<IPercept, SlidingPuzzleProblem<TSlidingPuzzleState>, TSlidingPuzzleState, SlidingPuzzleAction>
          where TSlidingPuzzleState : SlidingPuzzleState
    {
        /// <summary>
        /// A singular goal state.
        /// </summary>
        private TSlidingPuzzleState _goal;

        /// <summary>
        /// A functional interface for search.
        /// </summary>
        private readonly ISearch<SlidingPuzzleProblem<TSlidingPuzzleState>, TSlidingPuzzleState, SlidingPuzzleAction> _search;

        /// <summary>
        /// Specifies a singular goal state and a functional interface for search.
        /// </summary>
        /// <param name="goal">A singular goal state.</param>
        /// <param name="search">A functional interface for search.</param>
        public SlidingPuzzleProblemSolvingAgentProgram(TSlidingPuzzleState goal, ISearch<SlidingPuzzleProblem<TSlidingPuzzleState>, TSlidingPuzzleState, SlidingPuzzleAction> search)
            : base(SlidingPuzzleAction.NULL)
        {
            _goal = goal.NonNull();
            _search = search.NonNull();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public override TSlidingPuzzleState FormulateGoal(TSlidingPuzzleState state)
        {
            return _goal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="goal"></param>
        /// <returns></returns>
        public override SlidingPuzzleProblem<TSlidingPuzzleState> FormulateProblem(TSlidingPuzzleState state, TSlidingPuzzleState goal)
        {
            return new SlidingPuzzleProblem<TSlidingPuzzleState>(state,
                new SlidingPuzzleActionsFunction<TSlidingPuzzleState>(),
                new SlidingPuzzleResultFunction<TSlidingPuzzleState>(),
                new SlidingPuzzleGoalTestFunction<TSlidingPuzzleState>(goal));
        }

        /// <summary>
        /// Returns a sequence of actions that reaches the goal.
        /// </summary>
        /// <param name="problem">A problem.</param>
        /// <returns>A sequence of actions that reaches the goal.</returns>
        public override IList<SlidingPuzzleAction> Search(SlidingPuzzleProblem<TSlidingPuzzleState> problem)
        {
            return _search.Search(problem);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="percept"></param>
        /// <returns></returns>
        public override TSlidingPuzzleState UpdateState(TSlidingPuzzleState state, IPercept percept)
        {
            return state;
        }
    }
}
