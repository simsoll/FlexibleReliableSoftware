using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("======= Demonstration of Proxy =======");
            var wp = new WordProcessor();

            Console.WriteLine("--- Loading document (no image load) ---");
            wp.Load("mydocument.doc");

            Console.WriteLine("--- Showing page 1 ---");
            wp.ShowPage(1);

            Console.WriteLine("--- Showing page 2 (image load) ---");
            wp.ShowPage(2);

            Console.WriteLine("--- Back to page 1 ---");
            wp.ShowPage(1);

            Console.WriteLine("--- And again showing page 2 (no load)---");
            wp.ShowPage(2);

            Console.ReadLine();
        }
    }
}
