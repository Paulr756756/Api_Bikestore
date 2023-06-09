using BusinessLayer_PaulBikeStore.Business.DTOs;
using DomainLayer_PaulBikeStore.Models;

namespace BusinessLayer_PaulBikeStore.Repository.Implementations
{
    public interface IProfitRepository
    {
        Task<List<T>> GetProfits<T>(ProfitCheckValue dataObject) where T : class;
    }
}