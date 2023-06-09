using DomainLayer_PaulBikeStore.Models;

namespace BusinessLayer_PaulBikeStore.Business.Services.Interfaces.Application
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
    }
}