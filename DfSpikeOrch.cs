using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Spike.Inventory
{
    public static class DfSpikeOrch
    {
        [FunctionName("DfSpikeOrch")]
        public static async Task<int> RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            string data = context.GetInput<string>();

            var entityId = new EntityId("Counter", "myCounter");
            var proxy = context.CreateEntityProxy<ICounter>(entityId);

            // One-way signal to the entity - does not await a response
            proxy.Add(1);

            // Two-way call to the entity which returns a value - awaits the response
            int currentValue = await proxy.Get();

            return currentValue;
        }

        
        [FunctionName("DfSpikeOrch_HttpStart")]
        public static async Task<HttpResponseMessage> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestMessage req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            string data = await req.Content.ReadAsStringAsync();

            // Function input comes from the request content.
            string instanceId = await starter.StartNewAsync("DfSpikeOrch", null, data);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}