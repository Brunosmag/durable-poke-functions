using Newtonsoft.Json;
using System.Collections.Generic;

namespace Durable.Poke.Functions.Infrastructure.Contracts
{
    public class CharacteristcContract
    {
        public IReadOnlyCollection<PokemonDescription> Descriptions { get; set; }

        [JsonProperty("highest_stat")]
        public HighestStatus HighestStat { get; set; }


        public class HighestStatus
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }

        public class PokemonDescription
        {
            public string Description { get; set; }
            public Language Language { get; set; }
        }

        public class Language
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }

    }
}
