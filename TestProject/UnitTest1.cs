using stringmatch.Controllers;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //A unit test that ensures our app always returns a correct view with the name "Index". 
            var controller = new StringMatchController();
            var test1 = controller.Index("test") as Microsoft.AspNetCore.Mvc.ViewResult;
            var test2 = controller.StringMatcher("test");

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Assert.That(test1.ViewName, Is.EqualTo("Index"));
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            string[] data = test2.ToArray();
            if (data[1].Equals("No matches"))
            {
                Assert.Pass();
            }
        }
    }
}