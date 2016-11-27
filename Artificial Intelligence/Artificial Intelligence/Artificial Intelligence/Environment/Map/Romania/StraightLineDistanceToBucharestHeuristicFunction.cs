using System;
using Artificial_Intelligence.Chapter_3.Search.Informed.Function;
using System.Collections.Generic;

namespace Artificial_Intelligence.Environment.Map.Romania
{
    /// <summary>
    /// Computes Heuristic from the straight line distance to Bucharest.
    /// </summary>
    public class StraightLineDistanceToBucharestHeuristicFunction : IHeuristicFunction<RomaniaMapState>
    {
        /// <summary>
        /// A mapping of states to straight line distances.
        /// </summary>
        private readonly IDictionary<RomaniaMapState, double> _distances = new Dictionary<RomaniaMapState, double>()
        {
            [RomaniaMapState.ARAD] = 366,
            [RomaniaMapState.BUCHAREST] = 0,
            [RomaniaMapState.CRAIOVA] = 160,
            [RomaniaMapState.DROBETA] = 242,
            [RomaniaMapState.EFORIE] = 161,
            [RomaniaMapState.FAGARAS] = 176,
            [RomaniaMapState.GIURGIU] = 77,
            [RomaniaMapState.HIRSOVA] = 151,
            [RomaniaMapState.IASI] = 226,
            [RomaniaMapState.LUGOJ] = 244,
            [RomaniaMapState.MEHADIA] = 241,
            [RomaniaMapState.NEAMT] = 234,
            [RomaniaMapState.ORADEA] = 380,
            [RomaniaMapState.PITESTI] = 100,
            [RomaniaMapState.RIMNICU_VILCEA] = 193,
            [RomaniaMapState.SIBIU] = 253,
            [RomaniaMapState.TIMISOARA] = 329,
            [RomaniaMapState.URZICENI] = 80,
            [RomaniaMapState.VASLUI] = 199,
            [RomaniaMapState.ZERIND] = 374,
        };

        /// <summary>
        /// Returns the estimated cost of the cheapest path fromthe given state to the goal state.
        /// </summary>
        /// <param name="state">A state.</param>
        /// <returns>The estimated cost of the cheapest path from
        /// the given state to the goal state.</returns>
        public double Heuristic(RomaniaMapState state)
        {
            double value = double.MaxValue; // if state is not in distances, estimate conservatively

            _distances.TryGetValue(state, out value);

            return value;
        }
    }
}
