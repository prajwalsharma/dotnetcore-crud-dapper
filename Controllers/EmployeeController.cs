using CRUD_NET_Core_Web_API_Dapper.Models;
using CRUD_NET_Core_Web_API_Dapper.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_NET_Core_Web_API_Dapper.Controllers
{
    [ApiController]
    [Route("")]
    [Route("api")]
    public class EmployeeController : ControllerBase
    {

        private readonly EmployeeRepository employeeRepository;

        public EmployeeController()
        {
            employeeRepository = new EmployeeRepository();
        }

        [HttpPost("employee")]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            employeeRepository.CreateEmployee(employee);
            return Ok("Employee created");
        }

        [HttpGet("employees")]
        [Route("")]
        public IActionResult GetEmployees()
        {
            var employees = employeeRepository.GetEmployees();
            return Ok(employees);
        }

        [HttpGet("employee/{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employees = employeeRepository.GetEmployee(id);
            return Ok(employees);
        }

        [HttpPut("employee")]
        public IActionResult UpdateEmployee([FromBody]Employee employee)
        {
            employeeRepository.UpdateEmployee(employee);
            return Ok("Employee record updated");
        }

        [HttpDelete("employee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            employeeRepository.DeleteEmployee(id);
            return Ok("Employee record deleted");
        }
    }
}
