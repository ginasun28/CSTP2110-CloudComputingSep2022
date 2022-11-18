using System;
using System.Text.Json;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Assignment7;
using Assignment7.Queue;
using Assignment7.Common;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Assignment7_Function
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
