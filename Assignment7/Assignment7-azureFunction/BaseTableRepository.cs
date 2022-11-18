using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Data.Tables;
using Assignment7.Common;

namespace Assignment7_Function
{
    public class BaseTableRepository
    {
        protected IStorageConfiguration storageConfiguration;
        protected string tableName;

        public BaseTableRepository(IStorageConfiguration storageConfiguration, string tableName)
        {
            this.tableName = tableName;
            this.storageConfiguration = storageConfiguration;
        }

        protected TableClient GetTableClient()
        {
            var tableServiceClient = new TableServiceClient(this.storageConfiguration.GetStorageConnectionString());
            var tableClient = tableServiceClient.GetTableClient(tableName: this.tableName);
            tableClient.CreateIfNotExists();

            return tableClient;
        }
    }
}
