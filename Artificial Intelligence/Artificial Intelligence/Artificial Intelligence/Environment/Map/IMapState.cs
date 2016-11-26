using Artificial_Intelligence.Chapter_2.Agent;

namespace Artificial_Intelligence.Environment.Map
{
    /// <summary>
    /// An agent's memory of its environment.
    /// </summary>
    public interface IMapState : IState
    {
        /// <summary>
        /// The string representation.
        /// </summary>
        string Name { get; }
    }
}
