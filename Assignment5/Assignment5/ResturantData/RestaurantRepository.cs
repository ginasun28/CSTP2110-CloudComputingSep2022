using Assignment5;
using Assignment5.Common;
using Azure;
using Azure.Data.Tables;
using System.Collections.Generic;


namespace Assignment5.ResturantData
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

        // Search by city
        //public List<Restaurant> Query(string city)
        //{
        //    var tableClient = GetTableClient();
        //    var restaurants = tableClient.Query<Restaurant>(x => x.City == city);

        //    return sortByRate(restaurants);
        //}

        // Search by city and name
        public List<Restaurant> Query(string name)
        {
            var tableClient = GetTableClient();
            var restaurants = tableClient.Query<Restaurant>(x => x.RowKey == name);

            return sortByRate(restaurants);
        }

        // Search by city, name and cuisine
        public List<Restaurant> Query(string name, string cuisine)
        {
            var tableClient = GetTableClient();
            var restaurants = tableClient.Query<Restaurant>(x => x.RowKey == name && x.NameOfCuisine == cuisine);

            return sortByRate(restaurants); // call the sorting function
        }

        // Sorting by restaurant rating (1 to 5)
        private List<Restaurant> sortByRate(IEnumerable<Restaurant> data)
        {
            var result = new List<Restaurant>();
            foreach (var r in data)
            {
                result.Add(r);
            }
            result.Sort(); // form 1 to 5
            result.Reverse(); // from high to less, 5 to 1
            return result;
        }
    }
}
