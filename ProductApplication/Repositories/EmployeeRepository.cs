using ProductApplication.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace ProductApplication.Repositories
{
    public class EmployeeRepository
    {
        #region Constants

        private const string ConnectionName = "DefaultConnection";
        private const string AddEmployeeProcedureName = "AddNewEmployeeDetails";
        private const string GetEmployeesProcedureName = "GetEmployees";
        private const string UpdateEmployeeProcedureName = "UpdateEmployeeDetails";
        private const string DeleteEmployeeProcedureName = "DeleteEmployeeById";
        private const string IdParameterName = "Id";
        private const string NameParameterName = "Name";
        private const string CityParameterName = "City";
        private const string AddressParameterName = "Address";

        #endregion

        #region Private fields

        private SqlConnection _connection;

        #endregion

        #region Public logic

        public bool AddEmployee(Employee employee)
        {
            InitializeConnection();

            var command = new SqlCommand(AddEmployeeProcedureName, _connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue($"@{NameParameterName}", employee.Name);
            command.Parameters.AddWithValue($"@{CityParameterName}", employee.City);
            command.Parameters.AddWithValue($"@{AddressParameterName}", employee.Address);

            _connection.Open();

            int result = command.ExecuteNonQuery();

            _connection.Close();

            return result >= 1;
        }

        public List<Employee> GetAllEmployees()
        {
            InitializeConnection();

            var employees = new List<Employee>();

            var command = new SqlCommand(GetEmployeesProcedureName, _connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            var dataAdapter = new SqlDataAdapter(command);
            var dataTable = new DataTable();

            _connection.Open();

            dataAdapter.Fill(dataTable);

            _connection.Close();

            foreach (DataRow row in dataTable.Rows)
            {
                employees.Add(new Employee
                {
                    Id = Convert.ToInt32(row[IdParameterName]),
                    Name = Convert.ToString(row[NameParameterName]),
                    City = Convert.ToString(row[CityParameterName]),
                    Address = Convert.ToString(row[AddressParameterName])
                });
            }

            return employees;
        }

        public bool UpdateEmployee(Employee employee)
        {
            InitializeConnection();

            var command = new SqlCommand(UpdateEmployeeProcedureName, _connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue($"@{IdParameterName}", employee.Id);
            command.Parameters.AddWithValue($"@{NameParameterName}", employee.Name);
            command.Parameters.AddWithValue($"@{CityParameterName}", employee.City);
            command.Parameters.AddWithValue($"@{AddressParameterName}", employee.Address);

            _connection.Open();

            int result = command.ExecuteNonQuery();

            _connection.Close();

            return result >= 1;
        }

        public bool DeleteEmployee(int Id)
        {
            InitializeConnection();

            var command = new SqlCommand(DeleteEmployeeProcedureName, _connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue($"@{IdParameterName}", Id);

            _connection.Open();

            int result = command.ExecuteNonQuery();

            _connection.Close();

            return result >= 1;
        }

        #endregion

        #region Private logic

        private void InitializeConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[ConnectionName].ToString();

            _connection = new SqlConnection(connectionString);
        }

        #endregion
    }
}