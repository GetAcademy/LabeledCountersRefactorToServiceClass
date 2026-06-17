using SimpleService.DomainServices;

namespace SimpleService
{
    internal class CountersService
    {
        private readonly ICountersRepository _countersRepository;
        private IConsole _console;

        public CountersService(ICountersRepository countersRepository, IConsole console)
        {
            _console = console;
            _countersRepository = countersRepository;
        }

        public void Run()
        {
            var counters = _countersRepository.Load();

            ShowValidCounters(counters);

            var selectedLetter = AskForLetter();
            var selectedIndex = selectedLetter - 'A';
            counters[selectedIndex]++;

            _countersRepository.Save(counters);

            _console.WriteLine($"{selectedLetter}: {counters[selectedIndex]}");
            _console.WriteLine();
        }

        public void ShowValidCounters(int[] counters)
        {
            _console.Write("Gyldige tellere: ");

            for (var i = 0; i < counters.Length; i++)
            {
                var letter = (char)('A' + i);
                _console.Write(letter);

                if (i < counters.Length - 1)
                {
                    _console.Write(", ");
                }
            }
        }

        public int AskForLetter()
        {
            _console.WriteLine();
            _console.Write("Trykk teller: ");

            var selectedLetter = _console.ReadKey();

            _console.WriteLine();

            return selectedLetter;
        }
    }
}
