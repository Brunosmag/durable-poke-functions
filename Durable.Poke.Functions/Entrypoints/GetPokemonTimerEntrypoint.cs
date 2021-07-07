using Durable.Poke.Functions.Infrastructure;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Durable.Poke.Functions.Entrypoints
{
    public class GetPokemonTimerEntrypoint
    {
        [FunctionName(Constants.GetPokemonTimerEntrypoint)]
        public async Task GetPokemonAsync(
            [TimerTrigger("0 0 * * * *", RunOnStartup = true)] TimerInfo myTimer,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger logger)
        {
            var instanceId = await starter.StartNewAsync(Constants.PokeFlowOrchestrator);

            logger.LogInformation($"Started orchestration with ID = '{instanceId}'.");
        }
    }
}
