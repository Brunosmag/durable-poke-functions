using Durable.Poke.Functions.ExternalClients;
using Durable.Poke.Functions.Infrastructure;
using Durable.Poke.Functions.Infrastructure.Contracts;
using Durable.Poke.Functions.Infrastructure.Helpers;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System;
using System.Threading.Tasks;

namespace Durable.Poke.Functions.Activities
{
    public class PokemonActivity
    {
        public IPokeClient PokeClient { get; }

        public PokemonActivity(IPokeClient pokeClient)
        {
            PokeClient = pokeClient ?? throw new ArgumentNullException(nameof(pokeClient));
        }

        [FunctionName(Constants.GetRandomPokemonIdActivity)]
        public Task<int> GetRandomPokemonId([ActivityTrigger] IDurableActivityContext context)
        {
            const int firstPokemon = 1;
            const int lastPokemon = 890;
            return Task.FromResult(new Random().Next(firstPokemon, lastPokemon));
        }

        [FunctionName(Constants.GetBasePokemonActivity)]
        public async Task<BasePokemonContract> GetBasePokemonAsync([ActivityTrigger] IDurableActivityContext context)
        {
            var input = context.GetInput<ContextInputWrapper<int>>();

            return await PokeClient.GetAsync(input.Data);
        }
    }
}
