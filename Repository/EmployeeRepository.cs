using CRUD_NET_Core_Web_API_Dapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_NET_Core_Web_API_Dapper.Repository
{
    public class EmployeeRepository
    {

        private const string CONN_STRING = "YOUR_CONNECTION_STRING_HERE";

        // Insert new employee in DB
        public void CreateEmployee(Employee employee)
        {

            string procedureName = "EMS_SP_SAVE_EMPLOYEE";

            using (var idbConnection = new SqlConnection(CONN_STRING))
            {
                idbConnection.Open();

                var affectedRows = idbConnection.Execute(
                    procedureName,
                    new
                    {
                        NAME = employee.NAME,
                        CITY = employee.CITY,
                        DEPARTMENT = employee.DEPARTMENT,
                        GENDER = employee.GENDER
                    },
                    commandType: CommandType.StoredProcedure
                );
            }

        }

        // Fetch all active employees from DB
        public IEnumerable<Employee> GetEmployees()
        {
            string procedureName = "EMS_SP_GET_ALL_EMPLOYEES";

            IEnumerable<Employee> employees = null;

            using (var idbConnection = new SqlConnection(CONN_STRING))
            {
                idbConnection.Open();

                employees = idbConnection.Query<Employee>(
                    procedureName,
                    null,
                    commandType: CommandType.StoredProcedure
                );
            }

            return employees;
        }

        // Fetch only a particular employee from DB
        public Employee GetEmployee(int id)
        {
            string procedureName = "EMS_SP_GET_PARTICULAR_EMPLOYEE";

            Employee employee = null;

            using (var idbConnection = new SqlConnection(CONN_STRING))
            {
                idbConnection.Open();

                var result = idbConnection.Query<Employee>(
                    procedureName,
                    new { EMPLOYEEID = id },
                    commandType: CommandType.StoredProcedure
                );

                employee = result.FirstOrDefault();
            }

            return employee;
        }

        // Update an existing employee record
        public void UpdateEmployee(Employee employee)
        {
            string procedureName = "EMS_SP_UPDATE_EMPLOYEE";

            using (var idbConnection = new SqlConnection(CONN_STRING))
            {
                idbConnection.Open();

                var affectedRows = idbConnection.Execute(
                    procedureName,
                    new
                    {
                        EMPLOYEEID = employee.ID,
                        NAME = employee.NAME,
                        CITY = employee.CITY,
                        DEPARTMENT = employee.DEPARTMENT,
                        GENDER = employee.GENDER
                    },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        // Delete an existing employee record
        public void DeleteEmployee(int employeeId)
        {
            string procedureName = "EMS_SP_DELETE_EMPLOYEE";

            using (var idbConnection = new SqlConnection(CONN_STRING))
            {
                idbConnection.Open();

                var affectedRows = idbConnection.Execute(
                    procedureName,
                    new { EMPLOYEEID = employeeId },
                    commandType: CommandType.StoredProcedure
                );
            }
        }
    }
}
