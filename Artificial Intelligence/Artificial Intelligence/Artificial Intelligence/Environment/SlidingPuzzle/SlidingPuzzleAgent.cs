using Artificial_Intelligence.Chapter_2.Agent;

namespace Artificial_Intelligence.Environment.SlidingPuzzle
{
    /// <summary>
    /// An sliding puzzle agent interacts with a sliding puzzle environment.
    /// </summary>
    public class SlidingPuzzleAgent : Agent<IPercept, SlidingPuzzleAction>
    {
        /// <summary>
        /// Specifies an agent program.
        /// </summary>
        /// <param name="agentProgram">An agent program.</param>
        public SlidingPuzzleAgent(IAgentProgram<IPercept, SlidingPuzzleAction> agentProgram) : base(agentProgram)
        {

        }
    }
}
