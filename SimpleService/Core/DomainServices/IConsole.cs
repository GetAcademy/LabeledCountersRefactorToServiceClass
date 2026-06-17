namespace SimpleService.Core.DomainServices
{
    internal interface IConsole
    {
        void WriteLine(string s = "");
        void Write(string s);
        void Write(char c);
        char ReadKey();
    }
}
