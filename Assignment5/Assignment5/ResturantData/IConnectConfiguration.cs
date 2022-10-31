using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5.ResturantData
{
    public interface IConnectConfiguration
    {
        string GetConnectionString(string connectionString);
    }
}
