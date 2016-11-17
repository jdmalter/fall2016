using Artificial_Intelligence.Chapter_2.Agent;

namespace Artificial_Intelligence.Environment.VacuumWorld
{
    /// <summary>
    /// A vacuum agents's actions through actuators on an environment. 
    /// </summary>
    public class VacuumAction : Action
    {
        public static readonly VacuumAction NULL = new VacuumAction("Null");
        public static readonly VacuumAction LEFT = new VacuumAction("Left");
        public static readonly VacuumAction RIGHT = new VacuumAction("Right");
        public static readonly VacuumAction SUCK = new VacuumAction("Suck");

        /// <summary>
        /// Specifies the string representation.
        /// </summary>
        /// <param name="name">The string representation.</param>
        private VacuumAction(string name) : base(name)
        {

        }
    }
}
