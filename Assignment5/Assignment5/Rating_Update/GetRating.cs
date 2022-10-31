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
    public static class GetRating
    {
        private static IStorageConfiguration storageConfiguration = new StorageConfiguration();
        private static string tableName = "Restaurant";

        [FunctionName("GetRating")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];
            string id = req.Query["id"];

            var repo = new RestaurantRepository(storageConfiguration, tableName);
            var rest = repo.Get(id, name);

            string responseMessage = $"Rate: {rest.Rating}, Total rate: {rest.TotalRating}, Number of Rate: {rest.NumberOfRating}, Average rate: {rest.TotalRating / rest.NumberOfRating}";

            return new OkObjectResult(responseMessage);
        }
    }
}
