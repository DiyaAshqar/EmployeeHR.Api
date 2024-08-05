using EmployeeHR.Api.Data;
using EmployeeHR.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace EmployeeHR.Api.Controllers
{
    //[Route("api/{Controller}")]
    [ApiController]
    [Route("api/Department")]
    public class DepartmentController : ControllerBase
    {

        private readonly AppDbContext _dbContext;
        public DepartmentController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }


        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            //Statuses Code// 100, 200 , 300, 400, 500
            //200 Success
            //300 auth. issue (permission)
            //400 badrequest -- from client or from server
            //500 server error
            var dep = _dbContext.Departments.ToList();
            return Ok(dep);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var dep = _dbContext.Departments.FirstOrDefault(x=>x.Id == id);
            if (dep == null)
            {
                return NotFound();
            }
            return Ok(dep);

        }

        [HttpPost]
        public ActionResult<bool> Post([FromBody]Department department)
        {
            if (department == null)
            {
                return BadRequest();
            }

            _dbContext.Departments.Add(department);
            _dbContext.SaveChanges();
            return Ok(true);
        }


        [HttpPut]
        public ActionResult<bool> Put(Department department)
        {
            
            _dbContext.Departments.Update(department); 
            _dbContext.SaveChanges();
            return Ok(true);
        }
        [HttpPatch]
        public ActionResult<bool> Patch(Department department)
        {
            var dep = _dbContext.Departments.FirstOrDefault(x => x.Id == department.Id);
            if (dep == null)
            {
                return NotFound();
            }
            dep.Abbreviation = department.Abbreviation;
             
            _dbContext.SaveChanges();
            return Ok(true);
        }

        [HttpDelete]
        public ActionResult<bool> Delete(int id)
        {
            var dep = _dbContext.Departments.FirstOrDefault(x => x.Id == id);
            if (dep == null)
            {
                return NotFound();
            }
            _dbContext.Departments.Remove(dep);
            _dbContext.SaveChanges();
            return Ok(true);
        }

    }
}
