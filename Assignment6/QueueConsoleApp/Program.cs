using System;
using System.Text.Json;
using System.Collections.Generic;
using QueueConsoleApp.Common;
using System.IO;
using System.ComponentModel.DataAnnotations;
using QueueConsoleApp.Queue;

namespace QueueConsoleApp
{
    class Program
    {
        private static string queueName = "restaurantqueue";
        private IStorageConfiguration storageConfiguration = new StorageConfiguration();

        static void Main(string[] args)
        {

            //new Program().addRestaurant();
            //new Program().updateRestaurant();
            new Program().deleteRestaurant();
       
            
        }

        public void addRestaurant()
        {
            var queueClient = new RestaurantQueueRepository(storageConfiguration, queueName);
            Restaurant r1 = new Restaurant()
            {
                Address = "Metrotown",
                PartitionKey = "001",
                RowKey = "Church Chicken",

            };
            queueClient.Enqueue(new RestaurantOpt()
            {
                command = "add",
                restaurant = r1,
            });

        }

        public void updateRestaurant()
        {
            var queueClient = new RestaurantQueueRepository(storageConfiguration, queueName);
            Restaurant r1 = new Restaurant()
            {
                Address = "Vancouver",
                PartitionKey = "001",
                RowKey = "Church Chicken",

            };
            queueClient.Enqueue(new RestaurantOpt()
            {
                command = "update",
                restaurant = r1,
            });

        }

        public void deleteRestaurant()
        {
            var queueClient = new RestaurantQueueRepository(storageConfiguration, queueName);
            Restaurant r1 = new Restaurant()
            {
                Address = "Vancouver",
                PartitionKey = "001",
                RowKey = "Church Chicken",

            };
            queueClient.Enqueue(new RestaurantOpt()
            {
                command = "delete",
                restaurant = r1,
            });

        }

    }

   
}