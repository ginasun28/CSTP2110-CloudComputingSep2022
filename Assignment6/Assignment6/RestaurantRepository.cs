using QueueConsoleApp.Common;
using QueueConsoleApp.Queue;
using Azure;
using Azure.Data.Tables;
using System.Collections.Generic;


namespace Assignment6
{
    public class RestaurantRepository : BaseTableRepository
    {
        public RestaurantRepository(IStorageConfiguration storageConfiguration, string tableName)
            : base(storageConfiguration, tableName)
        {
        }

        // Add a table entity of type restaurant into table
        public void Add(Restaurant restaurant)
        {               
            var tableClient = GetTableClient();

            var res = tableClient.AddEntity<Restaurant>(restaurant);
        }

        // Get the specified table entity of type Restaurant <ID(partition key) and name(row key)>
        public Restaurant Get(string restaurantID, string restaurantName)
        {
            var tableClient = GetTableClient();

            var restaurant = tableClient.GetEntity<Restaurant>(
                partitionKey: restaurantID,
                rowKey: restaurantName
                );

            return restaurant;
        }

        // Get the restaurant elements by ID(partition key) and name(row key) from table
        //public Restaurant GetRestaurant(string restaurantID, string restaurantName)
        //{
        //    var tableClient = GetTableClient();

        //    var restaurant = tableClient.GetEntity<Restaurant>(
        //        partitionKey: restaurantID,
        //        rowKey: restaurantName
        //        );

        //    return restaurant;
        //}

        // Delete restaurant by ID and name
        public void DeleteRestaurant(string restaurantID, string restaurantName)
        {
            // Connect the table
            var tableClient = GetTableClient();
            // Delete the specified table entity
            tableClient.DeleteEntity(restaurantID, restaurantName);
        }

        // Update restaurants information
        public void UpdateRestaurant(Restaurant restaurant)
        {
            var tableClient = GetTableClient();
            //                                               ETage: look up restaurant
            tableClient.UpdateEntity<Restaurant>(restaurant, ETag.All, TableUpdateMode.Replace);
            // update restaurant all information
        }
    }
}
