using Moq;
using NUnit.Framework.Constraints;
using PerfMon.Business.Models.Agent;
using PerfMon.Business.Models.Agent.Exceptions;
using PerfMon.Business.Models.Sample;
using PerfMon.Business.Repositories;
using System.Runtime.CompilerServices;

namespace PerfMon.Business.Tests
{
    public class AgentTests
    {
        private Agent TestAgent;
        [SetUp]
        public void Setup()
        {
            TestAgent = new Agent("test-1");
        }

        [Test]
        public void Ping_Update_On_Agent_Registration()
        {
            var prev = TestAgent.LastSeen;
            TestAgent.Ping();

            Assert.That(TestAgent.LastSeen, Is.Not.EqualTo(prev));
        }

        [Test]
        public void Registering_Measure_Should_Update_LastSeen()
        {
            var prev = TestAgent.LastSeen;

            // register a random measure
            TestAgent.RegisterMeasure("fake", "%", MeasureType.Numeric);

            Assert.That(TestAgent.LastSeen, Is.Not.EqualTo(prev));
        }

        [Test]
        public void Should_Register_Valid_Measure()
        {
            const string MEASURE_NAME = "sample-1";
            TestAgent.RegisterMeasure(MEASURE_NAME, "%", MeasureType.Numeric);

            var measure = TestAgent.GetMeasure(MEASURE_NAME);

            Assert.That(measure, Is.Not.Null);
            Assert.That(measure.UniqueName, Is.EqualTo(MEASURE_NAME));
        }

        [Test]
        public void Should_Not_Register_Same_Measure_Twice()
        {
            var prevCount = TestAgent.Measures.Count();

            TestAgent.RegisterMeasure("measure-1", "%", MeasureType.String);
            TestAgent.RegisterMeasure("measure-1", "%", MeasureType.String);

            Assert.That(TestAgent.Measures.Count(), Is.EqualTo(prevCount + 1));
        }

        [Test]
        public void ReRegistering_Same_Measure_With_Different_Type_Should_Throw()
        {
            TestAgent.RegisterMeasure("measure-1", "%", MeasureType.Numeric);
            // re-register with a different type
            try
            {
                TestAgent.RegisterMeasure("measure-1", "%", MeasureType.String);
                Assert.Fail("Should have failed");
            }
            catch (IncompatibleMeasureException ex)
            {
                Assert.Pass();
            }
            catch (Exception e)
            {
                Assert.Fail("Wrong exception type thrown");
            }
        }


        [Test]
        public async Task Registering_Sample_Should_Update_Measure_Metadata() 
        {
            // moq sampleservice
            var sampleServiceMoq = new Mock<ISamplesRepo>(MockBehavior.Loose);

            // register a measure (empty)
            TestAgent.RegisterMeasure("m1", "%", MeasureType.Numeric);

            // register a sample
            var sampleTime = DateTime.Now;
            await TestAgent.RegisterSampleAsync("m1", sampleTime, 1d, sampleServiceMoq.Object);

            var measure = TestAgent.GetMeasure("m1");
            if (measure == null)
            {
                Assert.Inconclusive();
                return;
            }
            Assert.That(measure.LastValueTimestamp, Is.EqualTo(sampleTime));
            Assert.That(measure.FirstValueTimestamp, Is.EqualTo(sampleTime));
        }

        [Test]
        public async Task Registering_Sample_Should_Invoke_SampleService()
        {
            var sampleService = new Mock<ISamplesRepo>();
            sampleService.Setup(srv => srv.RegisterSampleAsync(It.IsAny<Sample>())).Returns(Task.CompletedTask);

            TestAgent.RegisterMeasure("X", "%", MeasureType.Numeric);

            await TestAgent.RegisterSampleAsync("X", DateTime.Now, 123d, sampleService.Object);

            sampleService.Verify(srv => srv.RegisterSampleAsync(It.IsAny<Sample>()), Times.Once());
        }
    }
}