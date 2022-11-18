using QueueConsoleApp.Common;
using Azure.Storage.Queues;

namespace QueueConsoleApp.Queue
{
    public class BaseMessageQueueRepository
    {
        protected IStorageConfiguration storageConfiguration;
        protected string queueName;

        public BaseMessageQueueRepository(IStorageConfiguration storageConfiguration, string queueName)
        {
            this.queueName = queueName;
            this.storageConfiguration = storageConfiguration;
        }

        protected QueueClient GetQueueClient()
        {
            var queueClientOptions = new QueueClientOptions()
            {
                MessageEncoding = QueueMessageEncoding.Base64
            };
            return new QueueClient(storageConfiguration.GetStorageConnectionString(), queueName, queueClientOptions);
        }
    }
}
