using API_PaulBikeStore.Filters;
using API_PaulBikeStore.Utilities;
using BusinessLayer_PaulBikeStore.Business.Services.Interfaces.Application;
using DomainLayer_PaulBikeStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API_PaulBikeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResponse<object>> GetOrdersForCustomer(int customerId)
        {
            var response = await _orderService.GetOrdersForCustomer(customerId: customerId);
            return CustomActionResponse.CreateActionResponse<object>(HttpStatusCode.OK, responseObject: response);
        }

        [HttpGet("TopOrders")]
        public async Task<ActionResponse<object>> GetTopSellingEntities(bool isBrand)
        {
            dynamic response = isBrand ? await _orderService.GetTopOrders<BrandOrders>() : await _orderService.GetTopOrders<ProductOrders>();
            return CustomActionResponse.CreateActionResponse<object>(HttpStatusCode.OK, responseObject: response);
        }
    }
}
