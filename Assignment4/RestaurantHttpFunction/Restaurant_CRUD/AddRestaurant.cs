using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace RestaurantHttpFunction.Restaurant_CRUD
{
    // Create function
    public static class AddRestaurant
    {
        [FunctionName("Create")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string id = req.Query["id"]; // restaurant id --> Partition Key
            string name = req.Query["name"]; // restaurant name --> Row Key
            string address = req.Query["address"];
            string url = req.Query["url"];
            string phonenum = req.Query["phonenum"];
            string email = req.Query["eamil"];
            double rating = double.Parse(req.Query["rating"]); // user's rating 
            double totalrating = double.Parse(req.Query["totalrating"]); // sum of user's rating
            int numofrating = Int32.Parse(req.Query["numofrating"]); // count of user's rating
            double finalrating = double.Parse(req.Query["finalrating"]); // average of restaurant rating





            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            testResults test = new testResults();
            test.testRestaurant.PartitionKey = id;
            test.testRestaurant.RowKey = name;
            
            var restaurant 
            

            string responseMessage = string.IsNullOrEmpty(name)
                ? "Please pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
