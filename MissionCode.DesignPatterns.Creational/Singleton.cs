using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;


namespace MissionCode.DesignPatterns.Creational
{
    public interface IDatabase
    {
        int GetProducts(string name);
    }

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> products;
        private static int instanceCount;
        public static int Count => instanceCount;

        private SingletonDatabase()
        {


            products = File.ReadAllLines(
              Path.Combine(
                new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "products.txt")
              )
              .Batch(2)
              .ToDictionary(
                list => list.ElementAt(0).Trim(),
                list => int.Parse(list.ElementAt(1)));
        }

        public int GetProducts(string name)
        {
            return products[name];
        }

        // laziness + thread safety
        private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() =>
        {
            instanceCount++;
            return new SingletonDatabase();
        });

        public static IDatabase Instance => instance.Value;
    }

    public class SingletonRecordFinder
    {
        public int TotalProducts(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
            {
                // SingletonRecordFinder is tightly coupled with SingletonDatabase
                // Which force to test with the actual implementation(live data) 
                result += SingletonDatabase.Instance.GetProducts(name);
            }

            return result;
        }
    }

    public class ConfigurableRecordFinder
    {
        private IDatabase database;

        public ConfigurableRecordFinder(IDatabase database)
        {
            this.database = database;
        }

        public int GetTotalProducts(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
                result += database.GetProducts(name);
            return result;
        }
    }

    //Constructor has to be public, so that we can instancate the object and inject it.
    //We can use DI framwork for depencency injection 
    public class DummyDatabase : IDatabase
    {
        public int GetProducts(string name)
        {
            return new Dictionary<string, int>
            {
                ["alpha"] = 1,
                ["beta"] = 2,
                ["gamma"] = 3
            }[name];
        }
    }

}
