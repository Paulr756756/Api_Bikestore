using DomainLayer_PaulBikeStore.Models;

namespace BusinessLayer_PaulBikeStore.Business.Services.Interfaces.Application
{
    public interface IProfitsService
    {
        Task<List<T>> GetAllProfits<T>(ProfitCheckValue dataObject);
    }
}