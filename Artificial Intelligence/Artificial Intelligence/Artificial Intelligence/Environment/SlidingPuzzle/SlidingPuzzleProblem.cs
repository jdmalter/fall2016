using Artificial_Intelligence.Chapter_3.Problem;

namespace Artificial_Intelligence.Environment.SlidingPuzzle
{
    /// <summary>
    /// An sliding puzzle problem can be defined by five components:
    /// initial state, actions, transition model, goal test, and path cost.
    /// </summary>
    public class SlidingPuzzleProblem : Problem<ISlidingPuzzleState, SlidingPuzzleAction>,
        IBidirectionalProblem<ISlidingPuzzleState, SlidingPuzzleAction>
    {
        /// <summary>
        /// Specifies initial state, actions, transition model, and goal.
        /// </summary>s
        /// <param name="initialState">The initial state that the agent starts in.</param>
        /// <param name="actionsFunction">A functional interface for Actions.</param>
        /// <param name="resultFunction">A functional interface for Result.</param>
        /// <param name="goalState">The singular goal state and initial state of the reverse problem.</param>
        public SlidingPuzzleProblem(ISlidingPuzzleState initialState,
            IActionsFunction<ISlidingPuzzleState, SlidingPuzzleAction> actionsFunction,
            IResultFunction<ISlidingPuzzleState, SlidingPuzzleAction> resultFunction,
            ISlidingPuzzleState goalState)
            : base(initialState,
                  actionsFunction,
                  resultFunction,
                  new SlidingPuzzleGoalTestFunction(goalState),
                  ConstantStepCostFunction<ISlidingPuzzleState, SlidingPuzzleAction>.ONE)
        {
            GoalState = goalState;
            Reverse = new SlidingPuzzleProblem(this);
        }

        /// <summary>
        /// Specifies a reverse problem.     
        /// </summary>
        /// <param name="reverse">A problem whose initial state and goal state are reverse of the original problem.</param>
        private SlidingPuzzleProblem(SlidingPuzzleProblem reverse)
            : base(reverse.GoalState,
                  reverse.ActionsFunction,
                  reverse.ResultFunction,
                  new SlidingPuzzleGoalTestFunction(reverse.InitialState),
                  reverse.StepCostFunction)
        {
            GoalState = reverse.InitialState;
            Reverse = reverse;
        }

        /// <summary>
        /// The singular goal state and initial state of the reverse problem.
        /// </summary>
        public ISlidingPuzzleState GoalState { get; }

        /// <summary>
        /// A problem whose initial state and goal state are reverse of the original problem.
        /// </summary>
        public IBidirectionalProblem<ISlidingPuzzleState, SlidingPuzzleAction> Reverse { get; }
    }
}
