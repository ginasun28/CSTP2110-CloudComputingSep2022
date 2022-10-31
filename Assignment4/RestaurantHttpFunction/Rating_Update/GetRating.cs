using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Assignment4.Rating_Update
{
    public static class GetRating
    {

        [FunctionName("GetRating")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];
            string id = req.Query["id"];

            // Connect to Azure Table function
            // Code here

            var rest = "get name and id";

            string responseMessage = $"Rate: {rest}, Total rate: {rest}, Number of Rate: {rest}, Average rate: {rest}";

            return new OkObjectResult(responseMessage);
        }
    }
}
