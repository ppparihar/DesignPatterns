using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MissionCode.DesignPatterns.SOLID
{
    // ReSharper disable once InconsistentNaming
    [TestClass]
    public class LSPTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArrayTypeMismatchException))]
        public void LspCovariance_ThrowException()
        {
            WidgetBase w = new NotLspWidget();
            WidgetBase[] relatives = w.Relatives();

            //try to put some other WidgetBase to the array
            relatives[0] = new LspWidget();

            Assert.Fail("ArrayTypeMismatchException exception should have been thrown");
        }
        [TestMethod]
        public void LspCovariance_Works()
        {
            WidgetBase w = new LspWidget();
            WidgetBase[] relatives = w.Relatives();

            //try to put some other WidgetBase to the array
            relatives[0] = new NotLspWidget();
            Assert.IsTrue(true);
        }
    }
}