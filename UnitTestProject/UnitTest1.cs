using Microsoft.VisualStudio.TestTools.UnitTesting;
using stringmatch.Controllers; 

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIndexView()
        {
            var controller = new StringMatchController();
            var result = controller.Index(1) as ViewResult;
            Assert.AreEqual("Index", result.ViewName);

        }
    }
}
