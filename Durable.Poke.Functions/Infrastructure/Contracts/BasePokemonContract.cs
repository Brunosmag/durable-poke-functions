using Newtonsoft.Json;

namespace Durable.Poke.Functions.Infrastructure.Contracts
{
    public class BasePokemonContract
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonProperty("Base_experience")]
        public int BaseExperience { get; set; }

        public int Height { get; set; }

        [JsonProperty("Is_default")]
        public bool IsDefault { get; set; }

        public int Order { get; set; }

        public int Weight { get; set; }

        [JsonProperty("Location_area_encounters")]
        public string LocationAreaEncounters { get; set; }
    }
}
