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
                //1 - Gera um ID de pokemon de forma determinística.
                var pokemonId = await context.CallActivityAsync<int>(Constants.GetRandomPokemonIdActivity, null);
                var pokemonIdInputWrapper = new ContextInputWrapper<int>(context.InstanceId, pokemonId);

                //2 - Obtem os dados base de um Pokemon através da PokeApi.
                var basePokemon = await context.CallActivityAsync<BasePokemonContract>(Constants.GetBasePokemonActivity, pokemonIdInputWrapper);
                var basePokemonInputWrapper = new ContextInputWrapper<BasePokemonContract>(context.InstanceId, basePokemon);

                //3 - Obtem dados de evolução do Pokemon.
                var evolution = await context.CallActivityAsync<Evolution>(Constants.GetEvolutionChainActivity, basePokemonInputWrapper);
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
