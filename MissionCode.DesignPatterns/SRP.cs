using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace MissionCode.DesignPatterns.SOLID
{
    public class Records
    {

        private List<string> data = new List<string>();

        public void add(string item)
        {
            data.Add(item);
        }

        public string RemoveLastItem()
        {
            var lastIndex = data.Count - 1;
            if (lastIndex < 0)
            {
                return null;
            }
            var item = data[lastIndex];
            data.RemoveAt(lastIndex);
            return item;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, data);
        }

        // breaks single responsibility principle
        public void Save()
        {
            File.WriteAllText(filePath, ToString());
            Process.Start(filePath);
        }

        private string filePath
        {
            get
            {
                return string.Format("{0}/record.txt", RootDirectory);
            }
        }
        private string RootDirectory
        {
            get
            {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            }
        }
    }

    // handles the responsibility of persisting objects
    public class Persistence
    {
      
        public static void Save(Records records)
        {
            File.WriteAllText(filePath, records.ToString());
            Process.Start(filePath);
        }

        private static string filePath
        {
            get
            {
                return string.Format("{0}/record.txt", RootDirectory);
            }
        }
        private static string RootDirectory
        {
            get
            {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            }
        }
    }
}
