using Durable.Poke.Functions.Infrastructure.Contracts;
using System;

namespace Durable.Poke.Functions.Infrastructure.DTOs
{
    public class PokemonDto
    {
        public PokemonDto(
            BasePokemonContract basePokemon, 
            EvolutionContract evolution, 
            LocationContract location)
        {
            BasePokemon = basePokemon ?? throw new ArgumentNullException(nameof(basePokemon));
            Evolution = evolution ?? throw new ArgumentNullException(nameof(evolution));
            Location = location ?? throw new ArgumentNullException(nameof(location));
        }

        public BasePokemonContract BasePokemon { get; private set; }
        public EvolutionContract Evolution { get; private set; }
        public LocationContract Location { get; private set; }
    }
}
