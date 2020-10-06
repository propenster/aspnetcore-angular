using FullStackWebAppwithAngular.DataAccess.Dapper;
using FullStackWebAppwithAngular.Domain;
using FullStackWebAppwithAngular.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FullStackWebAppwithAngular.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        protected readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void AddDepartment(Department department)
        {
            _departmentRepository.AddDepartment(department);
        }

        public void DeleteDepartment(int DepartmentId)
        {
            _departmentRepository.DeleteDepartment(DepartmentId);
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentAsync()
        {
            return await _departmentRepository.GetAllDepartments();
        }

        public async Task<Department> GetDepartmentByIdAsync(int DepartmentId)
        {
            return await _departmentRepository.GetDepartmentById(DepartmentId);
        }

        public void UpdateDepartment(Department department)
        {
            _departmentRepository.UpdateDepartment(department);
        }
    }
}
