using Durable.Poke.Functions.Infrastructure.Contracts;
using System.Threading.Tasks;

namespace Durable.Poke.Functions.ExternalClients
{
    public interface IPokeClient
    {
        Task<BasePokemonContract> GetPokemonBaseDataAsync(int pokemonId);

        Task<EvolutionContract> GetEvolutionChainAsync(int pokemonId);

        Task<CharacteristcContract> GetCharacteristicAsync(int pokemonId);
    }
}
