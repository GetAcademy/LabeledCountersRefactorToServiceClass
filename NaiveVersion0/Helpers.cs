using System.Diagnostics.Metrics;

namespace NaiveVersion0
{
    internal class Helpers
    {
        const string filePath = "clicks.txt";
        public static void ShowValidCounters(int[] counters)
        {
            Console.Write("Gyldige tellere: ");

            for (var i = 0; i < counters.Length; i++)
            {
                var letter = (char)('A' + i);
                Console.Write(letter);

                if (i < counters.Length - 1)
                {
                    Console.Write(", ");
                }
            }
        }

        public static int[] ReadCountersFromFile()
        {
            var lines = File.ReadAllLines(filePath);
            var counters = new int[lines.Length];

            for (var i = 0; i < lines.Length; i++)
            {
                counters[i] = int.Parse(lines[i]);
            }

            return counters;
        }

        public static void InitFile()
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "0\n0\n0\n");
            }

        }

        public static void WriteCountersToFile(int[] counters)
        {
            var updatedLines = new string[counters.Length];

            for (var i = 0; i < counters.Length; i++)
            {
                updatedLines[i] = counters[i].ToString();
            }

            File.WriteAllLines(filePath, updatedLines);
        }

        public static char AskForLetter()
        {
            Console.WriteLine();
            Console.Write("Trykk teller: ");

            var keyInfo = Console.ReadKey(true);
            Console.WriteLine();

            var selectedLetter = char.ToUpper(keyInfo.KeyChar);
            return selectedLetter;
        }

        public static void ShowMenu()
        {
            Console.WriteLine("Klikkteller");
            Console.WriteLine("Hver linje i clicks.txt er én teller.");
            Console.WriteLine("Linje 1 = A, linje 2 = B, linje 3 = C, osv.");
            Console.WriteLine("Trykk Escape for å avslutte.");
            Console.WriteLine();
        }
    }
}
