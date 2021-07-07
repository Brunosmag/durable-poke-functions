
namespace Durable.Poke.Functions.Infrastructure.Helpers
{
    public class ContextInputWrapper<T>
    {
        public string MainOrchestrationId { get; }
        public T Data { get; set; }

        public ContextInputWrapper(string mainOrchestrationId, T data)
        {
            MainOrchestrationId = mainOrchestrationId;
            Data = data;
        }
    }

}
