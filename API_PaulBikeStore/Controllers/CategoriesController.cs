using API_PaulBikeStore.Utilities;
using BusinessLayer_PaulBikeStore.Business.Services.Implementations;
using BusinessLayer_PaulBikeStore.Business.Services.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_PaulBikeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: api/<CategorieseController>
        [HttpGet]
        public async Task<ActionResponse<object>> GetCategories()
        {
            var response = await _categoryService.GetAllCategories();
            return CustomActionResponse.CreateActionResponse<object>(HttpStatusCode.OK, responseObject: response);
        }

        // GET api/<CategorieseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategorieseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategorieseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategorieseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
