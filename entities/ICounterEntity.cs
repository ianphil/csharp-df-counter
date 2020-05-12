namespace Spike.Inventory
{
    using Newtonsoft.Json;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.DurableTask;

    public interface ICounter
    {
        void Add(int amount);
        Task Reset();
        Task<int> Get();
        void Delete();
    }
}