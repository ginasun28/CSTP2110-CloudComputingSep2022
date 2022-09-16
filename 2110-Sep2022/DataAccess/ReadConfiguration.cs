using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;


namespace _2110_Sep2022.DataAccess
{
    public class ReadConfiguration
    {

        public string GetConnectionString(string configName)
        {
            foreach(ConnectionStringSettings settings in ConfigurationManager.ConnectionStrings)
            {
                                                       //bool ignoreCase
                if(string.Compare(settings.Name, configName, true) == 0)
                {
                   return settings.ConnectionString;
                }
               
            }

            return null;
        }
    }
}
