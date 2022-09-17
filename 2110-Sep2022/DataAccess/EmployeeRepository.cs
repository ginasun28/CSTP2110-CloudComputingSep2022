﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;

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
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "INSERT INTO Employee(ID, NAME) VALUES (@ID, @NAME)";
                    command.Parameters.AddWithValue("@ID", employee.ID);
                    command.Parameters.AddWithValue("@NAME", employee.Name);
                    try
                    {
                        connection.Open();
                        int records = command.ExecuteNonQuery();
                    }
                    catch(SqlException)
                    {
                        // error here
                        Console.WriteLine("Error!! The data is not adding.....");
                    }
                    finally
                    {
                        connection.Close();
                    }

                }
            }


        }
        /// <summary>
        /// Assignment1
        /// </summary>
        /// <param name="employee"></param>
        public void Delete(Employee employee)
        {
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "DELETE FROM Employee WHERE ID = @ID";
                    command.Parameters.AddWithValue("@ID", employee.ID);
                    try
                    {
                        connection.Open();
                        int records = command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        // error here
                        Console.WriteLine("Error!! The data cannot delete.....");
                    }
                    finally
                    {
                        connection.Close();
                    }

                }
            }
            
        }
        /// <summary>
        /// Assignment1
        /// </summary>
        /// <param name="employee"></param>
        public void Get(string idFilter)
        {
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT * FROM Employee WHERE ID = @ID";
                    command.Parameters.AddWithValue("@ID", idFilter);
                    try
                    {
                        connection.Open();
                        int records = command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        // error here
                        Console.WriteLine("Error!! The data cannot delete.....");
                    }
                    
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())//THIS always evaluates to false
                    {
                       string employeeID = dataReader["ID"].ToString();
                       string employeeName = dataReader["Name"].ToString();
                        Console.WriteLine("ID: {0}", employeeID);
                        Console.WriteLine("Name: {0}", employeeName);
                    }

                }
            }
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
