using System.Net.Http;
using System.Threading.Tasks;

namespace Durable.Poke.Functions.Infrastructure.HttpResponseHandlers
{
    public interface IHttpResponseMessageHandler
    {
        Task<T> HandleResponse<T>(HttpResponseMessage content);
    }
}
