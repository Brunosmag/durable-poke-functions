using AutoMapper;
using Durable.Poke.Functions.Entities;
using Durable.Poke.Functions.ExternalClients;
using Durable.Poke.Functions.Infrastructure;
using Durable.Poke.Functions.Infrastructure.Contracts;
using Durable.Poke.Functions.Infrastructure.Helpers;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Durable.Poke.Functions.Activities
{
    public class PokemonActivity
    {
        public IPokeClient PokeClient { get; }
        public IMapper Mapper { get; }
        public ITopicClientWrapper<Pokemon> TopicClientWrapper { get; }

        public PokemonActivity(
            IPokeClient pokeClient,
            IMapper mapper,
            ITopicClientWrapper<Pokemon> topicClientWrapper)
        {
            PokeClient = pokeClient ?? throw new ArgumentNullException(nameof(pokeClient));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            TopicClientWrapper = topicClientWrapper ?? throw new ArgumentNullException(nameof(topicClientWrapper));
        }

        [FunctionName(Constants.GetRandomPokemonIdActivity)]
        public Task<int> GetRandomPokemonId([ActivityTrigger] IDurableActivityContext context)
        {
            const int firstPokemon = 1;
            const int lastPokemon = 150;
            return Task.FromResult(new Random().Next(firstPokemon, lastPokemon));
        }

        [FunctionName(Constants.GetBasePokemonActivity)]
        public async Task<BasePokemonContract> GetBasePokemonAsync([ActivityTrigger] IDurableActivityContext context)
        {
            var input = context.GetInput<ContextInputWrapper<int>>();

            return await PokeClient.GetPokemonBaseDataAsync(input.Data);
        }

        [FunctionName(Constants.GetEvolutionChainActivity)]
        public async Task<EvolutionContract> GetEvolutionChainActivityAsync([ActivityTrigger] IDurableActivityContext context)
        {
            var input = context.GetInput<ContextInputWrapper<int>>();

            return await PokeClient.GetEvolutionChainAsync(input.Data);
        }

        [FunctionName(Constants.GetLocationActivity)]
        public async Task<LocationContract> GetLocationsActivityAsync([ActivityTrigger] IDurableActivityContext context)
        {
            var input = context.GetInput<ContextInputWrapper<int>>();

            return await PokeClient.GetLocationsAsync(input.Data);
        }

        [FunctionName(Constants.MapExternalInformationToEntityActivity)]
        public Pokemon MapPokemon([ActivityTrigger] IDurableActivityContext context)
        {
            var input = context.GetInput<ContextInputWrapper<Tuple<BasePokemonContract, EvolutionContract, LocationContract>>>();

            var pokemon = Mapper.Map<Pokemon>(input.Data.Item1);
            pokemon.WithEvolution(Mapper.Map<Evolution>(input.Data.Item2));
            pokemon.WithLocation(Mapper.Map<Location>(input.Data.Item3));

            return pokemon;
        }

        [FunctionName(Constants.PublishToServiceBusActivity)]
        public async Task PublishPokemonToServiceBus([ActivityTrigger] IDurableActivityContext context)
        {
            var input = context.GetInput<ContextInputWrapper<Pokemon>>();

            await TopicClientWrapper.SendAsync(input.Data);
        }
    }
}
