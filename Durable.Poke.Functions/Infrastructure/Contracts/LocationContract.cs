using Newtonsoft.Json;
using System.Collections.Generic;

namespace Durable.Poke.Functions.Infrastructure.Contracts
{
    public class LocationContract
    {

        [JsonProperty("game_indices")]
        public IReadOnlyCollection<GameIndiceContract> GameIndices { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public RegionContract Region { get; set; }      
    }

    public class RegionContract
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class GameIndiceContract
    {
        [JsonProperty("game_index")]
        public int GameIndex { get; set; }
        public GenerationContract Generation { get; set; }
    }

    public class GenerationContract
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
