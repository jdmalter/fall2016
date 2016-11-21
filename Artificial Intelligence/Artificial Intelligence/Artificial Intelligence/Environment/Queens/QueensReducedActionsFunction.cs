using System.Collections.Generic;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Environment.Queens
{
    /// <summary>
    /// A queens actions function that returns ADD.
    /// </summary>
    public class QueensReducedActionsFunction : IActionsFunction<IQueensState, QueensAction>
    {
        /// <summary>
        /// Returns the set of actions that can be executed in the given state.
        /// </summary>
        /// <param name="state">A particular agent state.</param>
        /// <returns>The set of actions that can be executed in the given state.</returns>
        public ISet<QueensAction> Actions(IQueensState state)
        {
            state.NonNull();

            for (uint x = 0; x < state.Length; x++)
            {
                bool isEmpty = true;
                for (uint y = 0; y < state.Length && isEmpty; y++)
                {
                    isEmpty = !state[x, y];
                }
                if (isEmpty)
                {
                    ISet<QueensAction> actions = new HashSet<QueensAction>();

                    for (uint y = 0; y < state.Length; y++)
                    {
                        if (0 == state.AttacksOn(x, y))
                        {
                            actions.Add(QueensAction.Add(x, y));
                        }
                    }

                    return actions;
                }
            }

            return new HashSet<QueensAction>();
        }
    }
}
