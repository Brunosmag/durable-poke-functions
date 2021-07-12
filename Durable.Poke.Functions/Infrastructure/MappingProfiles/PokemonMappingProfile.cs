using AutoMapper;
using Durable.Poke.Functions.Entities;
using Durable.Poke.Functions.Infrastructure.Contracts;

namespace Durable.Poke.Functions.Infrastructure.MappingProfiles
{
    public class PokemonMappingProfile : Profile
    {
        public PokemonMappingProfile()
        {
            CreateMap<EvolutionChainContract, EvolutionChain>();
            CreateMap<SpeciesContract, Species>();
            CreateMap<EvolutionContract, Evolution>();

            CreateMap<RegionContract, Region>();
            CreateMap<GameIndiceContract, GameIndice>();
            CreateMap<GenerationContract, Generation>();
            CreateMap<LocationContract, Location>();

            CreateMap<BasePokemonContract, Pokemon>();
        }
    }
}
