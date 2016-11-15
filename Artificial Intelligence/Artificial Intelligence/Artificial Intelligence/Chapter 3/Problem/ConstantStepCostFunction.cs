using Artificial_Intelligence.Chapter_2.Agent;

namespace Artificial_Intelligence.Chapter_3.Problem
{
    /// <summary>
    /// A step cost function that returns a constant cost of taking any given action in any given state.
    /// </summary>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public class ConstantStepCostFunction<TState, TAction> : IStepCostFunction<TState, TAction>
        where TState : IState
        where TAction : IAction
    {
        public static readonly ConstantStepCostFunction<TState, TAction> ZERO =
            new ConstantStepCostFunction<TState, TAction>(0);
        public static readonly ConstantStepCostFunction<TState, TAction> ONE =
            new ConstantStepCostFunction<TState, TAction>(1);

        /// <summary>
        /// The constant cost of taking any given action in any given state.
        /// </summary>
        private readonly double _cost;

        /// <summary>
        /// Specifies the constant cost of taking any given action in any given state.
        /// </summary>
        /// <param name="cost">The constant cost of taking any given action in any given state.</param>
        public ConstantStepCostFunction(double cost)
        {
            _cost = cost;
        }

        /// <summary>
        /// Returns the constant cost of taking any given action in any given state.
        /// </summary>
        /// <param name="initial">Irrelevant.</param>
        /// <param name="action">Irrelevant.</param>
        /// <param name="final">Irrelevant.</param>
        /// <returns>The constant cost of taking any given action in any given state.</returns>
        public double StepCost(TState initial, TAction action, TState final)
        {
            return _cost;
        }
    }
}
