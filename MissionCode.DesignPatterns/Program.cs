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

           
            SRP();
            OCP();

            LSP();
            ExitStatment();

        }

        private static void SRP()
        {
            WriteHeading("SRP");
            var record = new Records();
            record.Add("first Item");
            record.Add("second Item");
            // record.Save();

            // handles the responsibility of persisting objects here
            Persistence.Save(record);
        }

        private static void OCP()
        {

            WriteHeading("OCP");
            var productList = new List<Product>
            {
                new Product("Shoe",Color.Blue, Size.Midium),
                new Product("bag",Color.Blue, Size.Large),
                new Product("Lunch Box",Color.Green, Size.Small),
                new Product("Hand Riding Gloves",Color.Red, Size.Midium)
            };

            var filter = new ProductFilter();
            foreach (var product in filter.ByColor(productList, Color.Blue))
            {
                Console.WriteLine(product);
            }
            foreach (var product in filter.BySize(productList, Size.Midium))
            {
                Console.WriteLine(product);
            }

            // Extendable filters
            var colorFilter = new ColorFilter(Color.Blue);
            foreach (var product in colorFilter.Filter(productList))
            {
                Console.WriteLine(product);
            }
            var sizeFilter = new SizeFilter(Size.Midium);
            foreach (var product in sizeFilter.Filter(productList))
            {
                Console.WriteLine(product);
            }

        }

        private static void LSP()
        {
            WriteHeading("LSP");

            WidgetBase widget = new NotLspWidget();
            WidgetBase[] widgetRelatives = widget.Relatives();

            try
            {
                //try to put some other WidgetBase to the array
                widgetRelatives[0] = new LspWidget();
            }
            catch (ArrayTypeMismatchException)
            {
                Console.WriteLine("ArrayTypeMismatchException handled");
            }

            WidgetBase w = new LspWidget();
            WidgetBase[] relatives = w.Relatives();

            //try to put some other WidgetBase to the array
            relatives[0] = new NotLspWidget();
        }

        static void WriteHeading(string heading)
        {
            Console.WriteLine("============================================");
            Console.WriteLine(heading);
            Console.WriteLine("============================================");

        }

        static void ExitStatment()
        {
            Console.WriteLine("Press any key to exit!!");
            Console.ReadKey();
        }
    }
}
