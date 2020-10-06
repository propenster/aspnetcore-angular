using FullStackWebAppwithAngular.DataAccess.Dapper;
using FullStackWebAppwithAngular.Domain;
using FullStackWebAppwithAngular.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FullStackWebAppwithAngular.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        protected readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void AddEmployee(Employee employee)
        {
            _employeeRepository.AddEmployee(employee);
        }

        public void DeleteEmployee(int EmployeeId)
        {
            _employeeRepository.DeleteEmployee(EmployeeId);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeeAsync()
        {
            return await _employeeRepository.GetAllEmployees();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int EmployeeId)
        {
            return await _employeeRepository.GetEmployeeById(EmployeeId);
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeRepository.UpdateEmployee(employee);
        }
    }
}
