using System;
using System.Collections.Generic;
using System.Text;

namespace _2110_Sep2022.DataAccess
{
    public interface IReadConfiguration
    {
        string GetConnectionString(string connectionString);
    }
}
