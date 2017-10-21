using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IndexOfLetters
{
    class IndexOfLetters
    {
        static char[] GenerateArrayOfLetters()
        {
            List<char> letters = new List<char>();

            for (char i = 'a'; i <= 'z'; i++)
            {
                letters.Add(i);
            }

            return letters.ToArray();
        }

        static void CleanOutputFile(string path)
        {
            using (System.IO.StreamWriter file = new StreamWriter(path, false))
            {
                file.Write(String.Empty);
            }
        }

        static void Main(string[] args)
        {
            char[] letters = GenerateArrayOfLetters();

            string path = @"C:\Users\Aleksandur\Desktop\Homeworks\Files-Directories-and-Exceptions-Exercises\IndexOfLetters\input.txt";

            string[] lines = File.ReadAllLines(path);

            string outputPath = @"C:\Users\Aleksandur\Desktop\Homeworks\Files-Directories-and-Exceptions-Exercises\IndexOfLetters\output.txt";

            CleanOutputFile(outputPath);

            foreach (string line in lines)
            {
                char[] inputWord = line.ToCharArray();

                using (System.IO.StreamWriter file = new StreamWriter(outputPath, true))
                {
                    for (int i = 0; i < inputWord.Length; i++)
                    {
                        file.WriteLine("{0} -> {1}", inputWord[i], Array.IndexOf(letters, inputWord[i]));
                    }
                    file.WriteLine();
                }
            }
        }
    }
}
