using Google.Api.Gax;
using Google.Api.Gax.ResourceNames;
using Google.Cloud.PubSub.V1;

namespace ps_poc_assinante
{
    public class StructureCreator
    {
        private async Task<SubscriberServiceApiClient> CreateSubscriberService()
        {
            SubscriberServiceApiClient subscriberService = await new SubscriberServiceApiClientBuilder
            {
                EmulatorDetection = EmulatorDetection.EmulatorOrProduction
            }.BuildAsync();

            return subscriberService;
        }

        public async Task<SubscriptionName> CreateSubscription(string projectId, string topicId, string subscriptionId)
        {
            SubscriptionName subscriptionName = new SubscriptionName(projectId, subscriptionId);
            ProjectName projectName = ProjectName.FromProject(projectId);
            TopicName topicName = new TopicName(projectId, topicId);

            var subscriber = await CreateSubscriberService();
            IEnumerable<Subscription> topicNames = subscriber.ListSubscriptions(projectName);

            if (topicNames.Any(x => x.SubscriptionName == subscriptionName)) return subscriptionName;
            subscriber.CreateSubscription(subscriptionName, topicName, pushConfig: null, ackDeadlineSeconds: 60);
            return subscriptionName;
        }
    }
}
