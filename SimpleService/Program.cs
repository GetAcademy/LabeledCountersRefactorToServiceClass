using SimpleService;
using SimpleService.Infrastructure;

Console.WriteLine("Klikkteller");
Console.WriteLine("Hver linje i clicks.txt er én teller.");
Console.WriteLine("Linje 1 = A, linje 2 = B, linje 3 = C, osv.");
Console.WriteLine("Trykk Escape for å avslutte.");
Console.WriteLine();

var appConsole = new AppConsole();
var countersFileRepository = new CountersFileRepository();
countersFileRepository.InitFile();
var countersService = new CountersService(countersFileRepository, appConsole);

while (true)
{
    countersService.Run();
}