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
            // program.CreateTable();
            // program.AddEmployee();
            // program.DeleteEmployee();
            // program.GetEmployee();
            // program.UpdateEmployee();
            program.GetEmployees();

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

        public void AddEmployee()
        {
            var readConfig = new ReadConfiguration();
            var rep = new EmployeeRepository(readConfig);
            var emp = new Employee()
            {
                ID = "001",
                Name = "Alex"
            };
            rep.Add(emp);
        }

        public void DeleteEmployee()
        {
            var readConfig = new ReadConfiguration();
            var rep = new EmployeeRepository(readConfig);
            var emp = new Employee()
            {
                ID = "001",
                Name = "Alex"
            };
            rep.Delete(emp);
        }

        public void GetEmployee()
        {
            var readConfig = new ReadConfiguration();
            var rep = new EmployeeRepository(readConfig);

            var emp = rep.Get("001");
            Console.WriteLine($"Employee ID: {emp.ID}");
            Console.WriteLine($"Employee Name: {emp.Name}");
        }

        public void UpdateEmployee()
        {
            var readConfig = new ReadConfiguration();
            var rep = new EmployeeRepository(readConfig);
            var emp = new Employee()
            {
                ID = "001",
                Name = "Amy"
            };
            rep.Update(emp);
        }
        public void GetEmployees()
        {
            var readConfig = new ReadConfiguration();
            var rep = new EmployeeRepository(readConfig);

            foreach(var emp in rep.GetId("001"))
            {
                Console.WriteLine($"Employee ID: {emp.ID}");
                Console.WriteLine($"Employee Name: {emp.Name}");
            }
        }
    }
}