using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Artificial_Intelligence.Environment.VacuumWorld.Tests
{
    [TestClass]
    public class VacuumEnvironmentSimulators
    {
        /// <summary>
        /// Parameter to subject under test.
        /// </summary>
        private VacuumAgent _agent;

        /// <summary>
        /// Subject under test.
        /// </summary>
        private VacuumEnvironment _sut;

        /// <summary>
        /// Return of subject under test.
        /// </summary>
        private double _performanceMeasure;

        [TestInitialize]
        public void TestInitialize()
        {
            _sut = new VacuumEnvironment();
        }

        private void Simulate()
        {
            // Act
            _sut.Add(_agent);
            _sut.Step(1000);
            _performanceMeasure = _sut.GetPerformanceMeasure(_agent);
        }

        [TestMethod]
        public void ModelReflex()
        {
            // Arrange
            ISet<VacuumConditionActionRule> rules = new HashSet<VacuumConditionActionRule>()
            {
                new VacuumConditionActionRule(state =>
                {
                    Location location = state.Location;
                    Status status = state.GetLocationStatus(location);
                    return status == VacuumEnvironment.DIRTY;
                }, VacuumEnvironment.SUCK),
                new VacuumConditionActionRule(state =>
                {
                    return state.Location == VacuumEnvironment.B;
                }, VacuumEnvironment.LEFT),
                new VacuumConditionActionRule(state =>
                {
                    return state.Location == VacuumEnvironment.A;
                }, VacuumEnvironment.RIGHT),
            };
            VacuumConditionActionRule rule = new VacuumConditionActionRule(state => true, VacuumEnvironment.NULL);
            _agent = new VacuumAgent(new ModelReflexVacuumAgentProgram(new VacuumModel(), rules, rule));

            // Act
            Simulate();

            // two clean locations -> 1000
            // start location dirty -> 1010
            // start location clean -> 1011
            // two dirty locations -> 1020

            // Assert
            Assert.IsTrue(_performanceMeasure == 1000
                       || _performanceMeasure == 1010
                       || _performanceMeasure == 1011
                       || _performanceMeasure == 1020);
        }

        [TestMethod]
        public void Random()
        {
            // Arrange
            ISet<VacuumAction> actions = new HashSet<VacuumAction>()
            {
                VacuumEnvironment.LEFT,
                VacuumEnvironment.RIGHT,
                VacuumEnvironment.SUCK,
                VacuumEnvironment.NULL,
            };
            _agent = new VacuumAgent(new RandomVacuumAgentProgram(actions));

            // Act
            Simulate();

            // Assert
            // It is impossible to predict the outcome of a random variable
            // Therefore it is impossible to make accurate assertions
            // Assert.Inconclusive("performance measure is " + _performanceMeasure);
        }

        [TestMethod]
        public void SimplexReflex()
        {
            // Arrange
            ISet<VacuumConditionActionRule> rules = new HashSet<VacuumConditionActionRule>()
            {
                new VacuumConditionActionRule(state =>
                {
                    Location location = state.Location;
                    Status status = state.GetLocationStatus(location);
                    return status == VacuumEnvironment.DIRTY;
                }, VacuumEnvironment.SUCK),
                new VacuumConditionActionRule(state =>
                {
                    return state.Location == VacuumEnvironment.B;
                }, VacuumEnvironment.LEFT),
                new VacuumConditionActionRule(state =>
                {
                    return state.Location == VacuumEnvironment.A;
                }, VacuumEnvironment.RIGHT),
            };
            VacuumConditionActionRule rule = new VacuumConditionActionRule(state => true, VacuumEnvironment.NULL);
            _agent = new VacuumAgent(new SimpleReflexVacuumAgentProgram(rules, rule));

            // Act
            Simulate();

            // two clean locations -> 1000
            // start location dirty -> 1010
            // start location clean -> 1011
            // two dirty locations -> 1020

            // Assert
            Assert.IsTrue(_performanceMeasure == 1000
                       || _performanceMeasure == 1010
                       || _performanceMeasure == 1011
                       || _performanceMeasure == 1020);
        }

        [TestMethod]
        public void Reflex()
        {
            // Arrange
            _agent = new VacuumAgent(new ReflexVacuumAgentProgram());

            // Act
            Simulate();

            // two clean locations -> 1000
            // start location dirty -> 1010
            // start location clean -> 1011
            // two dirty locations -> 1020

            // Assert
            Assert.IsTrue(_performanceMeasure == 1000
                       || _performanceMeasure == 1010
                       || _performanceMeasure == 1011
                       || _performanceMeasure == 1020);
        }

        /// <summary>
        /// Dependency of parameter to parameter to subject under test.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        private class ListComparer<T> : IEqualityComparer<IList<T>>
        {
            public bool Equals(IList<T> x, IList<T> y)
            {
                return x.SequenceEqual(y);
            }

            public int GetHashCode(IList<T> obj)
            {
                int hash = 0;
                foreach (T t in obj)
                {
                    hash ^= t.GetHashCode();
                }
                return hash;
            }
        }

        [TestMethod]
        public void TableDriven()
        {
            // Arrange
            IEqualityComparer<IList<VacuumPercept>> comparer = new ListComparer<VacuumPercept>();
            IDictionary<IList<VacuumPercept>, VacuumAction> table = new Dictionary<IList<VacuumPercept>, VacuumAction>(comparer)
            {
                // one percept
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.RIGHT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.LEFT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                // two percepts                            
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.RIGHT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.RIGHT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.RIGHT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.RIGHT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.LEFT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.LEFT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.LEFT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.LEFT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                // three percepts                          
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.RIGHT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.RIGHT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.RIGHT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.RIGHT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.RIGHT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.RIGHT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.RIGHT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.RIGHT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.RIGHT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.RIGHT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.RIGHT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.RIGHT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.RIGHT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.RIGHT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.RIGHT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.RIGHT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.LEFT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.LEFT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.LEFT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.LEFT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.LEFT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.LEFT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.LEFT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.LEFT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.LEFT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.LEFT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.LEFT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.LEFT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.LEFT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.LEFT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.LEFT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                }] = VacuumEnvironment.LEFT,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.A, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.CLEAN),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
                [new List<VacuumPercept>()
                {
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                    new VacuumPercept(VacuumEnvironment.B, VacuumEnvironment.DIRTY),
                }] = VacuumEnvironment.SUCK,
            };
            _agent = new VacuumAgent(new TableDrivenVacuumAgentProgram(table, VacuumEnvironment.NULL));

            // Act
            Simulate();

            // two clean locations -> 1997
            // start location dirty -> 2007
            // start location clean -> 2008
            // two dirty locations -> 2017

            // Assert
            Assert.IsTrue(_performanceMeasure == 1997
                       || _performanceMeasure == 2007
                       || _performanceMeasure == 2008
                       || _performanceMeasure == 2017);
        }
    }
}
