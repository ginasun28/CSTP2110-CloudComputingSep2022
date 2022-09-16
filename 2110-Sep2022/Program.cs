using _2110_Sep2022.DataAccess;
using System;
using Microsoft.Data.SqlClient;

namespace _2110_Sep2022
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.CreateTable();

        }

        public void CreateTable()
        {
            var readConfig = new ReadConfiguration();
            var connString = readConfig.GetConnectionString(EnvironmentSettings.DBEnvironment);
            Console.WriteLine(connString);

            var sqlConnection = new SqlConnection(connString);

            string sqlStatement = "CREATE TABLE Emoloyee(ID VARCHAR(30) NOT NULL, NAME VARCHAR(50) NOT NULL)";
            SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }
    }
}