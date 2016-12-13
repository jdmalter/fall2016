using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Chapter_3.Search;
using Artificial_Intelligence.Chapter_3.Search.QSearch;
using Artificial_Intelligence.Chapter_3.Search.Uninformed;
using Artificial_Intelligence.Environment.Queens;
using Artificial_Intelligence.Environment.Queens.EightQueens;
using Artificial_Intelligence.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Artificial_IntelligenceTests.Environment.Queens
{
    [TestClass]
    public class QueensSimulators
    {
        /// <summary>
        /// Subject under test.
        /// </summary>
        private ISearch<QueensProblem, IQueensState, QueensAction> _sut;

        /// <summary>
        /// Parameter to subject under test.
        /// </summary>
        private QueensProblem _problem;

        /// <summary>
        /// Return of subject under test.
        /// </summary>
        private IList<QueensAction> _actions;

        /// <summary>
        /// Returns a new instance of queens problem.
        /// </summary>
        /// <param name="initialState">An initial state.</param>
        /// <returns>A new instance of queens problem.</returns>
        private QueensProblem CreateProblem(IQueensState initialState)
        {
            IActionsFunction<IQueensState, QueensAction> actionsFunction = new QueensReducedActionsFunction();
            IResultFunction<IQueensState, QueensAction> resultFunction = new QueensResultFunction();
            IGoalTestFunction<IQueensState> goalTestFunction = new QueensGoalTestFunction();
            return new QueensProblem(
                 initialState,
                 actionsFunction,
                 resultFunction,
                 goalTestFunction);
        }

        [TestMethod]
        public void BreadthFirstTreeSearch()
        {
            // Arrange
            var queueSearch = new TreeSearch<IFIFOQueue<INode<IQueensState, QueensAction>>, QueensProblem, IQueensState, QueensAction>();
            _sut = new BreadthFirstSearch<QueensProblem, IQueensState, QueensAction>(queueSearch);
            _problem = CreateProblem(new EightQueensState());

            // Act
            _actions = _sut.Search(_problem);

            // Assert
            Assert.AreEqual((int)_problem.InitialState.Length, _actions.Count); // Much slower than DFS, faster than graph version
        }

        [TestMethod]
        public void DepthFirstTreeSearch()
        {
            // Arrange
            var queueSearch = new TreeSearch<ILIFOQueue<INode<IQueensState, QueensAction>>, QueensProblem, IQueensState, QueensAction>();
            _sut = new DepthFirstSearch<QueensProblem, IQueensState, QueensAction>(queueSearch);
            _problem = CreateProblem(new EightQueensState());

            // Act
            _actions = _sut.Search(_problem);

            // Assert
            Assert.AreEqual((int)_problem.InitialState.Length, _actions.Count); // Much faster than BFS, faster than graph version
        }

        [TestMethod]
        public void BreadthFirstGraphSearch()
        {
            // Arrange
            var queueSearch = new GraphSearch<IFIFOQueue<INode<IQueensState, QueensAction>>, QueensProblem, IQueensState, QueensAction>();
            _sut = new BreadthFirstSearch<QueensProblem, IQueensState, QueensAction>(queueSearch);
            _problem = CreateProblem(new EightQueensState());

            // Act
            _actions = _sut.Search(_problem);

            // Assert
            Assert.AreEqual((int)_problem.InitialState.Length, _actions.Count); // Much slower than DFS, slower than tree version
        }

        [TestMethod]
        public void DepthFirstGraphSearch()
        {
            // Arrange
            var queueSearch = new GraphSearch<ILIFOQueue<INode<IQueensState, QueensAction>>, QueensProblem, IQueensState, QueensAction>();
            _sut = new DepthFirstSearch<QueensProblem, IQueensState, QueensAction>(queueSearch);
            _problem = CreateProblem(new EightQueensState());

            // Act
            _actions = _sut.Search(_problem);

            // Assert
            Assert.AreEqual((int)_problem.InitialState.Length, _actions.Count); // Much faster than BFS, slower than tree version
        }
    }
}
