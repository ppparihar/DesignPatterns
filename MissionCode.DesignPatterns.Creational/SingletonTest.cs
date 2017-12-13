using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MissionCode.DesignPatterns.Creational
{
    [TestClass]
    public class SingletonTests
    {
        [TestMethod]
        public void IsSingletonTest()
        {
            var db = SingletonDatabase.Instance;
            var db2 = SingletonDatabase.Instance;
            Assert.AreSame(db, db2);
            Assert.AreEqual(SingletonDatabase.Count, 1);
        }

        [TestMethod]
        public void SingletonTotalProductTest()
        {
            // testing on a live database
            var rf = new SingletonRecordFinder();
            var names = new[] { "Pen", "Book" };
            int tp = rf.TotalProducts(names);
            Assert.AreEqual(tp, 3200 + 2500);
        }

        [TestMethod]
        public void DependantTotalProductsTest()
        {
            var db = new DummyDatabase();
            var rf = new ConfigurableRecordFinder(db);
            Assert.AreEqual(rf.GetTotalProducts(new[] { "alpha", "gamma" }), 4);
        }
    }


}
