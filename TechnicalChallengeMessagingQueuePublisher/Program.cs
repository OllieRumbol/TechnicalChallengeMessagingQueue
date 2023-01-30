using RabbitMQ.Client;
using TechnicalChallengeMessagingQueuePublisherService.models;
using TechnicalChallengeMessagingQueuePublisherService.csv;
using TechnicalChallengeMessagingQueuePublisherService.queue;
using Newtonsoft.Json.Linq;
using TechnicalChallengeMessagingQueuePublisherService.monitoring;

string csvDataFileLocation = @"C:\Users\otgbo\Desktop\TestData.csv";
CsvProcessor processor = new CsvProcessor(csvDataFileLocation);
List<Product> products = processor.ConvertCsv<Product>();
Console.WriteLine($"Processed CSV file and found {products.Count} products");

IQueueProcessor queueProcessor = new QueueProcessor("localhost", "products");
IMonitoring monitoring = new Monitoring();

foreach (Product product in products)
{
    string message = JObject.FromObject(product).ToString();
    try
    {
        queueProcessor.SendMessageToQueue(message);

        Console.WriteLine($"Sent the following message to queue: {message}");
        Console.WriteLine();
    }
    catch (Exception ex)
    {
        monitoring.LogExcpetion(ex);
    }
}