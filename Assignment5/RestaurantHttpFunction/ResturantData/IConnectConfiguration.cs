using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5.ResturantDataSQL
{
    public interface IConnectConfiguration
    {
        string GetConnectionString(string connectionString);
    }
}
