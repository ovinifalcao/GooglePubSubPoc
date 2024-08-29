using Google.Api.Gax;
using Google.Cloud.PubSub.V1;

namespace ps_poc_editor
{
    public class Producer
    {
        public async Task SendMessage(string projectId, TopicName topicName, string messageToSend)
        {
            PublisherClient publisher = await new PublisherClientBuilder
            {
                TopicName = topicName,
                EmulatorDetection = EmulatorDetection.EmulatorOnly
            }.BuildAsync();

            await publisher.PublishAsync(messageToSend);
            await publisher.ShutdownAsync(TimeSpan.FromSeconds(15));
        }
    }
}
