using ShipCrewsRefAutoBlazorApp;

namespace TestProject
{
    public class SimpleResultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Initialisation()
        {
            {
                var res = new SimpleResponse();
                Assert.True(res.IsValid, "Default SimpleResult should be valid.");
                Assert.True(res.IsSuccess, "Default SimpleResult should show success.");
                Assert.Null(res.Error, "Default SimpleResult should have no error.");
            }
        }

        [Test]
        public void AssignmentSuccess()
        {
            {
                var res = new SimpleResponse { IsSuccess = false };
                Assert.False(res.IsSuccess, "IsSuccess should have been set.");
                Assert.That(res.Error, Is.EqualTo(string.Empty), "SimpleResults should have an empty error when set to false from true.");
                Assert.True(res.IsValid, "SimpleResults should be valid when setting to false.");
            }

            {
                var res = new SimpleResponse { IsSuccess = false, Error = "Error text" };
                Assert.False(res.IsSuccess, "IsSuccess should have been set.");
                Assert.That(res.Error, Is.EqualTo("Error text"), "Error should have been set.");
                Assert.True(res.IsValid, "SimpleResults should be valid when setting to false.");
            }
        }

        [Test]
        public void ErrorAssignmentFailure()
        {
            try
            {
                new SimpleResponse() { Error = "IsSuccess should have been set first" };
                Assert.Fail("The user must ensure IsSuccess is false before assigning an error.");
            }
            catch
            {
                //ContractViolationException
            }
        }
    }
}