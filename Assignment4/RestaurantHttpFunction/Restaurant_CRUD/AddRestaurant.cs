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


            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;
            return new OkObjectResult($"The restaurant {name} is added successfully");
        }
    }
}
