using RabbitMQ.Client;
using TechnicalChallengeMessagingQueuePublisherService.models;
using TechnicalChallengeMessagingQueuePublisherService.csv;
using TechnicalChallengeMessagingQueuePublisherService.queue;
using Newtonsoft.Json.Linq;

string csvDataFileLocation = @"C:\Users\otgbo\Desktop\TestData.csv";
CsvProcessor processor = new CsvProcessor(csvDataFileLocation);
List<Product> products = processor.ConvertCsv<Product>();
Console.WriteLine($"Processed CSV file and found {products.Count} products");

QueueProcessor queueProcessor = new QueueProcessor("localhost", "products");

foreach(Product product in products)
{
    string message = JObject.FromObject(product).ToString();
    queueProcessor.SendMessageToQueue(message);

    Console.WriteLine($"Sent the following message to queue: {message}");
    Console.WriteLine();
}