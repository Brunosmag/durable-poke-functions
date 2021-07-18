using Durable.Poke.Functions.Entities;
using System.Threading.Tasks;

namespace Durable.Poke.Functions.ExternalClients
{
    public interface ITopicClientWrapper<T>
    {
        Task SendAsync(T value);
    }
}
