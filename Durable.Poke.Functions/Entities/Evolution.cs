
namespace Durable.Poke.Functions.Entities
{
    public class Evolution
    {
        public int Id { get; set; }
        public bool IsBaby { get; set; }

        public EvolutionChain Chain { get; set; }

        public class EvolutionChain
        {
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
