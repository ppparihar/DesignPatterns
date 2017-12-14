using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MissionCode.DesignPatterns.Structural
{
    [TestClass]
    public class CompositeTest
    {
        [TestMethod]
        public void Test()
        {
            var singleValue = new SingleValue { Value = 11 };
            var otherValues = new ManyValues();
            otherValues.Add(22);
            otherValues.Add(33);
            Assert.AreEqual(new List<IValueContainer> { singleValue, otherValues }.Sum(), 66);
        }
    }
}
