using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionCode.DesignPatterns.Creational
{
    class Program
    {
        static void Main(string[] args)
        {
            Builder();
            AbstractFactory();
        }

        private static void Builder()
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
        }

        static void AbstractFactory()
        {
            var machine = new HotDrinkMachine();
            //var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 300);
            //drink.Consume();

            IHotDrink drink = machine.MakeDrink();
            drink.Consume();
        }
    }

    
}
