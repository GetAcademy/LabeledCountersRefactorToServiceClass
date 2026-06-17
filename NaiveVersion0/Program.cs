using NaiveVersion0;

Helpers.ShowMenu();

Helpers.InitFile();

while (true)
{
    var counters = Helpers.ReadCountersFromFile();

    Helpers.ShowValidCounters(counters);

    var selectedLetter = Helpers.AskForLetter();
    var selectedIndex = selectedLetter - 'A';
    counters[selectedIndex]++;

    Helpers.WriteCountersToFile(counters);

    Console.WriteLine($"{selectedLetter}: {counters[selectedIndex]}");
    Console.WriteLine();
}

