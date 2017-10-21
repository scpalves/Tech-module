using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FixEmails
{
    class FixEmails
    {
        private static string path = @"C:\Users\Aleksandur\Desktop\Homeworks\Files-Directories-and-Exceptions-Exercises\FixEmails\";

        static Dictionary<string, string> emails = new Dictionary<string, string> { };

        static void AddEmail(string name, string email)
        {
            if (ValidateEmai(email))
            {
                if (emails.ContainsKey(name))
                {
                    emails[name] = email;
                }
                else
                {
                    emails.Add(name, email);
                }
            }
        }

        static bool ValidateEmai(string email)
        {
            string domainEnd = email.Substring(email.Length - 2);
            if (string.Equals(domainEnd, "us", StringComparison.OrdinalIgnoreCase)
                || string.Equals(domainEnd, "uk", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            return true;
        }

        static void PrintEmails()
        {
            foreach (KeyValuePair<string, string> pair in emails)
            {
                WriteToFile($"{pair.Key} -> {pair.Value}");
            }
            WriteToFile(String.Empty);
        }

        static void TakeInput(out string[] lines)
        {
            lines = File.ReadAllLines(path + "input.txt");
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
            TakeInput(out string[] lines);

            int nameIndex = 0;
            int emailIndex = 1;

            while (lines[nameIndex] != "stop")
            {
                AddEmail(lines[nameIndex], lines[emailIndex]);
                nameIndex += 2;
                emailIndex += 2;
            }

            CleanOutputFile();

            PrintEmails();
        }
    }
}
