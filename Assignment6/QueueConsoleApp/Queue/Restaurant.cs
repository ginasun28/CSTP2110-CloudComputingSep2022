using Azure.Data.Tables;
using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueConsoleApp.Queue
{
    public class Restaurant : ITableEntity
    {
        public string PartitionKey { get; set; } = default; // restaurant ID
        public string RowKey { get; set; } = default; // restaurant Name
        public DateTimeOffset? Timestamp { get; set; } = default;
        public ETag ETag { get; set; } = default;

        public string Address { get; set; }
        public string WebsiteURL { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
