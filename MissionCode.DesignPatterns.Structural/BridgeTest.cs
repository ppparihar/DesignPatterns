using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MissionCode.DesignPatterns.Structural
{
    [TestClass]
    public class TestSuite
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(
                new Square(new VectorRenderer()).ToString(),
                "Drawing Square as lines");
        }
    }
}
