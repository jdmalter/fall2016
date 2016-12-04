using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Artificial_Intelligence.Chapter_3.Search.QSearch
{
    /// <summary>
    /// A queue search that uses bidirectional nodes.
    /// </summary>
    /// <typeparam name="TQueue">Any queue of IBidirectionalNode of TState and TAction.</typeparam>
    /// <typeparam name="TProblem">Any problem of TState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public class BidirectionalSearch<TQueue, TProblem, TState, TAction>
        : QueueSearch<TQueue, IBidirectionalNode<TState, TAction>, TProblem, TState, TAction>
         where TQueue : IQueue<IBidirectionalNode<TState, TAction>>
         where TProblem : IBidirectionalProblem<TProblem, TState, TAction>
         where TState : IState
         where TAction : IAction
    {
        /// <summary>
        /// A data structure which remembers every expanded node in the original problem.
        /// </summary>
        private readonly IDictionary<TState, IBidirectionalNode<TState, TAction>> _exploredOriginal =
            new Dictionary<TState, IBidirectionalNode<TState, TAction>>();

        /// <summary>
        /// A data structure which remembers every expanded node in the reverse problem.
        /// </summary>
        private readonly IDictionary<TState, IBidirectionalNode<TState, TAction>> _exploredReverse =
            new Dictionary<TState, IBidirectionalNode<TState, TAction>>();

        /// <summary>
        /// Returns a sequence of actions that reaches the goal.
        /// </summary>
        /// <param name="problem">A problem.</param>
        /// <param name="frontier">A queue of all leaf nodes available for expansion at any given point.</param>
        /// <returns>A sequence of actions that reaches the goal.</returns>
        public override IList<TAction> Search(TProblem problem, TQueue frontier)
        {
            _exploredOriginal.Clear();
            _exploredReverse.Clear();
            IBidirectionalNode<TState, TAction> rootOriginal = Root(problem.InitialState);
            IBidirectionalNode<TState, TAction> rootReverse = new BidirectionalNode<TState, TAction>(problem.Reverse.InitialState, false);

            if (rootOriginal.Equals(rootReverse))
            {
                return new List<TAction>();
            }

            frontier.Clear();
            frontier.Push(rootOriginal);
            frontier.Push(rootReverse);

            while (!IsEmpty(frontier))
            {
                IBidirectionalNode<TState, TAction> node = Remove(frontier);

                if ((node.IsOriginal ? _exploredReverse : _exploredOriginal).ContainsKey(node.State))
                {
                    IBidirectionalNode<TState, TAction> original = node.IsOriginal ? node : _exploredOriginal[node.State];
                    IBidirectionalNode<TState, TAction> reverse = node.IsOriginal ? _exploredReverse[node.State] : node;

                    IList<TAction> actions = original.Solution();
                    IList<TAction> reverseActions = reverse.ReverseSolution(problem);
                    return actions.Concat(reverseActions).ToList();
                }

                foreach (IBidirectionalNode<TState, TAction> child in node.Expand(problem))
                {
                    Add(frontier, child);
                }
            }

            return new List<TAction>();
        }

        /// <summary>
        /// Adds a new leaf node available for expansion to the frontier.
        /// </summary>
        /// <param name="frontier">A queue of all leaf nodes available for expansion at any given point.</param>
        /// <param name="node">A new leaf node available for expansion.</param>
        public override void Add(TQueue frontier, IBidirectionalNode<TState, TAction> node)
        {
            if (!(node.IsOriginal ? _exploredOriginal : _exploredReverse).ContainsKey(node.State))
            {
                frontier.Push(node);
            }
        }

        /// <summary>
        /// Determines whether the frontier contains any nodes available for expansion.
        /// </summary>
        /// <param name="frontier">A queue of all leaf nodes available for expansion at any given point.</param>
        /// <returns>Whether the frontier contains any nodes available for expansion.</returns>
        public override bool IsEmpty(TQueue frontier)
        {
            frontier.PopWhile(node => (node.IsOriginal ? _exploredOriginal : _exploredReverse).ContainsKey(node.State));
            return frontier.IsEmpty();
        }

        /// <summary>
        /// Removes and returns a node for expansion.
        /// </summary>
        /// <param name="frontier">A queue of all leaf nodes available for expansion at any given point.</param>
        /// <returns>A node for expansion.</returns>
        public override IBidirectionalNode<TState, TAction> Remove(TQueue frontier)
        {
            IBidirectionalNode<TState, TAction> node = frontier.Pop();
            (node.IsOriginal ? _exploredOriginal : _exploredReverse).Add(node.State, node);
            return node;
        }

        /// <summary>
        /// Returns a new root noot available for expansion.
        /// </summary>
        /// <param name="state">The initial state in which the seach starts.</param>
        /// <returns>A new root node available for expansion.</returns>
        public override IBidirectionalNode<TState, TAction> Root(TState state)
        {
            return new BidirectionalNode<TState, TAction>(state, true);
        }
    }
}
