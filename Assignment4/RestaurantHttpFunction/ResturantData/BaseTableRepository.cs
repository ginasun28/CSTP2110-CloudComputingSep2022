using Azure.Data.Tables;
using Assignment4.Common;


namespace Assignment4.ResturantData
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
