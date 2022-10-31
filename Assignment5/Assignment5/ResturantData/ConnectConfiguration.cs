using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Assignment5.ResturantData
{
    public class ConnectConfiguration : IConnectConfiguration
    {
        public string GetConnectionString(string configName)
        {
            foreach (ConnectionStringSettings settings in ConfigurationManager.ConnectionStrings)
            {
                if (string.Compare(settings.Name, configName, true) == 0)
                {
                    return settings.ConnectionString;
                }
            }
            return null;
        }
    }
}
