using Azure;
using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2.ResturantData
{
    public class Restaurant : ITableEntity
    {
        public string PartitionKey { get; set; } = default; // restaurant ID
        public string RowKey { get; set; } = default; // restaurant Name
        public DateTimeOffset? Timestamp { get; set; } = default;
        public ETag ETag { get; set; } = default;

        public string NumberAndStreet { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int Rating { get; set; }
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
            return String.Format("Restaurant ID: {0}\nRestaurant Name: {1}\nAddress: {2}, {3}, {4}\nRating: {5}\nHave Vegetarain: {6}\nHave Vegan: {7}\n" +
            "Have Serve Alchohol: {8}\nCuisine: {9}\nRelative Cost: {10}\nWork hour: {11}",
            this.PartitionKey, this.RowKey, this.NumberAndStreet, this.City, this.PostalCode, this.Rating, toYesNo(this.IsVegetarian),
            toYesNo(this.IsVegan), toYesNo(this.IsServeAlchohol), this.NameOfCuisine, this.RelativeCost, this.WorkHour);
        }

        public int CompareTo(Restaurant r)
        {
            Console.WriteLine(this.Rating - r.Rating);
            return this.Rating - r.Rating;
        }

    }


}
