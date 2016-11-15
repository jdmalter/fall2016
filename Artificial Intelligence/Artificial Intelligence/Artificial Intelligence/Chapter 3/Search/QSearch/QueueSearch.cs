using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.List;
using System.Collections.Generic;

namespace Artificial_Intelligence.Chapter_3.Search.QSearch
{
    /// <summary>
    /// Queue based search interface.
    /// </summary>
    /// <typeparam name="TProblem">Any problem of TState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public abstract class QueueSearch<TProblem, TState, TAction>
        where TProblem : IProblem<TState, TAction>
        where TState : IState
        where TAction : IAction
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="problem"></param>
        /// <returns></returns>
        public virtual IList<TAction> Search(TProblem problem)
        {
            IList<INode<TState, TAction>> frontier =
                problem.InitialState.RootNode<TState, TAction>().Cons(IList.Empty<INode<TState, TAction>>());

            while (!frontier.IsEmpty())
            {
                INode<TState, TAction> node = Remove(frontier);

                if (problem.GoalTestFunction.GoalTest(node.State))
                {
                    return node.Solution();
                }

                foreach (INode<TState, TAction> child in node.Expand(problem))
                {
                    Add(frontier, node);
                }
            }

            return IList.Empty<TAction>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frontier"></param>
        /// <param name="node"></param>
        public abstract void Add(IList<INode<TState, TAction>> frontier, INode<TState, TAction> node);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frontier"></param>
        /// <returns></returns>
        public abstract INode<TState, TAction> Remove(IList<INode<TState, TAction>> frontier);
    }
}
