using SimpleService.Core.DomainServices;

namespace SimpleService.Infrastructure
{
    internal class AppConsole : IConsole
    {
        public void WriteLine(string s = "")
        {
            Console.WriteLine(s);
        }

        public void Write(string s)
        {
            Console.Write(s);
        }

        public void Write(char c)
        {
            Console.Write(c);
        }

        public char ReadKey()
        {
            var consoleKeyInfo = Console.ReadKey(true);
            return char.ToUpper(consoleKeyInfo.KeyChar);
        }
    }
}
