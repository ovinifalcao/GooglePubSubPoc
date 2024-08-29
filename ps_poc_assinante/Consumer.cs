using Google.Api.Gax;
using Google.Cloud.PubSub.V1;

namespace ps_poc_assinante
{
    public class Consumer
    {
        public async Task ReciveMessage(SubscriptionName subscriptionName)
        {
            SubscriberClient subscriber = await new SubscriberClientBuilder
            {
                SubscriptionName = subscriptionName,
                EmulatorDetection = EmulatorDetection.EmulatorOnly
            }.BuildAsync();
            List<PubsubMessage> receivedMessages = new List<PubsubMessage>();

            await subscriber.StartAsync((msg, cancellationToken) =>
            {
                receivedMessages.Add(msg);
                Console.WriteLine($"Received message {msg.MessageId} published at {msg.PublishTime.ToDateTime()}");
                Console.WriteLine($"Text: '{msg.Data.ToStringUtf8()}'");

                subscriber.StopAsync(TimeSpan.FromSeconds(15));
                return Task.FromResult(SubscriberClient.Reply.Ack);
            });
        }
    }
}
