using NUnit.Framework;
using sample_ui_pipeline_v1.Services;
using System.Linq;

namespace sample_ui_pipeline_v1_tests
{
    public class Tests
    {
        private TestService _testService;

        [SetUp]
        public void Setup()
        {
            _testService = new TestService();
        }

        [Test]
        public void TestGetData()
        {
            var data = _testService.Get();
            Assert.That(data.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void TestGetDataById()
        {
            var data = _testService.GetById(1);
            
            /** Success Case **/
            Assert.That(data, Is.Not.EqualTo(string.Empty));


            /** Fail Case **/
            //Assert.That(data, Is.EqualTo(string.Empty));


        }



    }
}