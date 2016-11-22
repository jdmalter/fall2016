using Microsoft.VisualStudio.TestTools.UnitTesting;
using Artificial_Intelligence.Chapter_3.Search;
using Artificial_Intelligence.Environment.SlidingPuzzle;
using Artificial_Intelligence.Chapter_3.Search.Uninformed;
using Artificial_Intelligence.Chapter_3.Search.QSearch;
using System.Collections.Generic;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Environment.SlidingPuzzle.EightPuzzle;
using Artificial_Intelligence.Chapter_3.Search.Uninformed.DepthLimitedSearch;
using Artificial_Intelligence.Chapter_3.Search.Informed;
using Artificial_Intelligence.Chapter_3.Search.Informed.Function;
using Artificial_Intelligence.List;

namespace Artificial_IntelligenceTests.Environment.SlidingPuzzle
{
    [TestClass]
    public class SlidingPuzzleSimulators
    {
        /// <summary>
        /// Subject under test.
        /// </summary>
        private ISearch<SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction> _sut;

        /// <summary>
        /// Dependency of subject under test.
        /// </summary>
        private IHeuristicFunction<ISlidingPuzzleState> _heuristicFunction;

        /// <summary>
        /// Parameter to subject under test.
        /// </summary>
        private SlidingPuzzleProblem _problem;

        /// <summary>
        /// Return of subject under test.
        /// </summary>
        private IList<SlidingPuzzleAction> _actions;

        /// <summary>
        /// Returns a new instance of sliding puzzle problem.
        /// </summary>
        /// <returns>A new instance of sliding puzzle problem.</returns>
        private SlidingPuzzleProblem CreateProblem()
        {
            uint[,] locations = new uint[,]
            {
                { 8, 7, 6, },
                { 4, 0, 1, },
                { 3, 2, 5, },
            };
            ISlidingPuzzleState initialState =
                new EightPuzzleState(locations);
            ISlidingPuzzleState goal =
                EightPuzzleState.DefaultGoalState;
            IActionsFunction<ISlidingPuzzleState, SlidingPuzzleAction> actionsFunction =
                new SlidingPuzzleActionsFunction();
            IResultFunction<ISlidingPuzzleState, SlidingPuzzleAction> resultFunction =
                new SlidingPuzzleResultFunction();
            IGoalTestFunction<ISlidingPuzzleState> goalTestFunction =
                new SlidingPuzzleGoalTestFunction(goal);
            return new SlidingPuzzleProblem(
                 initialState,
                 actionsFunction,
                 resultFunction,
                 goalTestFunction);
        }

        /// <summary>
        /// Returns a sliding puzzle with the given actions applied to the given sliding puzzle.
        /// </summary>
        /// <param name="state">An initial state.</param>
        /// <param name="actions">A list of sliding puzzle actions.</param>
        /// <returns>A sliding puzzle with the given actions applied to the given sliding puzzle.</returns>
        private ISlidingPuzzleState Solve(ISlidingPuzzleState state, IList<SlidingPuzzleAction> actions)
        {
            foreach (SlidingPuzzleAction action in actions)
            {
                if (SlidingPuzzleAction.UP.Equals(action))
                {
                    state = state.MoveBlankSpaceUp();
                }
                else if (SlidingPuzzleAction.DOWN.Equals(action))
                {
                    state = state.MoveBlankSpaceDown();
                }
                else if (SlidingPuzzleAction.LEFT.Equals(action))
                {
                    state = state.MoveBlankSpaceLeft();
                }
                else if (SlidingPuzzleAction.RIGHT.Equals(action))
                {
                    state = state.MoveBlankSpaceRight();
                }
            }

            return state;
        }

        [TestMethod]
        public void BreadthFirstSearch()
        {
            // Arrange
            var queueSearch = new GraphSearch<IFIFOQueue<INode<ISlidingPuzzleState, SlidingPuzzleAction>>, SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction>();
            _sut = new BreadthFirstSearch<SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction>(queueSearch);
            _problem = CreateProblem();

            // Act
            _actions = _sut.Search(_problem);

            // Assert
            ISlidingPuzzleState state = Solve(_problem.InitialState, _actions);
            Assert.AreEqual(EightPuzzleState.DefaultGoalState, state);
        }

        [TestMethod]
        public void DepthFirstSearch()
        {
            // Arrange
            var queueSearch = new GraphSearch<ILIFOQueue<INode<ISlidingPuzzleState, SlidingPuzzleAction>>, SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction>();
            _sut = new DepthFirstSearch<SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction>(queueSearch);
            _problem = CreateProblem();

            // Act
            _actions = _sut.Search(_problem); // Faster than BFS, but less optimal

            // Assert
            ISlidingPuzzleState state = Solve(_problem.InitialState, _actions);
            Assert.AreEqual(EightPuzzleState.DefaultGoalState, state);
        }

        [TestMethod]
        public void DepthLimitedSearch()
        {
            // Arrange
            int limit = 40;
            _sut = new DepthLimitedGraphSearch<SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction>(limit);
            _problem = CreateProblem();

            // Act
            _actions = _sut.Search(_problem); // Faster than DFS, more optimal

            // Assert
            ISlidingPuzzleState state = Solve(_problem.InitialState, _actions);
            Assert.AreEqual(EightPuzzleState.DefaultGoalState, state);
        }

