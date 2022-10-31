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
    public static class UpdateRestaurant
    {
        private static IStorageConfiguration storageConfiguration = new StorageConfiguration();
        private static string tableName = "Restaurant";
        [FunctionName("Update")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string id = req.Query["id"];
            string address = req.Query["address"];
            string name = req.Query["name"];
            string email = req.Query["email"];
            string rate = req.Query["rate"];

            var repo = new RestaurantRepository(storageConfiguration, tableName);

            // Take all data to revise the current data
            var rest = repo.Get(id, name); // keep data not revise
            // 指定修改一個Varilable才會改動數據, 如無改動則數據不會變動
            if (!string.IsNullOrEmpty(address))
            {
                rest.Address = address;
            }
            // 指定修改一個Varilable才會改動數據, 如無改動則數據不會變動
            if (!string.IsNullOrEmpty(email))
            {
                rest.Email = email;
            }

            if (!string.IsNullOrEmpty(rate))
            {
                rest.Rating = rate;
            }

           
            new RestaurantRepository(storageConfiguration, tableName).UpdateRestaurant(rest) ;

            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
