using Durable.Poke.Functions.ExternalClients;
using Durable.Poke.Functions.Infrastructure.HttpResponseHandlers;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Durable.Poke.Functions.Startup))]
namespace Durable.Poke.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();

            builder.Services.AddTransient<IPokeClient, PokeClient>();
            builder.Services.AddTransient<IHttpResponseMessageHandler, HttpResponseMessageHandler>();

        }
    }
}
