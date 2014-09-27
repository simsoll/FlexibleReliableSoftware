using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("======= Demonstration of Builder =======");
            var wp = new WordProcessor();

            // This code act as the client role that
            // creates the concrete builders and instruct
            // the director to construct objects.
            var asciiBuilder = new AsciiBuilder();
            wp.Construct(asciiBuilder);
            Console.WriteLine("--- The ASCII Builder output ---");
            Console.WriteLine(asciiBuilder.GetResult());

            var htmlBuilder = new HtmlBuilder();
            wp.Construct(htmlBuilder);
            Console.WriteLine("--- The HTML Builder ---");
            Console.WriteLine(htmlBuilder.GetResult());

            var countBuilder = new CountBuilder();
            wp.Construct(countBuilder);
            Console.WriteLine("--- Counting types ---");
            Console.WriteLine("Sections   : " + countBuilder.GetSectionCount());
            Console.WriteLine("Subcections: " + countBuilder.GetSubSectionCount());
            Console.WriteLine("Paragraphs : " + countBuilder.GetParagraphCount());

            var xmlBuilder = new XmlBuilder();
            wp.Construct(xmlBuilder);
            Console.WriteLine("--- The XML Builder ---");
            Console.WriteLine(xmlBuilder.GetResult());

            var wordCountBuilder = new WordCountBuilder();
            wp.Construct(wordCountBuilder);
            Console.WriteLine("-- Counting words --");
            Console.WriteLine("Number of words: " + wordCountBuilder.GetWordCount());

            Console.Read();
        }
    }
}             
