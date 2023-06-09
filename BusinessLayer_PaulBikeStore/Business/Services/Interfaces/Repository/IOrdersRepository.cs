using BusinessLayer_PaulBikeStore.Business.DTOs;

namespace BusinessLayer_PaulBikeStore.Business.Services.Interfaces
{
    public interface IOrdersRepository
    {
        Task<(List<DTOOrders> Orders, List<DTOOrderItems> OrderItems)> GetOrders(int customerId);
        Task<List<T>> GetTopOrders<T>(bool isBrand) where T : class;
    }
}