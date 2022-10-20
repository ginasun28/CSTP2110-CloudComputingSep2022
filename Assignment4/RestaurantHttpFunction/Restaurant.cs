using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;
using Azure;
using Azure.Data.Tables;
using System.Security.Cryptography.X509Certificates;

namespace RestaurantHttpFunction
{
    public class Restaurant : Azure.Data.Tables.ITableEntity
    {
        public string PartitionKey { get; set; } = default;
        public string RowKey { get; set; } = default;
        public DateTimeOffset? Timestamp { get; set; } = default;
        public ETag ETag { get; set; } = default;
        
        //public string NumberAndStreet { get; set; }
        //public string City { get; set; }
        //public string PostalCode { get; set; }
        //public string PostalCode { get; set; }
        public string Address { get; set; }
        public string WebsiteUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        // Rating of each restaurant
        public double Rating { get; set; } // user's rating
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

    }

    public class testResults
    {
        // public DateTime CreatedDate = DateTime.Now;
        public Restaurant testRestaurant = new Restaurant();

    }
}
