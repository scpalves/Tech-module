using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;


namespace AMinerTask
{
    class AMinerTask
    {
        private static string path = @"C:\Users\Aleksandur\Desktop\Homeworks\Files-Directories-and-Exceptions-Exercises\AMinerTask\";

        static Dictionary<string, string> resources = new Dictionary<string, string> { };

        static void AddResources(string resource, string quantity)
        {
            if (resources.ContainsKey(resource))
            {
                BigInteger currQuantity = BigInteger.Parse(resources[resource]);

                BigInteger newQuantity = currQuantity + (BigInteger.Parse(quantity));

                resources[resource] = newQuantity.ToString();
            }
            else
            {
                resources.Add(resource, quantity);
            }
        }

        static void PrintResources()
        {
            foreach (KeyValuePair<string, string> pair in resources)
            {
                WriteToFile($"{pair.Key} -> {pair.Value}");
            }
            WriteToFile(String.Empty);
        }

        static void WriteToFile(string text)
        {
            using (StreamWriter writer = new StreamWriter(path + "output.txt", true))
            {
                writer.WriteLine(text);
            }
        }

        static void CleanOutputFile()
        {
            using (StreamWriter writer = new StreamWriter(path + "output.txt", false))
            {
                writer.Write(String.Empty);
            }
        }

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(path + "input.txt");

            int resourceIndex = 0;
            int quantityIndex = 1;

            while (lines[resourceIndex] != "stop")
            {
                AddResources(lines[resourceIndex], lines[quantityIndex]);
                resourceIndex += 2;
                quantityIndex += 2;
            }

            CleanOutputFile();

            PrintResources();
        }
    }
}
