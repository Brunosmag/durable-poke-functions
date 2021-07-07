using Durable.Poke.Functions.Infrastructure.Contracts;
using System.Threading.Tasks;

namespace Durable.Poke.Functions.ExternalClients
{
    public interface IPokeClient
    {
        Task<BasePokemonContract> GetAsync(int pokemonId);
    }
}
