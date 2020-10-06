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
    public class EmployeesController : ControllerBase
    {
        protected readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        // GET: api/<DepartmentsController>
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeeAsync();
            return Ok(employees);
        }

        // GET api/<DepartmentsController>/5
        [HttpGet("{EmployeeId}")]
        public async Task<IActionResult> GetEmployeeById(int EmployeeId)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(EmployeeId);
            return Ok(employee);
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            _employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { EmployeeId = employee.EmployeeId }, employee);
        }

        // PUT api/<DepartmentsController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            _employeeService.UpdateEmployee(employee);
            return Ok();
        }

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{EmployeeId}")]
        public void DeleteEmployee(int EmployeeId)
        {
            _employeeService.DeleteEmployee(EmployeeId);
        }
    }
}
