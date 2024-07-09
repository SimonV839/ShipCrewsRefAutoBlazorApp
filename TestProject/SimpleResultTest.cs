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
                Assert.True(res.IsSuccess, "Default SimpleResult should show success.");
                Assert.Null(res.Error, "Default SimpleResult should have no error.");
            }
        }

        [Test]
        public void AssignmentSuccess()
        {
            {
                var res = new SimpleResponse { Error = null };
                Assert.False(res.IsSuccess, "IsSuccess should have been set.");
                Assert.IsNull(res.Error, "SimpleResults should have a null error on success.");
            }

            {
                var res = new SimpleResponse { Error = "Error text" };
                Assert.False(res.IsSuccess, "IsSuccess should be false on error.");
                Assert.That(res.Error, Is.EqualTo("Error text"), "Error should have been set.");
            }
        }
    }
}