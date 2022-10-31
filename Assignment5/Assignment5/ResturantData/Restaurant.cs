using Azure;
using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5.ResturantData
{
    public class Restaurant : ITableEntity
    {
        //public Guid Id { get; set; } = Guid.NewGuid();
        public string PartitionKey { get; set; } = default; // restaurant ID
        public string RowKey { get; set; } = default; // restaurant Name
        public DateTimeOffset? Timestamp { get; set; } = default;
        public ETag ETag { get; set; } = default;

        //public string NumberAndStreet { get; set; }
        //public string City { get; set; }
        //public string PostalCode { get; set; }

        public string Address { get; set; }
        public string WebsiteURL { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        // Rating of each restaurant
        public string Rating { get; set; } // user's rating
        public double TotalRating { get; set; } // sum of user's rating
        public int NumberOfRating { get; set; } //  count of user's rating
        public double RestaurantRating { get; set; } // sum of rating divide count of user's rating

        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
        public bool IsServeAlchohol { get; set; }
        public string NameOfCuisine { get; set; }
        public int RelativeCost { get; set; }
        public string WorkHour { get; set; }

        // Convert bool to string (true/false convert to yes/no)
        private string toYesNo(bool b)
        {
            return b ? "Yes" : "None";
        }

        // Replaces items in a string with the string representation of a specified object.
        public override string ToString()
        {
            return String.Format("Restaurant ID: {0}\nRestaurant Name: {1}\nAddress: {2}\nRating: {5}\nHave Vegetarain: {6}\nHave Vegan: {7}\n" +
            "Have Serve Alchohol: {8}\nCuisine: {9}\nRelative Cost: {10}\nWork hour: {11}",
            this.PartitionKey, this.RowKey, this.Rating, toYesNo(this.IsVegetarian),
            toYesNo(this.IsVegan), toYesNo(this.IsServeAlchohol), this.NameOfCuisine, this.RelativeCost, this.WorkHour);
        }

        public int CompareTo(Restaurant r)
        {
            Console.WriteLine(this.TotalRating - r.TotalRating);
            return (int)(this.TotalRating - r.TotalRating);
        }

    }

}


}
