namespace SimpleService.Core.DomainServices
{
    internal interface ICountersRepository
    {
        int[] Load();
        void Save(int[] counters);
    }
}
