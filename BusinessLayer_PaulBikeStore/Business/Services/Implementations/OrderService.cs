using AutoMapper;
using BusinessLayer_PaulBikeStore.Business.DTOs;
using BusinessLayer_PaulBikeStore.Business.Services.Interfaces;
using BusinessLayer_PaulBikeStore.Business.Services.Interfaces.Application;
using DomainLayer_PaulBikeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_PaulBikeStore.Business.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrdersRepository ordersRepository;
        private readonly IMapper mapper;
        public OrderService(IOrdersRepository ordersRepository, IMapper mapper)
        {
            this.ordersRepository = ordersRepository;
            this.mapper = mapper;
        }
        public async Task<List<Order>> GetOrdersForCustomer(int customerId)
        {
            List<Order> orders = new List<Order>();
            var result = await ordersRepository.GetOrders(customerId);
            foreach (var order in result.Orders)
            {
                List<OrderItems> items = new List<OrderItems>();
                int orderId = order.order_id;
                items.AddRange(mapper.Map<List<DTOOrderItems>, List<OrderItems>>(result.OrderItems.FindAll(x => x.order_id == orderId)));
                Order _order = mapper.Map<DTOOrders, Order>(order);
                _order.OrderItems = items;
                orders.Add(_order);
            }
            return orders;
        }

        public async Task<List<T>> GetTopOrders<T>() where T : class
        {
            if (typeof(T) == typeof(BrandOrders))
            {
                var dtoBrands = await ordersRepository.GetTopOrders<DTOBrandOrders>(false);
                var brandOrders = mapper.Map<List<DTOBrandOrders>, List<BrandOrders>>(dtoBrands);
                return (List<T>)Convert.ChangeType(brandOrders, typeof(List<T>));
            }
            if (typeof(T) == typeof(ProductOrders))
            {
                var dtoProducts = await ordersRepository.GetTopOrders<DTOProductOrders>(true);
                var productOrders = mapper.Map<List<DTOProductOrders>, List<ProductOrders>>(dtoProducts);
                return (List<T>)Convert.ChangeType(productOrders, typeof(List<T>));
            }
            return null!;
        }
    }
}

