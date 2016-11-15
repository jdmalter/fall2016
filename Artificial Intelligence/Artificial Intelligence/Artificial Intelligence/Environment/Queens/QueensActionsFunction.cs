using System.Collections.Generic;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Environment.Queens
{
    /// <summary>
    /// A queens actions function that returns ADD.
    /// </summary>
    public class QueensActionsFunction : IActionsFunction<QueensState, QueensAction>
    {
        /// <summary>
        /// Returns the set of actions that can be executed in the given state.
        /// </summary>
        /// <param name="state">A particular agent state.</param>
        /// <returns>The set of actions that can be executed in the given state.</returns>
        public ISet<QueensAction> Actions(QueensState state)
        {
            state.NonNull();
            ISet<QueensAction> actions = new HashSet<QueensAction>();

            uint queens = 0;
            for (uint x = 0; x < state.Length; x++)
            {
                for (uint y = 0; y < state.Length; y++)
                {
                    if (state[x, y])
                    {
                        queens++;
                    }
                }
            }

            for (uint y = 0; y < state.Length; y++)
            {
                actions.Add(state[queens, y] ? QueensAction.Remove(queens, y) : QueensAction.Add(queens, y));
            }

            return actions;
        }
    }
}
