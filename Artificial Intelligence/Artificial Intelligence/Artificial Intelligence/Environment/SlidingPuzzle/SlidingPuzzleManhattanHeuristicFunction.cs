using Artificial_Intelligence.Chapter_3.Search.Informed.Function;

namespace Artificial_Intelligence.Environment.SlidingPuzzle
{
    /// <summary>
    /// Computes Heuristic from the sum of the distances of the tiles from their goal positions.
    /// </summary>
    public class SlidingPuzzleManhattanHeuristicFunction : IHeuristicFunction<ISlidingPuzzleState>
    {
        /// <summary>
        /// Returns the estimated cost of the cheapest path fromthe given state to the goal state.
        /// </summary>
        /// <param name="state">A state.</param>
        /// <returns>The estimated cost of the cheapest path from
        /// the given state to the goal state.</returns>
        public double Heuristic(ISlidingPuzzleState state)
        {
            double manhattan = 0;

            for (uint x = 0; x < state.Length; x++)
            {
                for (uint y = 0; y < state.Length; y++)
                {
                    if (state[x, y] != 0)
                    {
                        uint valueX = state[x, y] / state.Length;
                        uint valueY = state[x, y] % state.Length;

                        manhattan += x > valueX ? x - valueX : valueX - x;
                        manhattan += y > valueY ? y - valueY : valueY - y;
                    }
                }
            }

            return manhattan;
        }
    }
}
