using Dapper;
using FullStackWebAppwithAngular.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace FullStackWebAppwithAngular.DataAccess.Dapper
{
    public class EmployeeRepository : IEmployeeRepository
    {
        protected readonly IConfiguration _configuration;

        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlClient(_configuration.GetConnectionString("EmployeeDBConnection"));
            }
        }

        public void AddEmployee(Employee employee)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("EmployeeName", employee.EmployeeName);
                    parameters.Add("EmployeeMobile", employee.EmployeeMobile);
                    parameters.Add("EmployeeEmail", employee.EmployeeEmail);
                    parameters.Add("Department", employee.Department);
                    parameters.Add("ImageURL", employee.ImageURL);
                    parameters.Add("EmployeeRegisteredDate", employee.EmployeeRegisteredDate);

                    SqlMapper.Execute(dbConnection, "AddEmployee", param: parameters, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteEmployee(int EmployeeId)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("EmployeeId", EmployeeId);
                    SqlMapper.Execute(dbConnection, "DeleteEmployee", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    return await SqlMapper.QueryAsync<Employee>(dbConnection, "GetAllEmployees", commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Employee> GetEmployeeById(int EmployeeId)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("EmployeeId", EmployeeId);
                    return await SqlMapper.QuerySingleOrDefaultAsync<Employee>(dbConnection, "GetEmployeeById", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("EmployeeName", employee.EmployeeName);
                    parameters.Add("EmployeeMobile", employee.EmployeeMobile);
                    parameters.Add("EmployeeEmail", employee.EmployeeEmail);
                    parameters.Add("Department", employee.Department);
                    parameters.Add("ImageURL", employee.ImageURL);
                    parameters.Add("EmployeeRegisteredDate", employee.EmployeeRegisteredDate);

                    SqlMapper.Execute(dbConnection, "UpdateEmployee", param: parameters, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
