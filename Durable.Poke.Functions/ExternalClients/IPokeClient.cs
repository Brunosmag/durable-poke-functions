using Durable.Poke.Functions.Infrastructure.Contracts;
using System.Threading.Tasks;

namespace Durable.Poke.Functions.ExternalClients
{
    public interface IPokeClient
    {
        Task<BasePokemonContract> GetPokemonBaseDataAsync(int pokemonId);

        Task<Evolution> GetEvolutionChainAsync(int pokemonId);
    }
}
