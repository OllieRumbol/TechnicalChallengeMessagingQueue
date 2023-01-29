using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;

namespace TechnicalChallengeMessagingQueuePublisherService.queue;

public class QueueProcessor
{
    private string HostName;
    private string QueueName;

    public QueueProcessor(string hostName, string queueName)
    {
        HostName = hostName;
        QueueName = queueName;
    }

    public void SendMessageToQueue(string message)
    {
        ConnectionFactory factory = new ConnectionFactory
        {
            HostName = HostName
        };

        using (IConnection connection = factory.CreateConnection())
        using (IModel channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: QueueName,
                              durable: false,
                              exclusive: false,
                              autoDelete: false,
                              arguments: null);

            Byte[] body = Encoding.UTF8.GetBytes(message);

             channel.BasicPublish(exchange: "",
             routingKey: QueueName,
             basicProperties: null,
             body: body);
        }
    }
}
