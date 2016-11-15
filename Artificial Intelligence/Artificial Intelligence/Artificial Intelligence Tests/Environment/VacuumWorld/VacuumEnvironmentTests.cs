using Artificial_Intelligence.Chapter_2.Agent;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
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
            // Act
            bool any = _sut.Agents.Any();

            // Assert
            Assert.IsFalse(any);
        }

        [TestMethod]
        public void InitialIsDone()
        {
            // Act
            bool isDone = _sut.IsDone;

            // Assert
            Assert.IsFalse(isDone);
        }

        [TestMethod]
        public void ActuateNullAction()
        {
            // Arrange
            _action = VacuumEnvironment.NULL;

            // Act
            _sut.Actuate(_agent, _action);

            // Assert
            Assert.IsTrue(_sut.IsDone);
        }

        [TestMethod]
        public void ActuateLeftAction()
        {
            // Arrange
            _action = VacuumEnvironment.LEFT;

            // Act
            _sut.Actuate(_agent, _action);

            // Assert
            Assert.AreEqual(VacuumEnvironment.A, _environmentState.GetAgentLocation(_agent));
            Assert.AreEqual(-1, _sut.GetPerformanceMeasure(_agent));
        }

        [TestMethod]
        public void ActuateRightAction()
        {
            // Arrange
            _action = VacuumEnvironment.RIGHT;

            // Act
            _sut.Actuate(_agent, _action);

            // Assert
            Assert.AreEqual(VacuumEnvironment.B, _environmentState.GetAgentLocation(_agent));
            Assert.AreEqual(-1, _sut.GetPerformanceMeasure(_agent));
        }

        [TestMethod]
        public void ActuateSuckCleanAction()
        {
            // Arrange
            _location = VacuumEnvironment.A;
            _environmentState.SetAgentLocation(_agent, _location);
            _environmentState.SetLocationStatus(_location, VacuumEnvironment.CLEAN);
            _action = VacuumEnvironment.SUCK;

            // Act
            _sut.Actuate(_agent, _action);

            // Assert
            Assert.AreEqual(VacuumEnvironment.CLEAN, _environmentState.GetLocationStatus(_location));
            Assert.AreEqual(0, _sut.GetPerformanceMeasure(_agent));
        }

        [TestMethod]
        public void ActuateSuckDirtyAction()
        {
            // Arrange
            _location = VacuumEnvironment.B;
            _environmentState.SetAgentLocation(_agent, _location);
            _environmentState.SetLocationStatus(_location, VacuumEnvironment.DIRTY);
            _action = VacuumEnvironment.SUCK;

            // Act
            _sut.Actuate(_agent, _action);

            // Assert
            Assert.AreEqual(VacuumEnvironment.CLEAN, _environmentState.GetLocationStatus(_location));
            Assert.AreEqual(10, _sut.GetPerformanceMeasure(_agent));
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
        public void SenseAgent()
        {
            // Arrange
            _location = VacuumEnvironment.A;
            _environmentState.SetAgentLocation(_agent, _location);
            _environmentState.SetLocationStatus(_location, VacuumEnvironment.CLEAN);

            // Act
            VacuumPercept percept = _sut.Sense(_agent);

            // Assert
            Assert.AreEqual(_location, percept.Location);
            Assert.AreEqual(VacuumEnvironment.CLEAN, percept.Status);
        }
    }
}
