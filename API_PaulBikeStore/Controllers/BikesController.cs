using API_PaulBikeStore.Filters;
using API_PaulBikeStore.Utilities;
using BusinessLayer_PaulBikeStore.Business.DTOs;
using BusinessLayer_PaulBikeStore.Business.Services.Interfaces.Application;
using DomainLayer_PaulBikeStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_PaulBikeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikesController : ControllerBase
    {
        private readonly IBikeService _bikeService;
        private readonly IProfitsService _profitsService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bikeService"></param>
        /// <param name="profitsService"></param>
        public BikesController(IBikeService bikeService, IProfitsService profitsService)
        {
            _bikeService = bikeService;
            _profitsService = profitsService;
        }
        // GET: api/<BikesController>
        [HttpGet]
        //[AzureADAuthorizationFilter]
        public async Task<ActionResponse<object>> GetBikes()
        {
            var response = await _bikeService.GetAllBikes();
            return CustomActionResponse.CreateActionResponse<object>(HttpStatusCode.OK, responseObject: response);
        }

        [HttpGet("Profits")]
        public async Task<ActionResponse<object>> GetAllBikeProfits([FromQuery]ProfitCheckValue profitCheckValue)
        {
            dynamic response = profitCheckValue switch
            {
                ProfitCheckValue i when i.IsBrand == 1 => await _profitsService.GetAllProfits<DTOBrandProfits>(profitCheckValue),
                ProfitCheckValue i when i.IsCategory == 1 => await _profitsService.GetAllProfits<DTOCategoryProfits>(profitCheckValue),
                ProfitCheckValue i when i.IsStore == 1 => await _profitsService.GetAllProfits<DTOStoreProfits>(profitCheckValue),
                _ => throw new NotImplementedException(),
            };
            return CustomActionResponse.CreateActionResponse<object>(HttpStatusCode.OK, responseObject: response);
        }

        // GET api/<BikesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResponse<object>> GetBikesById(int id)
        {
            var response = await _bikeService.GetBikesById(id);
            return CustomActionResponse.CreateActionResponse<object>(HttpStatusCode.OK, responseObject: response);
        }

        // POST api/<BikesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BikesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BikesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
