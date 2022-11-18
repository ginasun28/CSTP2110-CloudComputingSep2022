using Azure.Data.Tables;
using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Assignment7.Queue
{
    public class Restaurant : ITableEntity
    {
        [Required]
        public string PartitionKey { get; set; } = default; // restaurant ID
        [Required]
        public string RowKey { get; set; } = default; // restaurant Name
        public DateTimeOffset? Timestamp { get; set; } = default;
        public ETag ETag { get; set; } = default;

        [StringLength(200)]
        public string Address { get; set; }
        [Url]
        public string WebsiteURL { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
