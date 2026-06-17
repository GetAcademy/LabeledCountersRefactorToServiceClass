using NaiveVersion0;

Console.WriteLine("Klikkteller");
Console.WriteLine("Hver linje i clicks.txt er én teller.");
Console.WriteLine("Linje 1 = A, linje 2 = B, linje 3 = C, osv.");
Console.WriteLine("Trykk Escape for å avslutte.");
Console.WriteLine();

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

