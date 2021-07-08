using Newtonsoft.Json;

namespace Durable.Poke.Functions.Infrastructure.Contracts
{
    public class Evolution
    {
        public int Id { get; set; }

        [JsonProperty("is_baby")]
        public bool IsBaby { get; set; }

        public EvolutionChain Chain { get; set; }

        public class EvolutionChain
        {
            [JsonProperty("is_baby")]
            public bool IsBaby { get; set; }
            public Species Species { get; set; }
        }

        public class Species
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }
    }
}
