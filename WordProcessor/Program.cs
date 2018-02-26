using System;
using System.IO;
using System.Reflection;

namespace WordProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\testing.txt");
            WordsProcessor processor = new WordsProcessor();
            processor.Process(path);
            Console.ReadKey();
        }
    }
}
