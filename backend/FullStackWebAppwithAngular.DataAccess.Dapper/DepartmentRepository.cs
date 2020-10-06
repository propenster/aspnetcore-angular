using Dapper;
using FullStackWebAppwithAngular.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace FullStackWebAppwithAngular.DataAccess.Dapper
{
    public class DepartmentRepository : IDepartmentRepository
    {
        protected readonly IConfiguration _configuration;

        public DepartmentRepository(IConfiguration configuration)
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

        public void AddDepartment(Department department)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("DepartmentName", department.DepartmentName);
                    parameters.Add("DepartmentEmail", department.DepartmentEmail);
                    SqlMapper.Execute(dbConnection, "AddDepartment", param: parameters, commandType: CommandType.StoredProcedure);

                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteDepartment(int DepartmentId)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("DepartmentId", DepartmentId);
                    SqlMapper.Execute(dbConnection, "DeleteDepartment", parameters, commandType: CommandType.StoredProcedure);
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    return await SqlMapper.QueryAsync<Department>(dbConnection, "GetAllDepartments", commandType: CommandType.StoredProcedure);
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Department> GetDepartmentById(int DepartmentId)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("DepartmentId", DepartmentId);
                    return await SqlMapper.QuerySingleOrDefaultAsync<Department>(dbConnection, "GetDepartmentById", parameters, commandType: CommandType.StoredProcedure);
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateDepartment(Department department)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("DepartmentName", department.DepartmentName);
                    parameters.Add("DepartmentEmail", department.DepartmentEmail);
                    SqlMapper.Execute(dbConnection, "UpdateDepartment", param: parameters, commandType: CommandType.StoredProcedure);

                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
