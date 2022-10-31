using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Assignment5.ResturantData;
using Assignment5.Common;


namespace Assignment5.Restaurant_CRUD
{
    // Create function
    public static class AddRestaurant
    {
        private static IStorageConfiguration storageConfiguration = new StorageConfiguration();
        private static string tableName = "Restaurant";

        [FunctionName("Create")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string id = req.Query["id"]; // restaurant id --> Partition Key
            string name = req.Query["name"]; // restaurant name --> Row Key
            string address = req.Query["address"];
            string url = req.Query["url"];
            string phonenum = req.Query["phonenum"];
            string email = req.Query["email"];

            string t1 = req.Query["isVegetarian"];
            bool isVegetarian = bool.Parse(t1 ?? "false"); //if t1 is null give false
            t1 = req.Query["isVegan"];
            bool isVegan = bool.Parse(t1 ?? "false");
            t1 = req.Query["isServeAlchohol"];
            bool isServeAlchohol = bool.Parse(t1 ?? "false");
            string cuisine = req.Query["cuisine"];
            t1 = req.Query["relativeCost"];
            int relativeCost = int.Parse(t1 ?? "0");
            string workHour = req.Query["workHour"];


            var restaurant = new Restaurant()
            {
                PartitionKey = id,
                RowKey = name,
                //NumberAndStreet = "777 Thurlow St",
                //City = "Vancouver",
                //PostalCode = "V6E3V5",
                Address = address,
                WebsiteURL = url,
                PhoneNumber = phonenum,
                Email = email,
                IsVegetarian = isVegetarian,
                IsVegan = isVegan,
                IsServeAlchohol = isServeAlchohol,
                NameOfCuisine = cuisine,
                RelativeCost = relativeCost,
                WorkHour = workHour

            };
            new RestaurantRepository(storageConfiguration, tableName).Add(restaurant);

            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;
            return new OkObjectResult($"The restaurant {name} is added successfully");
        }
    }
}
