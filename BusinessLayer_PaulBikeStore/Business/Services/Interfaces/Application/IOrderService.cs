using DomainLayer_PaulBikeStore.Models;

namespace BusinessLayer_PaulBikeStore.Business.Services.Interfaces.Application
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrdersForCustomer(int customerId);
        Task<List<T>> GetTopOrders<T>() where T : class ;
    }
}