using System.Collections.Generic;

namespace Durable.Poke.Functions.Entities
{
    public class Location
    {
        public IReadOnlyCollection<GameIndice> GameIndices { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public Region Region { get; set; }
    }

    public class Region
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class GameIndice
    {
        public int GameIndex { get; set; }
        public Generation Generation { get; set; }
    }

    public class Generation
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
