using Durable.Poke.Functions.ExternalClients;
using Durable.Poke.Functions.Infrastructure;
using Durable.Poke.Functions.Infrastructure.Contracts;
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

        [FunctionName(Constants.GetBasePokemonActivity)]
        public async Task<BasePokemonContract> GetBasePokemonAsync([ActivityTrigger] IDurableActivityContext context)
        {
            var pokemonId = GetRandomIdBetweenFirstAndLastPokemon();

            return await PokeClient.GetAsync(pokemonId);
        }

        private static int GetRandomIdBetweenFirstAndLastPokemon()
        {
            const int firstPokemon = 1;
            const int lastPokemon = 890;
            return new Random().Next(firstPokemon, lastPokemon);
        }
    }
}
