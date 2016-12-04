using System.Collections.Generic;
using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Chapter_3.Search.Informed.Function;
using Artificial_Intelligence.Collections;
using System;

namespace Artificial_Intelligence.Chapter_3.Search.Informed
{
    /// <summary>
    /// An informed iterative deepening search using an A* evaluation function.
    /// </summary>
    /// <typeparam name="TProblem">Any problem of TState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public class IterativeDeepeningAStarSearch<TProblem, TState, TAction> : ISearch<TProblem, TState, TAction>
        where TProblem : IProblem<TState, TAction>
        where TState : IState
        where TAction : IAction
    {
        /// <summary>
        /// A functional interface for Evaluate.
        /// </summary>
        private readonly IEvaluationFunction<TState, TAction> _evaluationFunction;

        /// <summary>
        /// A depth at which nodes have no successors.
        /// </summary>
        private readonly double _limit;

        /// <summary>
        /// An empty list which should not be returned by search.
        /// </summary>
        private static readonly IList<TAction> _empty = new List<TAction>();

        /// <summary>
        /// A tuple of an empty list which should not be returned by search and the max value of double.
        /// </summary>
        private static readonly Tuple<IList<TAction>, double> _max = new Tuple<IList<TAction>, double>(_empty, double.MaxValue);

        /// <summary>
        /// Specifies a heuristic function and a limit.
        /// </summary>
        /// <param name="heuristicFunction">A functional interface for Heuristic.</param>
        /// <param name="limit">A depth at which nodes have no successors.</param>
        public IterativeDeepeningAStarSearch(IHeuristicFunction<TState> heuristicFunction, double limit)
        {
            _evaluationFunction = new AStarEvaluationFunction<TState, TAction>(heuristicFunction);
            _limit = limit;
        }

        /// <summary>
        /// Returns a sequence of actions that reaches the goal.
        /// </summary>
        /// <param name="problem">A problem.</param>
        /// <returns>A sequence of actions that reaches the goal.</returns>
        public IList<TAction> Search(TProblem problem)
        {
            INode<TState, TAction> root = new Node<TState, TAction>(problem.InitialState);

            for (double bound = _evaluationFunction.Evaluate(root); bound <= _limit;)
            {
                Tuple<IList<TAction>, double> min = RecursiveDLS(problem, root, bound);

                if (!min.Item1.IsEmpty())
                {
                    return min.Item1;
                }

                bound = min.Item2;
            }

            return new List<TAction>();
        }

        /// <summary>
        /// Returns a tuple of a sequence of actions that reaches the goal and its estimated cost.
        /// </summary>
        /// <param name="problem">A problem.</param>
        /// <param name="node">A node.</param>
        /// <param name="limit">A depth at which nodes have no successors.</param>
        /// <returns>A tuple of a sequence of actions that reaches the goal or an empty sequence and its estimated cost.</returns>
        public Tuple<IList<TAction>, double> RecursiveDLS(TProblem problem, INode<TState, TAction> node, double limit)
        {
            double fCost = _evaluationFunction.Evaluate(node);

            if (fCost > limit)
            {
                return new Tuple<IList<TAction>, double>(_empty, fCost);
            }
            else if (problem.GoalTestFunction.GoalTest(node.State))
            {
                return new Tuple<IList<TAction>, double>(node.Solution(), fCost);
            }
            else
            {
                Tuple<IList<TAction>, double> min = _max;

                foreach (INode<TState, TAction> child in node.Expand(problem))
                {
                    Tuple<IList<TAction>, double> next = RecursiveDLS(problem, child, limit);

                    if (!min.Item1.IsEmpty())
                    {
                        return min;
                    }

                    min = min.Item2 <= next.Item2 ? min : next;
                }

                return min;
            }
        }
    }
}
