using System;

namespace Durable.Poke.Functions.Entities
{
    public class Pokemon
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int BaseExperience { get; set; }
        public int Height { get; set; }
        public bool IsDefault { get; set; }
        public int Order { get; set; }
        public int Weight { get; set; }
        public Evolution Evolution { get; set; }
        public Location Location { get; set; }

        public void WithEvolution(Evolution evolution)
        {
            Evolution = evolution ?? throw new ArgumentNullException(nameof(evolution));
        }

        public void WithLocation(Location location)
        {
            Location = location ?? throw new ArgumentException(nameof(location));
        }
    }
}
