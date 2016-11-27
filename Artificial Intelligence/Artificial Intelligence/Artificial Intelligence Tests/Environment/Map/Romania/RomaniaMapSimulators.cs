using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Chapter_3.Search;
using Artificial_Intelligence.Chapter_3.Search.Informed.Function;
using Artificial_Intelligence.Chapter_3.Search.QSearch;
using Artificial_Intelligence.Chapter_3.Search.Uninformed;
using Artificial_Intelligence.Collections;
using Artificial_Intelligence.Environment.Map;
using Artificial_Intelligence.Environment.Map.Romania;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Artificial_IntelligenceTests.Environment.Map.Romania
{
    [TestClass]
    public class RomaniaMapSimulators
    {
        /// <summary>
        /// Subject under test.
        /// </summary>
        private ISearch<MapProblem<RomaniaMapState, RomaniaMapAction>, RomaniaMapState, RomaniaMapAction> _sut;

        /// <summary>
        /// Parameter to subject under test.
        /// </summary>
        private MapProblem<RomaniaMapState, RomaniaMapAction> _problem;

        /// <summary>
        /// Return of subject under test.
        /// </summary>
        private IList<RomaniaMapAction> _actions;

        /// <summary>
        /// Returns a new tuple of initial, action, and final.
        /// </summary>
        /// <param name="initial">The initial state.</param>
        /// <param name="action">The taken action.</param>
        /// <param name="final">The final state.</param>
        /// <returns>A new tuple of initial, action, and final.</returns>
        private Tuple<RomaniaMapState, RomaniaMapAction, RomaniaMapState> CreateTriple(RomaniaMapState initial, RomaniaMapAction action, RomaniaMapState final)
        {
            return new Tuple<RomaniaMapState, RomaniaMapAction, RomaniaMapState>(initial, action, final);
        }

        /// <summary>
        /// Returns a new instance of Romania map problem.
        /// </summary>
        /// <param name="initialState">The initial state that the agent starts in.</param>
        /// <param name="goal">A singular goal state.</param>
        /// <returns>A new instance of Romania map problem.</returns>
        private MapProblem<RomaniaMapState, RomaniaMapAction> CreateProblem(RomaniaMapState initialState, RomaniaMapState goal)
        {
            IDictionary<RomaniaMapState, ISet<RomaniaMapAction>> actions = new Dictionary<RomaniaMapState, ISet<RomaniaMapAction>>()
            {
                [RomaniaMapState.ARAD] = new HashSet<RomaniaMapAction>()
                {
                    RomaniaMapAction.GO_SIBIU,
                    RomaniaMapAction.GO_TIMISOARA,
                    RomaniaMapAction.GO_ZERIND,
                },
                [RomaniaMapState.BUCHAREST] = new HashSet<RomaniaMapAction>()
                {
                    RomaniaMapAction.GO_FAGARAS,
                    RomaniaMapAction.GO_GIURGIU,
                    RomaniaMapAction.GO_PITESTI,
                    RomaniaMapAction.GO_URZICENI,
                },
                [RomaniaMapState.CRAIOVA] = new HashSet<RomaniaMapAction>()
                {
                    RomaniaMapAction.GO_DROBETA,
                    RomaniaMapAction.GO_PITESTI,
                    RomaniaMapAction.GO_RIMNICU_VILCEA,
                },
                [RomaniaMapState.DROBETA] = new HashSet<RomaniaMapAction>()
                {
                    RomaniaMapAction.GO_CRAIOVA,
                    RomaniaMapAction.GO_MEHADIA,
                },
                [RomaniaMapState.EFORIE] = new HashSet<RomaniaMapAction>()
                {
                    RomaniaMapAction.GO_HIRSOVA,
                },
                [RomaniaMapState.FAGARAS] = new HashSet<RomaniaMapAction>()
                {
                    RomaniaMapAction.GO_BUCHAREST,
                    RomaniaMapAction.GO_SIBIU,
                },
                [RomaniaMapState.GIURGIU] = new HashSet<RomaniaMapAction>()
                {
                    RomaniaMapAction.GO_BUCHAREST,
                },
                [RomaniaMapState.HIRSOVA] = new HashSet<RomaniaMapAction>()
                {
                    RomaniaMapAction.GO_EFORIE,
                    RomaniaMapAction.GO_URZICENI,
                },
                [RomaniaMapState.IASI] = new HashSet<RomaniaMapAction>()
                {
                    RomaniaMapAction.GO_NEAMT,
                    RomaniaMapAction.GO_VASLUI,
                },
                [RomaniaMapState.LUGOJ] = new HashSet<RomaniaMapAction>()
                {
                    RomaniaMapAction.GO_MEHADIA,
                    RomaniaMapAction.GO_TIMISOARA,
                },
                [RomaniaMapState.MEHADIA] = new HashSet<RomaniaMapAction>()
                {
                    RomaniaMapAction.GO_DROBETA,
                    RomaniaMapAction.GO_LUGOJ,
                },
                [RomaniaMapState.NEAMT] = new HashSet<RomaniaMapAction>()
                {
                    RomaniaMapAction.GO_IASI,
                },
                [RomaniaMapState.ORADEA] = new HashSet<RomaniaMapAction>()
                {
                    RomaniaMapAction.GO_SIBIU,
                    RomaniaMapAction.GO_ZERIND,
                },
                [RomaniaMapState.PITESTI] = new HashSet<RomaniaMapAction>()
                {
                    RomaniaMapAction.GO_BUCHAREST,
                    RomaniaMapAction.GO_CRAIOVA,
                    RomaniaMapAction.GO_RIMNICU_VILCEA,
                },
                [RomaniaMapState.RIMNICU_VILCEA] = new HashSet<RomaniaMapAction>()
                {
                    RomaniaMapAction.GO_CRAIOVA,
                    RomaniaMapAction.GO_PITESTI,
                    RomaniaMapAction.GO_SIBIU,
                },
                [RomaniaMapState.SIBIU] = new HashSet<RomaniaMapAction>()
                {
                    RomaniaMapAction.GO_ARAD,
                    RomaniaMapAction.GO_FAGARAS,
                    RomaniaMapAction.GO_ORADEA,
                    RomaniaMapAction.GO_RIMNICU_VILCEA,
                },
                [RomaniaMapState.TIMISOARA] = new HashSet<RomaniaMapAction>()
                {
                    RomaniaMapAction.GO_ARAD,
                    RomaniaMapAction.GO_LUGOJ,
                },
                [RomaniaMapState.URZICENI] = new HashSet<RomaniaMapAction>()
                {
                    RomaniaMapAction.GO_BUCHAREST,
                    RomaniaMapAction.GO_HIRSOVA,
                    RomaniaMapAction.GO_VASLUI,
                },
                [RomaniaMapState.VASLUI] = new HashSet<RomaniaMapAction>()
                {
                    RomaniaMapAction.GO_IASI,
                    RomaniaMapAction.GO_URZICENI,
                },
                [RomaniaMapState.ZERIND] = new HashSet<RomaniaMapAction>()
                {
                    RomaniaMapAction.GO_ARAD,
                    RomaniaMapAction.GO_ORADEA,
                },
            };
            IDictionary<Tuple<RomaniaMapState, RomaniaMapAction, RomaniaMapState>, double> stepCosts = new Dictionary<Tuple<RomaniaMapState, RomaniaMapAction, RomaniaMapState>, double>()
            {
                [CreateTriple(RomaniaMapState.ARAD, RomaniaMapAction.GO_SIBIU, RomaniaMapState.SIBIU)] = 140,
                [CreateTriple(RomaniaMapState.ARAD, RomaniaMapAction.GO_TIMISOARA, RomaniaMapState.TIMISOARA)] = 118,
                [CreateTriple(RomaniaMapState.ARAD, RomaniaMapAction.GO_ZERIND, RomaniaMapState.ZERIND)] = 75,
                [CreateTriple(RomaniaMapState.BUCHAREST, RomaniaMapAction.GO_FAGARAS, RomaniaMapState.FAGARAS)] = 211,
                [CreateTriple(RomaniaMapState.BUCHAREST, RomaniaMapAction.GO_GIURGIU, RomaniaMapState.GIURGIU)] = 90,
                [CreateTriple(RomaniaMapState.BUCHAREST, RomaniaMapAction.GO_PITESTI, RomaniaMapState.PITESTI)] = 101,
                [CreateTriple(RomaniaMapState.BUCHAREST, RomaniaMapAction.GO_URZICENI, RomaniaMapState.URZICENI)] = 85,
                [CreateTriple(RomaniaMapState.CRAIOVA, RomaniaMapAction.GO_DROBETA, RomaniaMapState.DROBETA)] = 120,
                [CreateTriple(RomaniaMapState.CRAIOVA, RomaniaMapAction.GO_PITESTI, RomaniaMapState.PITESTI)] = 138,
                [CreateTriple(RomaniaMapState.CRAIOVA, RomaniaMapAction.GO_RIMNICU_VILCEA, RomaniaMapState.RIMNICU_VILCEA)] = 146,
                [CreateTriple(RomaniaMapState.DROBETA, RomaniaMapAction.GO_CRAIOVA, RomaniaMapState.CRAIOVA)] = 120,
                [CreateTriple(RomaniaMapState.DROBETA, RomaniaMapAction.GO_MEHADIA, RomaniaMapState.MEHADIA)] = 75,
                [CreateTriple(RomaniaMapState.EFORIE, RomaniaMapAction.GO_HIRSOVA, RomaniaMapState.HIRSOVA)] = 86,
                [CreateTriple(RomaniaMapState.FAGARAS, RomaniaMapAction.GO_BUCHAREST, RomaniaMapState.BUCHAREST)] = 211,
                [CreateTriple(RomaniaMapState.FAGARAS, RomaniaMapAction.GO_SIBIU, RomaniaMapState.SIBIU)] = 99,
                [CreateTriple(RomaniaMapState.GIURGIU, RomaniaMapAction.GO_BUCHAREST, RomaniaMapState.BUCHAREST)] = 90,
                [CreateTriple(RomaniaMapState.HIRSOVA, RomaniaMapAction.GO_EFORIE, RomaniaMapState.EFORIE)] = 86,
                [CreateTriple(RomaniaMapState.HIRSOVA, RomaniaMapAction.GO_URZICENI, RomaniaMapState.URZICENI)] = 98,
                [CreateTriple(RomaniaMapState.IASI, RomaniaMapAction.GO_NEAMT, RomaniaMapState.NEAMT)] = 87,
                [CreateTriple(RomaniaMapState.IASI, RomaniaMapAction.GO_VASLUI, RomaniaMapState.VASLUI)] = 92,
                [CreateTriple(RomaniaMapState.LUGOJ, RomaniaMapAction.GO_MEHADIA, RomaniaMapState.MEHADIA)] = 70,
                [CreateTriple(RomaniaMapState.LUGOJ, RomaniaMapAction.GO_TIMISOARA, RomaniaMapState.TIMISOARA)] = 111,
                [CreateTriple(RomaniaMapState.MEHADIA, RomaniaMapAction.GO_DROBETA, RomaniaMapState.DROBETA)] = 75,
                [CreateTriple(RomaniaMapState.MEHADIA, RomaniaMapAction.GO_LUGOJ, RomaniaMapState.LUGOJ)] = 70,
                [CreateTriple(RomaniaMapState.NEAMT, RomaniaMapAction.GO_IASI, RomaniaMapState.IASI)] = 87,
                [CreateTriple(RomaniaMapState.ORADEA, RomaniaMapAction.GO_SIBIU, RomaniaMapState.SIBIU)] = 151,
                [CreateTriple(RomaniaMapState.ORADEA, RomaniaMapAction.GO_ZERIND, RomaniaMapState.ZERIND)] = 71,
                [CreateTriple(RomaniaMapState.PITESTI, RomaniaMapAction.GO_BUCHAREST, RomaniaMapState.BUCHAREST)] = 101,
                [CreateTriple(RomaniaMapState.PITESTI, RomaniaMapAction.GO_CRAIOVA, RomaniaMapState.CRAIOVA)] = 138,
                [CreateTriple(RomaniaMapState.PITESTI, RomaniaMapAction.GO_RIMNICU_VILCEA, RomaniaMapState.RIMNICU_VILCEA)] = 97,
                [CreateTriple(RomaniaMapState.RIMNICU_VILCEA, RomaniaMapAction.GO_CRAIOVA, RomaniaMapState.CRAIOVA)] = 146,
                [CreateTriple(RomaniaMapState.RIMNICU_VILCEA, RomaniaMapAction.GO_PITESTI, RomaniaMapState.PITESTI)] = 97,
                [CreateTriple(RomaniaMapState.RIMNICU_VILCEA, RomaniaMapAction.GO_SIBIU, RomaniaMapState.SIBIU)] = 80,
                [CreateTriple(RomaniaMapState.SIBIU, RomaniaMapAction.GO_ARAD, RomaniaMapState.ARAD)] = 140,
                [CreateTriple(RomaniaMapState.SIBIU, RomaniaMapAction.GO_FAGARAS, RomaniaMapState.FAGARAS)] = 99,
                [CreateTriple(RomaniaMapState.SIBIU, RomaniaMapAction.GO_ORADEA, RomaniaMapState.ORADEA)] = 151,
                [CreateTriple(RomaniaMapState.SIBIU, RomaniaMapAction.GO_RIMNICU_VILCEA, RomaniaMapState.RIMNICU_VILCEA)] = 80,
                [CreateTriple(RomaniaMapState.TIMISOARA, RomaniaMapAction.GO_ARAD, RomaniaMapState.ARAD)] = 118,
                [CreateTriple(RomaniaMapState.TIMISOARA, RomaniaMapAction.GO_LUGOJ, RomaniaMapState.LUGOJ)] = 111,
                [CreateTriple(RomaniaMapState.URZICENI, RomaniaMapAction.GO_BUCHAREST, RomaniaMapState.BUCHAREST)] = 85,
                [CreateTriple(RomaniaMapState.URZICENI, RomaniaMapAction.GO_HIRSOVA, RomaniaMapState.HIRSOVA)] = 98,
                [CreateTriple(RomaniaMapState.URZICENI, RomaniaMapAction.GO_VASLUI, RomaniaMapState.VASLUI)] = 142,
                [CreateTriple(RomaniaMapState.VASLUI, RomaniaMapAction.GO_IASI, RomaniaMapState.IASI)] = 92,
                [CreateTriple(RomaniaMapState.VASLUI, RomaniaMapAction.GO_URZICENI, RomaniaMapState.URZICENI)] = 142,
                [CreateTriple(RomaniaMapState.ZERIND, RomaniaMapAction.GO_ARAD, RomaniaMapState.ARAD)] = 75,
                [CreateTriple(RomaniaMapState.ZERIND, RomaniaMapAction.GO_ORADEA, RomaniaMapState.ORADEA)] = 71,
            };
            IActionsFunction<RomaniaMapState, RomaniaMapAction> actionsFunction =
                new MapActionsFunction<RomaniaMapState, RomaniaMapAction>(actions);
            IResultFunction<RomaniaMapState, RomaniaMapAction> resultFunction =
                new MapResultFunction<RomaniaMapState, RomaniaMapAction>();
            IGoalTestFunction<RomaniaMapState> goalTestFunction
                = new MapGoalTestFunction<RomaniaMapState>(goal);
            IStepCostFunction<RomaniaMapState, RomaniaMapAction> stepCostFunction =
                new MapStepCostFunction<RomaniaMapState, RomaniaMapAction>(stepCosts);
            return new MapProblem<RomaniaMapState, RomaniaMapAction>(initialState,
                actionsFunction,
                resultFunction,
                goalTestFunction,
                stepCostFunction);
        }

        /// <summary>
        /// Returns the last action's state in the list of actions.
        /// </summary>
        /// <param name="actions">The list of Romania map actions.</param>
        /// <returns>The last action's state in the list of actions.</returns>
        private RomaniaMapState Solve(IList<RomaniaMapAction> actions)
        {
            return actions[actions.Count - 1].State;
        }

        [TestMethod]
        public void BreadthFirstSearch()
        {
            // Arrange
            RomaniaMapState initialState = RomaniaMapState.ARAD;
            RomaniaMapState expected = RomaniaMapState.BUCHAREST;
            var queueSearch = new GraphSearch<IFIFOQueue<INode<RomaniaMapState, RomaniaMapAction>>, MapProblem<RomaniaMapState, RomaniaMapAction>, RomaniaMapState, RomaniaMapAction>();
            _sut = new BreadthFirstSearch<MapProblem<RomaniaMapState, RomaniaMapAction>, RomaniaMapState, RomaniaMapAction>(queueSearch);
            _problem = CreateProblem(initialState, expected);

            // Act
            _actions = _sut.Search(_problem);
            RomaniaMapState actual = Solve(_actions);

            // Assert
            Assert.AreEqual(RomaniaMapState.BUCHAREST, actual);
        }

        [TestMethod]
        public void UniformCostSearch()
        {
            // Arrange
            RomaniaMapState initialState = RomaniaMapState.SIBIU;
            RomaniaMapState expected = RomaniaMapState.BUCHAREST;
            var queueSearch = new PriorityQueueSearch<IPriorityQueue<INode<RomaniaMapState, RomaniaMapAction>>, MapProblem<RomaniaMapState, RomaniaMapAction>, RomaniaMapState, RomaniaMapAction>();
            _sut = new UniformCostSearch<MapProblem<RomaniaMapState, RomaniaMapAction>, RomaniaMapState, RomaniaMapAction>(queueSearch);
            _problem = CreateProblem(initialState, expected);

            // Act
            _actions = _sut.Search(_problem);
            RomaniaMapState actual = Solve(_actions);

            // Assert
            Assert.AreEqual(RomaniaMapState.BUCHAREST, actual);
        }
    }
}
