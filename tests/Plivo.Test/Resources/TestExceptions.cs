using NUnit.Framework;
using Plivo.Exception;

namespace Plivo.Test.Resources
{
    [TestFixture]
    public class TestExceptions : BaseTestCase
    {
        [Test]
        public void TestThrowsPlivoValidationException()
        {
            var ex =
                Assert.Throws<PlivoValidationException>(
                    () => Api.Application.Create(
                        ""));
            Assert.That(ex.Message, Is.EqualTo("appName is mandatory, can not be null or empty"));
        }

        [Test]
        public void TestThrowsPlivoException()
        {
            var ex =
                Assert.Throws<PlivoValidationException>(
                    () => Api.Application.Create(
                        "", "http://www.com", null));
            Assert.That(ex.Message, Is.EqualTo("appName is mandatory, can not be null or empty"));
        }

        [Test]
        public void TestLimitException()
        {
            var ex =
                Assert.Throws<PlivoValidationException>(
                    () => Api.Call.List(limit: 112));
            Assert.That(ex.Message, Is.EqualTo("limit:112 is out of range [0,20]"));
        }
    }
}