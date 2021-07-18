using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Durable.Poke.Functions.ExternalClients
{
    public class TopicClientWrapper<T> : ITopicClientWrapper<T> where T : class
    {
        public TopicClient TopicClient { get; }

        public TopicClientWrapper(TopicClient topicClient)
        {
            TopicClient = topicClient ?? throw new ArgumentNullException(nameof(topicClient));
        }


        public async Task SendAsync(T value)
        {
            var serializedMessage = JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var serviceBusMessage = new Message(Encoding.UTF8.GetBytes(serializedMessage));

            await TopicClient.SendAsync(serviceBusMessage);
        }
    }
}
