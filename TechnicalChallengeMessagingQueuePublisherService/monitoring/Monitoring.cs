namespace TechnicalChallengeMessagingQueuePublisherService.monitoring;

// I guess there are a few different ways you could monitor the health of a queue between microservices
// There are plently of tools to help with this like rabbitmq-diagnostics and rabbitmq_management
// You could write to a noSQL databse the number of read and writes the queue is making but that feels like defeating the point of micro service
// To keep any eye on critical errors logging any execptions to Azure Monitor (AWS CloudWatch) would be a good idea. For now i will just mock this service   
public class Monitoring : IMonitoring
{
    public void LogExcpetion(Exception ex)
    {
        // Call Azure monitor to log exception

        Console.WriteLine(ex.ToString());
    }
}
