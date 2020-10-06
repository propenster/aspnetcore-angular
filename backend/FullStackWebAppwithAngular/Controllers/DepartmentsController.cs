using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStackWebAppwithAngular.Domain;
using FullStackWebAppwithAngular.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackWebAppwithAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        protected readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }


        // GET: api/<DepartmentsController>
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _departmentService.GetAllDepartmentAsync();
            return Ok(departments);
        }

        // GET api/<DepartmentsController>/5
        [HttpGet("{DepartmentId}")]
        public async Task<IActionResult> GetDepartmentById(int DepartmentId)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(DepartmentId);
            return Ok(department);
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public IActionResult AddDepartment([FromBody] Department department)
        {
            _departmentService.AddDepartment(department);
            return CreatedAtAction(nameof(GetDepartmentById), new { DepartmentId = department.DepartmentId }, department);
        }

        // PUT api/<DepartmentsController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateDepartment([FromBody] Department department)
        {
            _departmentService.UpdateDepartment(department);
            return Ok();
        }

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{DepartmentId}")]
        public void DeleteDepartment(int DepartmentId)
        {
            _departmentService.DeleteDepartment(DepartmentId);
        }
    }
}
