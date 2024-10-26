using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace MyApp;

internal class Program
{
    static void Main(string[] args)
    {
        string directory = args[0] ?? @".\XmlSharpFiles";

        foreach (string filePath in Directory.EnumerateFiles(directory).Where(x => x[^3..^0] is ['x', 'm', 'l']))
        {
            Console.WriteLine(filePath);
        }
    }
}