using API_PaulBikeStore.Utilities;
using BusinessLayer_PaulBikeStore.Business.DTOs;
using BusinessLayer_PaulBikeStore.Business.Services.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_PaulBikeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<ActionResponse<object>> GetAllEmployeeDetails([FromQuery] PageModel pageModel)
        {
            var response = await employeeService.GetAllEmployees(pageModel);
            return CustomActionResponse.CreateActionResponse<object>(HttpStatusCode.OK, responseObject: response);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
