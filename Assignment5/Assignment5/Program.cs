using System;
using System;
using Assignment5.ResturantData;
using Assignment5.Common;

namespace Assignment5
{
    class Program
    {
        private IStorageConfiguration storageConfiguration = new StorageConfiguration();
        private static string tableName = "Restaurant";
        static void Main(string[] args)
        {
            // Testing
            var program = new Program();
            // program.AddRestaurant();
            //program.GetRestaurant();
            // program.DeleteRestaurant();
            // program.UpdateRestaurant();
            // program.Query1();

        }

        //public void AddRestaurant()
        //{
        //    var restaurant = new Restaurant()
        //    {
        //        PartitionKey = "1976",
        //        RowKey = "J&G Chicken",
        //        NumberAndStreet = "4500 Kingsway",
        //        City = "Burnaby",
        //        PostalCode = "V5H2A9",
        //        Rating = 1,
        //        IsVegetarian = true,
        //        IsVegan = false,
        //        IsServeAlchohol = true,
        //        NameOfCuisine = "Sweet Tomato",
        //        RelativeCost = 4,
        //        WorkHour = "11:30 Am to 19:00 pm"

        //    };
        //    var restaurant2 = new Restaurant()
        //    {
        //        PartitionKey = "1977",
        //        RowKey = "Joe Fortes Seafood & Chop House",
        //        NumberAndStreet = "777 Thurlow St",
        //        City = "Vancouver",
        //        PostalCode = "V6E3V5",
        //        Rating = 5,
        //        IsVegetarian = false,
        //        IsVegan = true,
        //        IsServeAlchohol = false,
        //        NameOfCuisine = "Seafood",
        //        RelativeCost = 4,
        //        WorkHour = "11:30 Am to 19:00 pm"

        //    };
        //    new RestaurantRepository(this.storageConfiguration, tableName).Add(restaurant);
        //    new RestaurantRepository(this.storageConfiguration, tableName).Add(restaurant2);

        //}

        public void GetRestaurant()
        {
            // get restaurant
            var restaurant = new RestaurantRepository(this.storageConfiguration, tableName).Get("1973", "J&G Chicken");
            Console.WriteLine(restaurant);
        }

        public void DeleteRestaurant()
        {
            new RestaurantRepository(this.storageConfiguration, tableName).DeleteRestaurant("1973", "J&G Chicken");
        }

        public void UpdateRestaurant()
        {
            var repo = new RestaurantRepository(this.storageConfiguration, tableName);
            var restaurant = repo.Get("1975", "J&G Chicken");
            restaurant.WorkHour = "13:00 pm to 7:00 pm";
            // restaurant.PostalCode = "V5H2A9";
            repo.UpdateRestaurant(restaurant);
        }

        public void Query1()
        {
            var restaurants = new RestaurantRepository(this.storageConfiguration, tableName)
                .Query("Burnaby");

            foreach (var restaurant in restaurants)
            {
                Console.WriteLine(restaurant);
            }
        }

        //public void Query2()
        //{
        //    var restaurants = new RestaurantRepository(this.storageConfiguration, tableName)
        //        .Query("Burnaby", "J&G Chicken");

        //    foreach (var restaurant in restaurants)
        //    {
        //        Console.WriteLine(string.Format("City: {0}\nRestaurant Name: {1}\nCuisine: {2}", restaurant.City, restaurant.PartitionKey));
        //    }
        //}

        //public void Query3()
        //{
        //    var restaurants = new RestaurantRepository(this.storageConfiguration, tableName)
        //        .Query("Burnaby", "J&G Chicken", "sweet tomato");


        //    foreach (var restaurant in restaurants)
        //    {
        //        Console.WriteLine(string.Format("City: {0}\nRestaurant Name: {1}\nCuisine: {2}", restaurant.City, restaurant.PartitionKey, restaurant.NameOfCuisine));
        //    }
        //}

    }

}