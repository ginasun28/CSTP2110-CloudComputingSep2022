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
using System.Collections.Generic;

namespace Assignment5.Rating_Update
{
    public static class AddRating
    {
        private static IStorageConfiguration storageConfiguration = new StorageConfiguration();
        private static string tableName = "Restaurant";

        [FunctionName("AddRating")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post","get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];
            string id = req.Query["id"];

            // convert date to doubke and store in array return to json info
            string rate_str = req.Query["rate"] ;
            if (string.IsNullOrEmpty(rate_str))
            {
                string ignore = "no rate provided, ignore";

                return new OkObjectResult(ignore);
            }
            double rate = double.Parse(rate_str);

            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;

            
            var repo = new RestaurantRepository(storageConfiguration, tableName);
            var rest = repo.Get(id, name);
            // find the data of restaurant then rating of string convert to double value
            var data = JsonConvert.DeserializeObject<List<double>>(rest.Rating??"[]");
            // add rate to data 
            data.Add(rate);
            // convert to json string to save into database
            rest.Rating = JsonConvert.SerializeObject(data);
            // user input will increase one
            rest.NumberOfRating++;
            double s = 0;
            // sum of rating in data
            foreach(var i in data)
            {
                s += i;
            }
            rest.TotalRating = s;
            // re-write date into table(database)
            repo.UpdateRestaurant(rest);

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
