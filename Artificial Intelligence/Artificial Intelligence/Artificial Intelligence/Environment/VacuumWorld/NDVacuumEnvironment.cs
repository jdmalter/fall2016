﻿using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Guard;
using System;

namespace Artificial_Intelligence.Environment.VacuumWorld
{
    /// <summary>
    /// An vacuum agent's envrionment which provides sensors and actuators to the agent.
    /// In this environment, the SUCK action has a probability P of failing to clean a location
    /// and each clean square has a probabiliy Q of becoming dirty at each step.
    /// Since there is nondeterminism in this class, I am not testing for expected results.
    /// </summary>
    public class NDVacuumEnvironment : Environment<VacuumAgent, VacuumPercept, VacuumAction>
    {
        /// <summary>
        /// The probability that the SUCH action fails to clean a location.
        /// </summary>
        public static readonly double P = 0.25;
        /// <summary>
        /// The probability that each clean square becomes dirty at each time step.
        /// </summary>
        public static readonly double Q = 0.10;

        /// <summary>
        /// A pseudo-random number generator.
        /// </summary>
        private readonly Random _random = new Random();

        /// <summary>
        /// A vacuum environment's possible state.
        /// </summary>
        private readonly VacuumEnvironmentState _environmentState;

        /// <summary>
        ///  Backing field for whether or not the environment is finished being actuated upon.
        /// </summary>
        private bool _isDone = false;

        /// <summary>
        /// Constructs vacuum environment state with two locations. Dirt is placed randomly.
        /// </summary>
        public NDVacuumEnvironment() : this(new VacuumEnvironmentState())
        {
            _environmentState.SetLocationStatus(Location.A, _random.Next(2) == 0 ? Status.CLEAN : Status.DIRTY);
            _environmentState.SetLocationStatus(Location.B, _random.Next(2) == 0 ? Status.CLEAN : Status.DIRTY);
        }

        /// <summary>
        /// Specifies a small child vacuum environment's state.
        /// </summary>
        /// <param name="state">A vacuum environment's possible state.</param>
        public NDVacuumEnvironment(VacuumEnvironmentState environmentState)
        {
            _environmentState = environmentState.NonNull();
        }

        /// <summary>
        /// Whether or not the environment is finished being actuated upon.
        /// </summary>
        public override bool IsDone { get { return _isDone; } }

        /// <summary>
        /// Performs vacuum agent's action on the environment.
        /// </summary>
        /// <param name="agent">An agent.</param>
        /// <param name="action">An action.</param>
        public override void Actuate(VacuumAgent agent, VacuumAction action)
        {
            agent.NonNull();
            action.NonNull();
            if (VacuumAction.NULL == action)
            {
                _isDone = true;
            }
            else if (VacuumAction.LEFT == action)
            {
                _environmentState.SetAgentLocation(agent, Location.A);
                ChangePerformanceMeasure(agent, -1);
            }
            else if (VacuumAction.RIGHT == action)
            {
                _environmentState.SetAgentLocation(agent, Location.B);
                ChangePerformanceMeasure(agent, -1);
            }
            else if (VacuumAction.SUCK == action)
            {
                Location agentLocation = _environmentState.GetAgentLocation(agent);
                Status locationStatus = _environmentState.GetLocationStatus(agentLocation);
                if (Status.DIRTY == locationStatus && _random.NextDouble() < P)
                {
                    _environmentState.SetLocationStatus(agentLocation, Status.CLEAN);
                    ChangePerformanceMeasure(agent, 10);
                }
            }
        }

        /// <summary>
        /// Adds a vacuum agent to the environment's agents.
        /// </summary>
        /// <param name="agent">New agent.</param>
        public override void Add(VacuumAgent agent)
        {
            Location location = _random.Next(2) == 0 ? Location.A : Location.B;
            _environmentState.SetAgentLocation(agent.NonNull(), location);
            base.Add(agent);
        }

        /// <summary>
        /// Creates a vacuum agent's inputs at the given step.
        /// </summary>
        /// <param name="agent">An agent.</param>
        /// <returns>An agent's inputs at the given step.</returns>
        public override VacuumPercept Sense(VacuumAgent agent)
        {
            Location agentLocation = _environmentState.GetAgentLocation(agent.NonNull());
            Status locationStatus = _environmentState.GetLocationStatus(agentLocation);
            return new VacuumPercept(agentLocation, locationStatus);
        }

        /// <summary>
        /// Moves the environment forward by one step.
        /// </summary>
        public override void Step()
        {
            base.Step();
            foreach (Location location in _environmentState.Locations)
            {
                if (Status.CLEAN == _environmentState.GetLocationStatus(location))
                {
                    foreach (VacuumAgent agent in Agents)
                    {
                        ChangePerformanceMeasure(agent, 1);
                    }
                    if (_random.NextDouble() < Q)
                    {
                        _environmentState.SetLocationStatus(location, Status.DIRTY);
                    }
                }
            }
        }
    }
}