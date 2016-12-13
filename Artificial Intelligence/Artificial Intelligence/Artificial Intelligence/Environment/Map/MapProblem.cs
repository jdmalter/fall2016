using Artificial_Intelligence.Chapter_3.Problem;

namespace Artificial_Intelligence.Environment.Map
{
    /// <summary>
    /// An map puzzle problem can be defined by five components:
    /// initial state, actions, transition model, goal test, and path cost.
    /// </summary>
    /// <typeparam name="TState">Any map state.</typeparam>
    /// <typeparam name="TAction">Any map action of TState.</typeparam>
    public class MapProblem<TState, TAction> : Problem<TState, TAction>,
        IBidirectionalProblem<TState, TAction>
        where TState : IMapState
        where TAction : MapAction<TState>
    {
        /// <summary>
        /// Specifies initial state, actions, transition model, goal, and path cost.
        /// </summary>
        /// <param name="initialState">The initial state that the agent starts in.</param>
        /// <param name="actionsFunction">A functional interface for Actions.</param>
        /// <param name="resultFunction">A functional interface for Result.</param>
        /// <param name="goalState">The singular goal state and initial state of the reverse problem.</param>
        /// <param name="stepCostFunction">A functional interface for StepCost.</param>
        public MapProblem(TState initialState,
            IActionsFunction<TState, TAction> actionsFunction,
            IResultFunction<TState, TAction> resultFunction,
            TState goalState,
            IStepCostFunction<TState, TAction> stepCostFunction)
            : base(initialState,
                  actionsFunction,
                  resultFunction,
                  new MapGoalTestFunction<TState>(goalState),
                  stepCostFunction)
        {
            GoalState = goalState;
            Reverse = new MapProblem<TState, TAction>(this);
        }

        /// <summary>
        /// Specifies a reverse problem.
        /// </summary>
        /// <param name="reverse">A problem whose initial state and goal state are reverse of the original problem.</param>
        private MapProblem(MapProblem<TState, TAction> reverse)
            : base(reverse.GoalState,
                  reverse.ActionsFunction,
                  reverse.ResultFunction,
                  new MapGoalTestFunction<TState>(reverse.InitialState),
                  reverse.StepCostFunction)
        {
            GoalState = reverse.InitialState;
            Reverse = reverse;
        }

        /// <summary>
        /// The singular goal state and initial state of the reverse problem.
        /// </summary>
        public TState GoalState { get; }

        /// <summary>
        /// A problem whose initial state and goal state are reverse of the original problem.
        /// </summary>
        public IBidirectionalProblem<TState, TAction> Reverse { get; }
    }
}
