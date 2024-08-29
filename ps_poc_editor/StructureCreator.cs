using Google.Api.Gax;
using Google.Api.Gax.ResourceNames;
using Google.Cloud.PubSub.V1;

public class StructureCreator
{
    private async Task<PublisherServiceApiClient> CreatePublisherService()
    {
        PublisherServiceApiClient publisherService = await new PublisherServiceApiClientBuilder
        {
            EmulatorDetection = EmulatorDetection.EmulatorOnly,
        }.BuildAsync();

        return publisherService;
    }

    public async Task<TopicName> CreateTopic(string projectId, string topicId)
    {
        var publisher = await CreatePublisherService();
        ProjectName projectName = ProjectName.FromProject(projectId);
        IEnumerable<Topic> topicNames = publisher.ListTopics(projectName);
        TopicName topicName = new TopicName(projectId, topicId);

        if (topicNames.Any(x => x.TopicName == topicName)) return topicName;
        publisher.CreateTopic(topicName);
        return topicName;
    }
}