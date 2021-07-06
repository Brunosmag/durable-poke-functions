namespace Durable.Poke.Functions.Infrastructure.Contracts
{
    public class BasePokemonContract
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Base_experience { get; set; }
        public int Height { get; set; }
        public bool Is_default { get; set; }
        public int Order { get; set; }
        public int Weight { get; set; }
        public string Location_area_encounters { get; set; }
    }
}
