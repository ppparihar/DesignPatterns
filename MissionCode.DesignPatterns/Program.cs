using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionCode.DesignPatterns.SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            var record = new Records();
            record.Add("first Item");
            record.Add("second Item");
           // record.Save();

          // handles the responsibility of persisting objects here
            Persistence.Save(record);
        }
    }
}
