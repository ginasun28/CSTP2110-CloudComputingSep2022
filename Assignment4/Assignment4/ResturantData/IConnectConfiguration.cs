using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4.ResturantDataSQL
{
    public interface IConnectConfiguration
    {
        string GetConnectionString(string connectionString);
    }
}
