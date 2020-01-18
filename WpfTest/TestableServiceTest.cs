using Microsoft.VisualStudio.TestTools.UnitTesting;
using LessonWpf.Service;

namespace WpfTest
{
    [TestClass]
    public class TestableServiceTest
    {
        [TestMethod]
        public void TestCorrectSumMethod()
        {
            TestableService service = new TestableService();
            var result = service.CorrectSumMethod(2, 2);
            Assert.AreEqual(4, result);
        }
        [TestMethod]
        public void TestIncorrectSumMethod()
        {
            TestableService service = new TestableService();
            var result = service.IncorrectSumMethod(2, 2);
            Assert.AreEqual(4, result);
        }
    }
}
