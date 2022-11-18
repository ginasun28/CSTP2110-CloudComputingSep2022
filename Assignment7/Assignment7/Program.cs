using System;
using System.Text.Json;
using System.Collections.Generic;
using Assignment7.Common;
using System.IO;
using System.ComponentModel.DataAnnotations;
using Assignment7.Queue;

namespace Assignment7
{
    class Program
    {
        private static string queueName = "restaurantqueue";
        private IStorageConfiguration storageConfiguration = new StorageConfiguration();

        static void Main(string[] args)
        {

            //new Program().addRestaurant();
            // new Program().updateRestaurant();
             new Program().deleteRestaurant();


        }

        public void addRestaurant()
        {
            var queueClient = new RestaurantQueueRepository(storageConfiguration, queueName);
            //Restaurant r1 = new Restaurant()
            //{
            //    Address = "Metrotown",
            //    PartitionKey = "001",
            //    RowKey = "Church Chicken",

            //};
            Restaurant r1 = new Restaurant()
            {
                Address = "Richmond",
                PartitionKey = "003",
                RowKey = "EA",
 
            };

            if (ValidateObject(r1))
            {
                var ro = new RestaurantOpt()
                {
                    command = "add",
                    restaurant = r1,
                };

                if (ValidateObject(ro))
                {
                    queueClient.Enqueue(ro);
                }
                
            }


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

            if (ValidateObject(r1))
            {
                var ro = new RestaurantOpt()
                {
                    command = "update",
                    restaurant = r1,
                };

                if (ValidateObject(ro))
                {
                    queueClient.Enqueue(ro);
                }

            }

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

            // if object(=send to queue) is invalidated won't change queue
            if (ValidateObject(r1))
            {
                var ro = new RestaurantOpt()
                {
                    command = "delete",
                    restaurant = r1,
                };

                if (ValidateObject(ro))
                {
                    queueClient.Enqueue(ro);
                }

            }

        }

        // check if object(=send to queue) validate or not
        private bool ValidateObject(Object rest)
        {
            var validationContext = new ValidationContext(rest);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(rest, validationContext, validationResults, true);

            if (!isValid)
            {
                foreach (var result in validationResults)
                {
                    Console.WriteLine($"validation result = {result.ErrorMessage} ");
                }
            }
            return isValid;

        }

       

    }

   
}