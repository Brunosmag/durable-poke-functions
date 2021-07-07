using Durable.Poke.Functions.Infrastructure;
using Durable.Poke.Functions.Infrastructure.Contracts;
using Durable.Poke.Functions.Infrastructure.Helpers;
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
                var pokemonId = await context.CallActivityAsync<int>(Constants.GetRandomPokemonIdActivity, null);

                var inputWrapper = new ContextInputWrapper<int>("", pokemonId);
                var teste = await context.CallActivityAsync<BasePokemonContract>(Constants.GetBasePokemonActivity, inputWrapper);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
