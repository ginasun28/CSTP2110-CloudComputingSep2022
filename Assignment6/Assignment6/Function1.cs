using System;
using System.Text.Json;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using QueueConsoleApp;
using QueueConsoleApp.Queue;
using QueueConsoleApp.Common;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Assignment6
{
    public class Function1
    {
        private IStorageConfiguration storageConfiguration = new StorageConfiguration();
        [FunctionName("Function1")]
        public void Run([QueueTrigger("restaurantqueue", Connection = "restaurantqueue")]string myQueueItem, ILogger log)
        {
            var restRep = new RestaurantRepository(storageConfiguration, "Restaurant");
            var restOpt = JsonSerializer.Deserialize<RestaurantOpt>(myQueueItem); 
            if (restOpt.command == "add")
            {
                restRep.Add(restOpt.restaurant);
            }
            else if(restOpt.command == "update")
            {
                restRep.UpdateRestaurant(restOpt.restaurant);
            }
            else if(restOpt.command == "delete")
            {
                restRep.DeleteRestaurant(restOpt.restaurant.PartitionKey, restOpt.restaurant.RowKey);
            }

            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
