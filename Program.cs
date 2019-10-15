using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using org.mariuszgromada.math.mxparser;

namespace c_sharp_test
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = Path.Combine(Directory.GetCurrentDirectory(), "json.json");
            var jobj = JsonConvert.DeserializeObject<JsonStructure>(File.ReadAllText(filename));


            Console.WriteLine("\n\n----TESTING INCLINE SCALING FUNCTIONS----\n\n");
            foreach(KeyValuePair<string, string> entry in jobj.inclineScalingFunctions)
            {
                Console.WriteLine("\nTesting incline {0}: {1}", entry.Key, entry.Value);
                Function f = new Function(entry.Value);
                if (f.checkSyntax()) {
                    var result = f.calculate(2);
                    Console.WriteLine("result for {0}: {1}", entry.Key, result);
                } else {
                    Console.WriteLine("Error parsing {0}, for: {1}", entry.Key, entry.Value);
                    mXparser.consolePrintln(f.getErrorMessage());
                }
            }

            Console.WriteLine("\n\n----TESTING SPEED SCALING FUNCTIONS----\n\n");
            foreach(KeyValuePair<string, string> entry in jobj.speedScalingFunctions)
            {
                Console.WriteLine("\nTesting speed {0}: {1}", entry.Key, entry.Value);
                Function f = new Function(entry.Value);
                if (f.checkSyntax()) {
                    var result = f.calculate(2);
                    Console.WriteLine("result for {0}: {1}", entry.Key, result);
                } else {
                    Console.WriteLine("Error parsing {0}, for: {1}", entry.Key, entry.Value);
                    mXparser.consolePrintln(f.getErrorMessage());
                }
            }

            Console.WriteLine("\n\n----TESTING RESISTANCE SCALING FUNCTIONS----\n\n");
            foreach(KeyValuePair<string, string> entry in jobj.resistanceScalingFunctions)
            {
                Console.WriteLine("\nTesting resistance {0}: {1}", entry.Key, entry.Value);
                Function f = new Function(entry.Value);
                if (f.checkSyntax()) {
                    var result = f.calculate(2);
                    Console.WriteLine("result for {0}: {1}", entry.Key, result);
                } else {
                    Console.WriteLine("Error parsing {0}, for: {1}", entry.Key, entry.Value);
                    mXparser.consolePrintln(f.getErrorMessage());
                }
            }
        }
    }
}
