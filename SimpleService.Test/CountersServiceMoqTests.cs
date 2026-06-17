using System.Text;
using Moq;
using SimpleService.Core.DomainServices;

namespace SimpleService.Test
{
    public class CountersServiceMoqTests
    {
        [Test]
        public void Run_IncrementsSelectedCounterAndSavesCounters()
        {
            var repository = new Mock<ICountersRepository>();
            var console = new Mock<IConsole>();
            var counters = new[] { 1, 2, 3 };
            int[]? savedCounters = null;

            repository.Setup(x => x.Load()).Returns(counters);
            repository
                .Setup(x => x.Save(It.IsAny<int[]>()))
                .Callback<int[]>(c => savedCounters = c.ToArray());
            console.Setup(x => x.ReadKey()).Returns('B');

            var service = new CountersService(repository.Object, console.Object);

            service.Run();

            repository.Verify(x => x.Load(), Times.Once);
            repository.Verify(x => x.Save(It.IsAny<int[]>()), Times.Once);
            Assert.That(savedCounters, Is.EqualTo(new[] { 1, 3, 3 }));
        }

        [Test]
        public void Run_WritesSelectedLetterAsLetterNotNumberCode()
        {
            var repository = new Mock<ICountersRepository>();
            var console = new Mock<IConsole>();
            var output = new StringBuilder();

            repository.Setup(x => x.Load()).Returns(new[] { 1, 2, 3 });
            console.Setup(x => x.ReadKey()).Returns('B');
            console.Setup(x => x.Write(It.IsAny<string>())).Callback<string>(s => output.Append(s));
            console.Setup(x => x.Write(It.IsAny<char>())).Callback<char>(c => output.Append(c));
            console.Setup(x => x.WriteLine(It.IsAny<string>())).Callback<string>(s => output.AppendLine(s));

            var service = new CountersService(repository.Object, console.Object);

            service.Run();

            Assert.That(output.ToString(), Does.Contain("B: 3"));
            Assert.That(output.ToString(), Does.Not.Contain("66: 3"));
        }
    }
}
