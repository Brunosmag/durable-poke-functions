using Durable.Poke.Functions.Infrastructure.Contracts;
using Durable.Poke.Functions.Infrastructure.HttpResponseHandlers;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Durable.Poke.Functions.ExternalClients
{
    public class PokeClient : IPokeClient
    {
        public HttpClient HttpClient { get; }
        public IHttpResponseMessageHandler HttpResponseMessageHandler { get; }

        public PokeClient(
            HttpClient httpClient,
            IHttpResponseMessageHandler httpResponseMessageHandler)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            HttpResponseMessageHandler = httpResponseMessageHandler ?? throw new ArgumentNullException(nameof(httpResponseMessageHandler));
        }


        public async Task<BasePokemonContract> GetAsync(int pokemonId)
        {
            var requestUri = $"https://pokeapi.co/api/v2/pokemon/{pokemonId}";

            var response = await GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            return await HttpResponseMessageHandler.HandleResponse<BasePokemonContract>(response);
        }

        public virtual async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            var response = await HttpClient.GetAsync(requestUri);
            return response;
        }
    }
}
