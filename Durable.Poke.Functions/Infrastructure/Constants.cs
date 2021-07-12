namespace Durable.Poke.Functions.Infrastructure
{
    public class Constants
    {
         public const string GetPokemonTimerEntrypoint = "E_Timer_GetPokemon";

         public const string GetBasePokemonActivity = "A_GetBasePokemonActivity";
         public const string GetRandomPokemonIdActivity = "A_GetRandomPokemonIdActivity";
         public const string GetEvolutionChainActivity = "A_GetEvolutionChainActivity";
         public const string GetLocationActivity = "A_GetLocationActivity";
        public const string MapExternalInformationToEntityActivity = "A_MapExternalInformationToEntityActivity";


        public const string PokeFlowOrchestrator = "O_PokeFlowOrchestrator";
    }
}
