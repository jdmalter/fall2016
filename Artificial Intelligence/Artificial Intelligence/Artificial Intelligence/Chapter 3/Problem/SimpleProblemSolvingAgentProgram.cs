using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.List;
using System.Collections.Generic;

namespace Artificial_Intelligence.Chapter_3.Problem
{
    /// <summary>
    /// A problem solving agent program that implements the agent function.
    /// </summary>
    /// <typeparam name="TPercept">Any percept.</typeparam>
    /// <typeparam name="TGoal">Any goal.</typeparam>
    /// <typeparam name="TProblem">Any problem of TAgentState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public abstract class SimpleProblemSolvingAgentProgram<TPercept, TGoal, TProblem, TState, TAction> : IAgentProgram<TPercept, TAction>
        where TPercept : IPercept
        where TProblem : IProblem<TState, TAction>
        where TState : IState
        where TAction : IAction
    {
        /// <summary>
        /// An action sequence, initially empty.
        /// </summary>
        private IList<TAction> _actions = IList.Empty<TAction>();

        /// <summary>
        /// The agent's current conception of the world state.
        /// </summary>
        private TState _state;

        /// <summary>
        /// Maps percepts to actions.
        /// </summary>
        /// <param name="percept">New percept.</param>
        /// <returns>An action.</returns>
        public TAction Invoke(TPercept percept)
        {
            _state = UpdateState(_state, percept);
            if (_actions.IsEmpty())
            {
                TGoal goal = FormulateGoal(_state);
                TProblem problem = FormulateProblem(_state, goal);
                _actions = Search(problem);
                if (_actions.IsEmpty())
                {
                    return default(TAction);
                }
            }
            TAction action = _actions.First();
            _actions.Rest();
            return action;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="percept"></param>
        /// <returns></returns>
        public abstract TState UpdateState(TState state, TPercept percept);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public abstract TGoal FormulateGoal(TState state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="goal"></param>
        /// <returns></returns>
        public abstract TProblem FormulateProblem(TState state, TGoal goal);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="problem"></param>
        /// <returns></returns>
        public abstract IList<TAction> Search(TProblem problem);
    }
}
