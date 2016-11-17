using Artificial_Intelligence.Chapter_2.Agent;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Linq;

namespace Artificial_Intelligence.Environment.VacuumWorld.Tests
{
    [TestClass]
    public class VacuumEnvironmentTests
    {
        /// <summary>
        /// Dependency of parameter to subject under test.
        /// </summary>
        private IAgentProgram<VacuumPercept, VacuumAction> _agentProgram;

        /// <summary>
        /// Parameter to subject under test.
        /// </summary>
        private VacuumAgent _agent;

        /// <summary>
        /// Parameter to subject under test.
        /// </summary>
        private Location _location;

        /// <summary>
        /// Return of subject under test.
        /// </summary>
        private VacuumAction _action;

        /// <summary>
        /// Dependency of subject under test.
        /// </summary>
        private VacuumEnvironmentState _environmentState;

        /// <summary>
        /// Subject under test.
        /// </summary>
        private VacuumEnvironment _sut;

        [TestInitialize]
        public void Initialize()
        {
            _agentProgram = Substitute.For<IAgentProgram<VacuumPercept, VacuumAction>>();
            _agent = Substitute.For<VacuumAgent>(_agentProgram);
            _environmentState = Substitute.For<VacuumEnvironmentState>();
            _sut = new VacuumEnvironment(_environmentState);
        }

        [TestMethod]
        public void InitialAgentsAny()
        {
            // Assert
            Assert.IsFalse(_sut.Agents.Any());
        }

        [TestMethod]
        public void InitialIsDone()
        {
            // Assert
            Assert.IsFalse(_sut.IsDone);
        }

        [TestMethod]
        public void ActuateNullAgentParameter()
        {
            // Arrange
            _agent = null;
            _action = VacuumAction.NULL;

            try
            {
                // Act
                _sut.Actuate(_agent, _action);

                // Assert
                Assert.Fail("Exception should be thrown.");
            }
            catch (ArgumentNullException)
            {
                // Assert
                Assert.IsFalse(_sut.IsDone);
            }
        }

        [TestMethod]
        public void ActuateNullActionParameter()
        {
            // Arrange
            _action = null;

            try
            {
                // Act
                _sut.Actuate(_agent, _action);

                // Assert
                Assert.Fail("Exception should be thrown.");
            }
            catch (ArgumentNullException)
            {
                // Assert
                Assert.IsFalse(_sut.IsDone);
            }
        }

        [TestMethod]
        public void ActuateNullAction()
        {
            // Arrange
            _action = VacuumAction.NULL;

            // Act
            _sut.Actuate(_agent, _action);

            // Assert
            Assert.IsTrue(_sut.IsDone);
        }

        [TestMethod]
        public void ActuateLeftAction()
        {
            // Arrange
            _action = VacuumAction.LEFT;

            // Act
            _sut.Actuate(_agent, _action);

            // Assert
            Assert.AreEqual(Location.A, _environmentState.GetAgentLocation(_agent));
            Assert.AreEqual(-1, _sut.GetPerformanceMeasure(_agent));
        }

        [TestMethod]
        public void ActuateRightAction()
        {
            // Arrange
            _action = VacuumAction.RIGHT;

            // Act
            _sut.Actuate(_agent, _action);

            // Assert
            Assert.AreEqual(Location.B, _environmentState.GetAgentLocation(_agent));
            Assert.AreEqual(-1, _sut.GetPerformanceMeasure(_agent));
        }

        [TestMethod]
        public void ActuateSuckCleanAction()
        {
            // Arrange
            _location = Location.A;
            _environmentState.SetAgentLocation(_agent, _location);
            _environmentState.SetLocationStatus(_location, Status.CLEAN);
            _action = VacuumAction.SUCK;

            // Act
            _sut.Actuate(_agent, _action);

            // Assert
            Assert.AreEqual(Status.CLEAN, _environmentState.GetLocationStatus(_location));
            Assert.AreEqual(0, _sut.GetPerformanceMeasure(_agent));
        }

        [TestMethod]
        public void ActuateSuckDirtyAction()
        {
            // Arrange
            _location = Location.B;
            _environmentState.SetAgentLocation(_agent, _location);
            _environmentState.SetLocationStatus(_location, Status.DIRTY);
            _action = VacuumAction.SUCK;

            // Act
            _sut.Actuate(_agent, _action);

            // Assert
            Assert.AreEqual(Status.CLEAN, _environmentState.GetLocationStatus(_location));
            Assert.AreEqual(10, _sut.GetPerformanceMeasure(_agent));
        }

        [TestMethod]
        public void AddNullAgentParameter()
        {
            // Arrange
            _agent = null;

            try
            {
                // Act
                _sut.Add(_agent);

                // Assert
                Assert.Fail("Exception should be thrown.");
            }
            catch (ArgumentNullException)
            {
                // Assert
                Assert.IsFalse(_sut.Agents.Any());
            }
        }

        [TestMethod]
        public void AddAgent()
        {
            // Act
            _sut.Add(_agent);

            // Assert
            Assert.IsTrue(_sut.Agents.Contains(_agent));
            Assert.IsNotNull(_environmentState.GetAgentLocation(_agent));
        }

        [TestMethod]
        public void SenseNullAgentParameter()
        {
            // Arrange
            _agent = null;
            VacuumPercept percept = null;

            try
            {
                // Act
                percept = _sut.Sense(_agent);

                // Assert
                Assert.Fail("Exception should be thrown.");
            }
            catch (ArgumentNullException)
            {
                // Assert
                Assert.IsNull(percept);
            }
        }

        [TestMethod]
        public void SenseAgent()
        {
            // Arrange
            _location = Location.A;
            _environmentState.SetAgentLocation(_agent, _location);
            _environmentState.SetLocationStatus(_location, Status.CLEAN);

            // Act
            VacuumPercept percept = _sut.Sense(_agent);

            // Assert
            Assert.AreEqual(_location, percept.Location);
            Assert.AreEqual(Status.CLEAN, percept.Status);
        }
    }
}
