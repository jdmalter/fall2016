using System.Collections.Generic;
using Artificial_Intelligence.Chapter_2.Agent;

namespace Artificial_Intelligence.Environment.VacuumWorld
{
    /// <summary>
    /// A table driven agent for vacuum world.
    /// </summary>
    public class TableDrivenVacuumAgentProgram : TableDrivenAgentProgram<VacuumPercept, VacuumAction>
    {
        /// <summary>
        /// Specifies the table of vacuum actions.
        /// </summary>
        /// <param name="table">The table of vacuum actions.</param>
        /// <param name="action">An alternative vacuum action if table does not contain a percept sequence.</param>
        public TableDrivenVacuumAgentProgram(IDictionary<IList<VacuumPercept>, VacuumAction> table, VacuumAction action) : base(table, action)
        {

        }
    }
}
