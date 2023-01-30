using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalChallengeMessagingQueuePublisherService.queue
{
    public interface IQueueProcessor
    {
        void SendMessageToQueue(string message);
    }
}
