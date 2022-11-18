using QueueConsoleApp.Common;

namespace QueueConsoleApp.Common
{
    public class StorageConfiguration : IStorageConfiguration
    {
        private static string connectionString = "DefaultEndpointsProtocol=https;AccountName=storageaccountweek2;AccountKey=715EKdkwtfGVZQetfTDWv5ZfNdt0b+5TvobEQBjm39Gi4fQul3S0CS+YgO8T8Tfvb5kpqsXltKsr+AStPqkesg==;EndpointSuffix=core.windows.net";
        public string GetStorageConnectionString()
        {
            return connectionString;
        }
    }
}
