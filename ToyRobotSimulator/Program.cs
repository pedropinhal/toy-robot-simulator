using System;
using System.Collections.Generic;
using System.IO;
using ToyRobotSimulator.Business;

namespace ToyRobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = ReadCommandsFromFile("Samples.txt");
            var driver = new RobotDriver(new Robot(new Map()));

            foreach (var command in commands)
            {
                if (!string.IsNullOrEmpty(command))
                {
                    driver.AddCommand(command);
                }
            }

            driver.Drive();
            driver.Reports.ForEach(r => Console.WriteLine(r));
            driver.Reset();
        }

        private static IList<string> ReadCommandsFromFile(string filename)
        {
            var result = new List<string>();

            try
            {
                // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;
                    // Read the stream to a string, and write the string to the console.
                    while ((line = sr.ReadLine()) != null)
                    {
                        result.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return result;
        }
    }
}
