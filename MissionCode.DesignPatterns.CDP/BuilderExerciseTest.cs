using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MissionCode.DesignPatterns.CDP
{
    [TestClass]
    public class FirstTestSuite
    {
        private static string Preprocess(string s)
        {
            return s.Trim().Replace("\r\n", "\n");
        }

        [TestMethod]
        public void EmptyTest()
        {
            var cb = new CodeBuilder("Foo");
            Assert.AreEqual(Preprocess(cb.ToString()), "public class Foo\n{\n}");
        }

        [TestMethod]
        public void PersonTest()
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            var expected = @"public class Person
{
  public string Name;
  public int Age;
}";

            Assert.IsTrue(string.Equals(cb.ToString(), expected));

         
        }
    }
}
