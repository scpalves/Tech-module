using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MostFrequentNumber
{
    class MostFrequentNumber
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Aleksandur\Desktop\Homeworks\Files-Directories-and-Exceptions-Exercises\MostFrequentNumber\input.txt";

            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {

                int[] array = line.Split(' ').Select(int.Parse).ToArray();


                int numberCounter = 0;

                int maxNumberCounter = 0;
                int mostFrequentNumber = 0;

                foreach (int currendNumber in array)
                {
                    for (int j = 0; j < array.Length; j++)
                    {
                        if (array[j] == currendNumber)
                        {
                            numberCounter++;
                        }
                    }
                    if (numberCounter > maxNumberCounter)
                    {
                        maxNumberCounter = numberCounter;
                        mostFrequentNumber = currendNumber;

                    }
                    numberCounter = 0;
                }

                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"C:\Users\Aleksandur\Desktop\Homeworks\Files-Directories-and-Exceptions-Exercises\MostFrequentNumber\output.txt", true))
                {
                    file.WriteLine(mostFrequentNumber);
                }
            }
        }
    }
}
