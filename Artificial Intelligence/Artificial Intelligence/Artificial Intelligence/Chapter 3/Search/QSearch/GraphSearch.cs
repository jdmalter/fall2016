using System;
using System.Collections.Generic;
using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.List;

namespace Artificial_Intelligence.Chapter_3.Search.QSearch
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TProblem"></typeparam>
    /// <typeparam name="TState"></typeparam>
    /// <typeparam name="TAction"></typeparam>
    public abstract class GraphSearch<TProblem, TState, TAction> : QueueSearch<TProblem, TState, TAction>
          where TProblem : IProblem<TState, TAction>
          where TState : IState
          where TAction : IAction
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ISet<TState> _explored = new HashSet<TState>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="problem"></param>
        /// <returns></returns>
        public override IList<TAction> Search(TProblem problem)
        {
            _explored.Clear();
            return base.Search(problem);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frontier"></param>
        /// <param name="node"></param>
        public override void Add(IList<INode<TState, TAction>> frontier, INode<TState, TAction> node)
        {
            if (!_explored.Contains(node.State))
            {
                frontier.Push(node);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frontier"></param>
        /// <returns></returns>
        public override INode<TState, TAction> Remove(IList<INode<TState, TAction>> frontier)
        {
            INode<TState, TAction> node = frontier.PopFirstIn();
            _explored.Add(node.State);
            return node;
        }
    }
}
