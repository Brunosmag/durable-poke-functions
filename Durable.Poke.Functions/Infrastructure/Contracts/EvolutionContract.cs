using Newtonsoft.Json;

namespace Durable.Poke.Functions.Infrastructure.Contracts
{
    public class EvolutionContract
    {
        public int Id { get; set; }

        [JsonProperty("is_baby")]
        public bool IsBaby { get; set; }

        public EvolutionChainContract Chain { get; set; }

        public class EvolutionChainContract
        {
            [JsonProperty("is_baby")]
            public bool IsBaby { get; set; }

            public SpeciesContract Species { get; set; }
        }

        public class SpeciesContract
        {
            public string Name { get; set; }

            public string Url { get; set; }
        }
    }
}
