using System;
using System.Collections.Generic;

using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MissionCode.DesignPatterns.SOLID
{
    //Single Responsibility Princilple
    //A class should only have one reason to change
    public class Records
    {

        private List<string> _data = new List<string>();

        public void Add(string item)
        {
            _data.Add(item);
        }

        public string RemoveLastItem()
        {
            var lastIndex = _data.Count - 1;
            if (lastIndex < 0)
            {
                return null;
            }
            var item = _data[lastIndex];
            _data.RemoveAt(lastIndex);
            return item;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _data);
        }

        // breaks single responsibility principle
        public void Save()
        {
            File.WriteAllText(FilePath, ToString());
            Process.Start(FilePath);
        }

        private static string FilePath => $"{RootDirectory}/record.txt";

        private static string RootDirectory => Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
    }

    // handles the responsibility of persisting objects
    public class Persistence
    {

        public static void Save(Records records)
        {
            File.WriteAllText(FilePath, records.ToString());
            Process.Start(FilePath);
        }

        private static string FilePath => $"{RootDirectory}/record.txt";

        private static string RootDirectory => Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
    }
}
