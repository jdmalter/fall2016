using System.Collections.Generic;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Environment.Queens
{
    /// <summary>
    /// A queens actions function that returns ADD.
    /// </summary>
    public class QueensActionsFunction : IActionsFunction<IQueensState, QueensAction>
    {
        /// <summary>
        /// Returns the set of actions that can be executed in the given state.
        /// </summary>
        /// <param name="state">A particular agent state.</param>
        /// <returns>The set of actions that can be executed in the given state.</returns>
        public ISet<QueensAction> Actions(IQueensState state)
        {
            state.NonNull();
            ISet<QueensAction> actions = new HashSet<QueensAction>();

            for (uint x = 0; x < state.Length; x++)
            {
                for (uint y = 0; y < state.Length; y++)
                {
                    if (!state[x, y])
                    {
                        actions.Add(QueensAction.Add(x, y));
                    }
                }
            }

            return actions;
        }
    }
}
