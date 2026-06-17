namespace SimpleService.DomainServices
{
    internal interface ICountersRepository
    {
        int[] Load();
        void Save(int[] counters);
    }
}
