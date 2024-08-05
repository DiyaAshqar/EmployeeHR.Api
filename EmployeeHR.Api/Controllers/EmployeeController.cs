using EmployeeHR.Api.Data;
using EmployeeHR.Api.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace EmployeeHR.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public EmployeeController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }



        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            var employees = _dbContext.Employees.Include(x => x.Department).ToList();
            if (!employees.Any())
            {
                return NotFound();
            }
            return Ok(employees);
        }


        [HttpGet("GetById/{id}")]
        public ActionResult<Employee> Get(int id)
        {
            var employee = _dbContext.Employees.Include(x => x.Department).FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] Employee employee)
        {
            try
            {
                if (employee.BasicSalary > 1000)
                {
                    return BadRequest("Salary exceeded");
                }
                employee.BasicSalary = Convert.ToDecimal("2,l");
                employee = new Employee();
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
                return Ok(true);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        [HttpPut]
        public ActionResult<bool> Put([FromBody] Employee employee)
        {
            try
            {
                _dbContext.Employees.Update(employee);
                _dbContext.SaveChanges();
                return Ok(true);
            }
            catch (Exception e)
            {
                throw;
            }

        }

    }
}
