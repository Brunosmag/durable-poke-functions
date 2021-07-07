using Durable.Poke.Functions.Infrastructure;
using Durable.Poke.Functions.Infrastructure.Contracts;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System;
using System.Threading.Tasks;

namespace Durable.Poke.Functions.Orchestrators
{
    public class PokeFlowOrchestrator
    {
        [FunctionName(Constants.PokeFlowOrchestrator)]
        public async Task RunOrchestrator([OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            try
            {
                var teste = await context.CallActivityAsync<BasePokemonContract>(Constants.GetBasePokemonActivity, context);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
