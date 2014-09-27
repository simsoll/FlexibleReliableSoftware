using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("======= Demonstration of Command =======");
            var doc = new Document();

            const string line1 = "Chapter: The command pattern.";
            const string line2 = "Section 1: Problem";
            const string line3 = "Command is a pattern that makes behavior an object.";

            Console.WriteLine("======= First - using method calls =======");
            doc.Write(line1);
            doc.Write(line2);
            doc.Write(line3);
            Console.WriteLine(doc);

            Console.WriteLine("---> Erasing last entered line");
            doc.Erase(line3);
            Console.WriteLine(doc);


            Console.WriteLine("======= Next - command objects assigned to F1..F3 =======");
            doc = new Document();
            // Create the commands
            ICommand write1 = new WriteCommand(doc, line1);
            ICommand write2 = new WriteCommand(doc, line2);
            ICommand write3 = new WriteCommand(doc, line3);
            // Note - nothing has happened to the document yet!

            // assign bindings to the F1 keys
            var f1 = new FKey();
            var f2 = new FKey();
            var f3 = new FKey();
            // assign write commands to the keys
            f1.Assign(write1);
            f2.Assign(write2);
            f3.Assign(write3);

            // next press F1 to F3 and see the result in the document
            f1.Press();
            f2.Press();
            f3.Press();
            Console.WriteLine(doc);

            // reassigning F2
            Console.WriteLine("======= F2 reassigned and pressed =======");
            ICommand write4 = new WriteCommand(doc, "A wrong line");
            f2.Assign(write4);
            f2.Press();
            Console.WriteLine(doc);

            // undoing the last operation
            Console.WriteLine("======= Undo of last insert =======");
            write4.Undo();
            Console.WriteLine(doc);

            Console.WriteLine("======= Next - macro magic =======");
            doc = new Document();
            var macro1 = new WriteCommand(doc, "Hello world!");
            var marco2 = new WriteCommand(doc, "Hello world, again...");
            var marco3 = new WriteCommand(doc, "Hello world, again and again...");

            ICommand macroCommand = new MacroCommand(doc, new[] { macro1, marco2, marco3});
            var macroKey = new FKey();
            macroKey.Assign(macroCommand);
            macroKey.Press();
            Console.WriteLine(doc);
            macroCommand.Undo();
            Console.WriteLine(doc);

            Console.Read();
        }
    }
}
