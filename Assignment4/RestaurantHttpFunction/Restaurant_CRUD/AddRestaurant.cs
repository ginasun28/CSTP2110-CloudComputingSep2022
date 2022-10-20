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
            //double rating = double.Parse(req.Query["rating"]); // user's rating 
            //double totalrating = double.Parse(req.Query["totalrating"]); // sum of user's rating
            //int numofrating = int.Parse(req.Query["numofrating"]); // count of user's rating
            //double finalrating = double.Parse(req.Query["finalrating"]); // average of restaurant rating

            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;

            var restaurant = new Restaurant()
            {
                PartitionKey = "1976",
                RowKey = "J&G Chicken",
                Address = "4500 Kingsway, Burnaby, V5H2A9",
                //NumberAndStreet = "4500 Kingsway",
                //City = "Burnaby",
                //PostalCode = "V5H2A9",
                WebsiteUrl = "xxxxxxx",
                PhoneNumber = "778-251xxxx",
                Email = "xxx@gmail.com",
                Rating = 1,
                IsVegetarian = true,
                IsVegan = false,
                IsServeAlchohol = true,
                NameOfCuisine = "Sweet Tomato",
                RelativeCost = 4,
                WorkHour = "11:30 Am to 19:00 pm"

            };
            restaurant.PartitionKey = id;
            restaurant.RowKey = name;
            restaurant.Address = address;
            restaurant.WebsiteUrl = url;
            restaurant.PhoneNumber = phonenum;
            restaurant.Email = email;


            var result = String.Format("Restaurant ID: {0}\nRestaurant Name: {1}\nAddress: {2}\nWebsite URL: {3}\nPhone Number: {4}\nEmail: {5}", id, name, address, url, phonenum, email);

            return new OkObjectResult(result);


            //testResults test = new testResults();
            //test.testRestaurant.PartitionKey = id;
            //test.testRestaurant.RowKey = name;


            //string responseMessage = string.IsNullOrEmpty(name)
            //    ? "Please pass a name in the query string or in the request body for a personalized response."
            //    : $"Hello, {name}. This HTTP triggered function executed successfully.";

            //return new OkObjectResult(responseMessage);
        }
    }
}
