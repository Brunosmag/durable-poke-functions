using Durable.Poke.Functions.Infrastructure;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System.Threading.Tasks;

namespace Durable.Poke.Functions.Entrypoints
{
    public class GetPokemonTimerEntrypoint
    {
        [FunctionName(Constants.GetPokemonTimerEntrypoint)]
        public async Task GetPokemonAsync(
            [TimerTrigger("0 0 * * * *")] TimerInfo myTimer,
            [DurableClient] IDurableOrchestrationClient starter)
        {

        }  
    }
}
