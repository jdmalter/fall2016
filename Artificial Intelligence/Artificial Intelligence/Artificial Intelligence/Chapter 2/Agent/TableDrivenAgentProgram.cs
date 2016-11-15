using Artificial_Intelligence.Guard;
using System.Collections.Generic;

namespace Artificial_Intelligence.Chapter_2.Agent
{
    /// <summary>
    /// The table driven agent program is invoked for each new percept and returns an action each time.
    /// It retains the complete percept sequence in memory.
    /// </summary>
    /// <typeparam name="TPercept">Any percept.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public abstract class TableDrivenAgentProgram<TPercept, TAction> : IAgentProgram<TPercept, TAction>
        where TPercept : IPercept
        where TAction : IAction
    {
        /// <summary>
        /// A percept sequence, initially empty
        /// </summary>
        private readonly IList<TPercept> _percepts = new List<TPercept>();

        /// <summary>
        /// A table of actions, indexed by percept sequences, initially fully specified
        /// </summary>
        private readonly IDictionary<IList<TPercept>, TAction> _table;

        /// <summary>
        /// An alternative action if table does not contain a percept sequence.
        /// </summary>
        private readonly TAction _action;

        /// <summary>
        /// Specifies the table of actions.
        /// </summary>
        /// <param name="table">The table of actions.</param>
        /// <param name="action">An alternative action if table does not contain a percept sequence.</param>
        public TableDrivenAgentProgram(IDictionary<IList<TPercept>, TAction> table, TAction action)
        {
            _table = table.NonNull();
            _action = action.NonNull();
        }

        /// <summary>
        /// Maps percepts to actions.
        /// </summary>
        /// <param name="percept">New percept.</param>
        /// <returns>An action.</returns>
        public TAction Invoke(TPercept percept)
        {
            _percepts.Insert(_percepts.Count, percept);
            TAction action = Lookup(_table, _percepts, _action);
            return action;
        }

        /// <summary>
        /// Finds appropriate action for every given percept sequence.
        /// If percept sequence is not specified, returns action.
        /// </summary>
        /// <param name="table">A table of actions, indexed by percept sequences.</param>
        /// <param name="percepts">A percept sequence.</param>
        /// <param name="action">An alternative action if table does not contain a percept sequence.</param>
        /// <returns>An action.</returns>
        private static TAction Lookup(IDictionary<IList<TPercept>, TAction> table, IList<TPercept> percepts, TAction action)
        {
            TAction value;
            return table.TryGetValue(percepts, out value) ? value : action;
        }
    }
}
