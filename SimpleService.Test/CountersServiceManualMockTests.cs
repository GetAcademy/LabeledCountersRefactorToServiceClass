using System.Text;
using SimpleService.Core.DomainServices;

namespace SimpleService.Test
{
    public class CountersServiceManualMockTests
    {
        [Test]
        public void Run_IncrementsSelectedCounterAndSavesCounters()
        {
            var repository = new CountersRepositoryMock(new[] { 1, 2, 3 });
            var console = new ConsoleMock('B');
            var service = new CountersService(repository, console);

            service.Run();

            Assert.That(repository.LoadWasCalled, Is.True);
            Assert.That(repository.SavedCounters, Is.Not.Null);
            Assert.That(repository.SavedCounters!, Is.EqualTo(new[] { 1, 3, 3 }));
        }

        [Test]
        public void Run_WritesSelectedLetterAsLetterNotNumberCode()
        {
            var repository = new CountersRepositoryMock(new[] { 1, 2, 3 });
            var console = new ConsoleMock('B');
            var service = new CountersService(repository, console);

            service.Run();

            Assert.That(console.Output, Does.Contain("B: 3"));
            Assert.That(console.Output, Does.Not.Contain("66: 3"));
        }

        private sealed class CountersRepositoryMock : ICountersRepository
        {
            private readonly int[] _counters;

            public CountersRepositoryMock(int[] counters)
            {
                _counters = counters;
            }

            public bool LoadWasCalled { get; private set; }

            public int[]? SavedCounters { get; private set; }

            public int[] Load()
            {
                LoadWasCalled = true;
                return _counters;
            }

            public void Save(int[] counters)
            {
                SavedCounters = counters.ToArray();
            }
        }

        private sealed class ConsoleMock : IConsole
        {
            private readonly StringBuilder _output = new();
            private readonly char _keyToRead;

            public ConsoleMock(char keyToRead)
            {
                _keyToRead = keyToRead;
            }

            public string Output => _output.ToString();

            public void WriteLine(string s = "")
            {
                _output.AppendLine(s);
            }

            public void Write(string s)
            {
                _output.Append(s);
            }

            public void Write(char c)
            {
                _output.Append(c);
            }

            public char ReadKey()
            {
                return _keyToRead;
            }
        }
    }
}
