﻿using Durable.Poke.Functions.Entities;
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

                //2 - Obtem os dados base.
                var basePokemon = await context.CallActivityAsync<BasePokemonContract>(Constants.GetBasePokemonActivity, pokemonIdInputWrapper);

                //3 - Obtem dados de evolução.
                var evolution = await context.CallActivityAsync<EvolutionContract>(Constants.GetEvolutionChainActivity, pokemonIdInputWrapper);

                //4 - Obtem a localização.
                var location = await context.CallActivityAsync<LocationContract>(Constants.GetLocationActivity, pokemonIdInputWrapper);

                var mapperTuple = new Tuple<BasePokemonContract, EvolutionContract, LocationContract>(basePokemon, evolution, location);
                var mapperInputWrapper = new ContextInputWrapper<Tuple<BasePokemonContract, EvolutionContract, LocationContract>>(context.InstanceId, mapperTuple);

                var poke = await context.CallActivityAsync<Pokemon>(Constants.MapExternalInformationToEntityActivity, mapperInputWrapper);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
