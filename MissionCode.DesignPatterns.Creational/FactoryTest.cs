using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MissionCode.DesignPatterns.Creational
{
    [TestClass]
    public class FactoryTest
    {
        [TestMethod]
        public void Point_InstantiateByCallingSimpleConstructor_Works()
        {
            var point = new Point(1, 2);
            Assert.IsTrue(string.Equals(point.ToString(), "X: 1, Y: 2"));
        }

        [TestMethod]
        public void Point_InstantiateByCallingOverloadConstructor_Works()
        {
            var rho = 30;
            var theta = 30;

            var x = rho * Math.Cos(theta);
            var y = rho * Math.Sin(theta);

            var expected = $"X: {x}, Y: {y}";
            var point = new Point(rho, theta, Point.CoordinateSystem.Polar);

            Assert.IsTrue(string.Equals(point.ToString(), expected));
        }

        [TestMethod]
        public void Point_InstantiateByFactoryMethod_Works()
        {
            var rho = 30;
            var theta = 30;

            var x = rho * Math.Cos(theta);
            var y = rho * Math.Sin(theta);

            var expected = $"X: {x}, Y: {y}";
            var point = Point.NewPolarPoint(rho, theta);

            Assert.IsTrue(string.Equals(point.ToString(), expected));
        }

        [TestMethod]
        public void Point_InstantiateByInnerFactory_Works()
        {
            var x = 10;
            var y = 20;

            var expected = $"X: {x}, Y: {y}";
            var point = Point.Factory.NewCartesianPoint(x, y);

            Assert.IsTrue(string.Equals(point.ToString(), expected));
        }
    }
}
