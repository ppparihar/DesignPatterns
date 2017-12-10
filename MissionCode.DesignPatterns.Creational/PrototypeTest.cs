using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MissionCode.DesignPatterns.Creational
{
    [TestClass]
    public class PrototypeTest
    {
        [TestMethod]
        public void DeepCopy_Works()
        {
            var line1 = new Line
            {
                Start = new Coordinate { X = 1, Y = 1 },
                End = new Coordinate { X = 8, Y = 7 }
            };

            var line2 = line1.DeepCopy();

            line1.Start.X = line1.Start.Y = line1.End.X = line1.End.Y = 0;

            Assert.AreEqual(line2.Start.X, 1);
            Assert.AreEqual(line2.Start.Y, 1);
            Assert.AreEqual(line2.End.X, 8);
            Assert.AreEqual(line2.End.Y, 7);

        }
    }
}
