using SimpleService.Core.DomainServices;

namespace SimpleService.Infrastructure
{
    internal class CountersFileRepository : ICountersRepository
    {
        const string filePath = "clicks.txt";


        public int[] Load()
        {
            var lines = File.ReadAllLines(filePath);
            var counters = new int[lines.Length];

            for (var i = 0; i < lines.Length; i++)
            {
                counters[i] = int.Parse(lines[i]);
            }

            return counters;
        }

        public void InitFile()
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "0\n0\n0\n");
            }

        }

        public void Save(int[] counters)
        {
            var updatedLines = new string[counters.Length];

            for (var i = 0; i < counters.Length; i++)
            {
                updatedLines[i] = counters[i].ToString();
            }

            File.WriteAllLines(filePath, updatedLines);
        }

    }
}