        [TestMethod]
        public void IterativeDeepeningSearch()
        {
            // Arrange
            int limit = 40;
            DepthLimitedSearch<SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction> depthLimitedSearch =
                new DepthLimitedGraphSearch<SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction>(0);
            _sut = new IterativeDeepeningSearch<SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction>(depthLimitedSearch, limit);
            _problem = CreateProblem();

            // Act
            _actions = _sut.Search(_problem); // Slower than DFS and DLS, but equally optimal to BFS

            // Assert
            ISlidingPuzzleState state = Solve(_problem.InitialState, _actions);
            Assert.AreEqual(EightPuzzleState.DefaultGoalState, state);
        }

        [TestMethod]
        public void UniformCostSearch()
        {
            // Arrange
            var priorityQueueSearch = new PriorityQueueSearch<IPriorityQueue<INode<ISlidingPuzzleState, SlidingPuzzleAction>>, SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction>();
            _sut = new UniformCostSearch<SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction>(priorityQueueSearch);
            _problem = CreateProblem();

            // Act
            _actions = _sut.Search(_problem);

            // Assert
            ISlidingPuzzleState state = Solve(_problem.InitialState, _actions);
            Assert.AreEqual(EightPuzzleState.DefaultGoalState, state);
        }

        [TestMethod]
        public void MisplacedTilesAStarSearch()
        {
            // Arrange
            var priorityQueueSearch = new PriorityQueueSearch<IPriorityQueue<INode<ISlidingPuzzleState, SlidingPuzzleAction>>, SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction>();
            _heuristicFunction = new SlidingPuzzleMisplacedTilesHeuristicFunction();
            _sut = new AStarSearch<SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction>(priorityQueueSearch, _heuristicFunction);
            _problem = CreateProblem();

            // Act
            _actions = _sut.Search(_problem);

            // Assert
            ISlidingPuzzleState state = Solve(_problem.InitialState, _actions);
            Assert.AreEqual(EightPuzzleState.DefaultGoalState, state);
        }

        [TestMethod]
        public void ManhattanAStarSearch()
        {
            // Arrange
            var priorityQueueSearch = new PriorityQueueSearch<IPriorityQueue<INode<ISlidingPuzzleState, SlidingPuzzleAction>>, SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction>();
            _heuristicFunction = new SlidingPuzzleManhattanHeuristicFunction();
            _sut = new AStarSearch<SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction>(priorityQueueSearch, _heuristicFunction);
            _problem = CreateProblem();

            // Act
            _actions = _sut.Search(_problem);

            // Assert
            ISlidingPuzzleState state = Solve(_problem.InitialState, _actions);
            Assert.AreEqual(EightPuzzleState.DefaultGoalState, state);
        }

        [TestMethod]
        public void DijkstraSearch()
        {
            // Arrange
            var priorityQueueSearch = new PriorityQueueSearch<IPriorityQueue<INode<ISlidingPuzzleState, SlidingPuzzleAction>>, SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction>();
            _sut = new DijkstraSearch<SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction>(priorityQueueSearch);
            _problem = CreateProblem();

            // Act
            _actions = _sut.Search(_problem);

            // Assert
            ISlidingPuzzleState state = Solve(_problem.InitialState, _actions);
            Assert.AreEqual(EightPuzzleState.DefaultGoalState, state);
        }

        [TestMethod]
        public void MisplacedTilesGreedyBestFirstSearch()
        {
            // Arrange
            var priorityQueueSearch = new PriorityQueueSearch<IPriorityQueue<INode<ISlidingPuzzleState, SlidingPuzzleAction>>, SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction>();
            _heuristicFunction = new SlidingPuzzleMisplacedTilesHeuristicFunction();
            _sut = new GreedyBestFirstSearch<SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction>(priorityQueueSearch, _heuristicFunction);
            _problem = CreateProblem();

            // Act
            _actions = _sut.Search(_problem);

            // Assert
            ISlidingPuzzleState state = Solve(_problem.InitialState, _actions);
            Assert.AreEqual(EightPuzzleState.DefaultGoalState, state);
        }

        [TestMethod]
        public void ManhattanGreedyBestFirstSearch()
        {
            // Arrange
            var priorityQueueSearch = new PriorityQueueSearch<IPriorityQueue<INode<ISlidingPuzzleState, SlidingPuzzleAction>>, SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction>();
            _heuristicFunction = new SlidingPuzzleManhattanHeuristicFunction();
            _sut = new GreedyBestFirstSearch<SlidingPuzzleProblem, ISlidingPuzzleState, SlidingPuzzleAction>(priorityQueueSearch, _heuristicFunction);
            _problem = CreateProblem();

            // Act
            _actions = _sut.Search(_problem);

            // Assert
            ISlidingPuzzleState state = Solve(_problem.InitialState, _actions);
            Assert.AreEqual(EightPuzzleState.DefaultGoalState, state);
        }
    }
}
