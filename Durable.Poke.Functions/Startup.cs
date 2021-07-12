using AutoMapper;
using Durable.Poke.Functions.ExternalClients;
using Durable.Poke.Functions.Infrastructure.HttpResponseHandlers;
using Durable.Poke.Functions.Infrastructure.MappingProfiles;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

[assembly: FunctionsStartup(typeof(Durable.Poke.Functions.Startup))]
namespace Durable.Poke.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PokemonMappingProfile());
            });
            var mapper = mapperConfig.CreateMapper();

            builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(PokemonMappingProfile)));
            builder.Services.AddHttpClient();

            builder.Services.AddTransient<IPokeClient, PokeClient>();
            builder.Services.AddTransient<IHttpResponseMessageHandler, HttpResponseMessageHandler>();

        }
    }
}
