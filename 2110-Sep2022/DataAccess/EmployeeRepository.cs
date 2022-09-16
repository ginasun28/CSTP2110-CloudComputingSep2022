using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace _2110_Sep2022.DataAccess
{
    public class EmployeeRepository
    {
        private readonly IReadConfiguration readConfiguration;
        public EmployeeRepository(IReadConfiguration readConfiguration)
        {
            this.readConfiguration = readConfiguration;
        }

        /// <summary>
        /// Assignment1
        /// </summary>
        /// <param name="employee"></param>
        public void Add(Employee employee)
        {

        }
        /// <summary>
        /// Assignment1
        /// </summary>
        /// <param name="employee"></param>
        public void Delete(Employee employee)
        {

        }
        /// <summary>
        /// Assignment1
        /// </summary>
        /// <param name="employee"></param>
        public void Get(string idFilter)
        {

        }

        private SqlConnection GetConnection()
        {
            var connString = readConfiguration.GetConnectionString(EnvironmentSettings.DBEnvironment);
            if (string.IsNullOrWhiteSpace(connString))
            {
                throw new Exception("Database Connection string not found");
            }
            var connection = new SqlConnection(connString);
            return connection;
        }
    }
}
