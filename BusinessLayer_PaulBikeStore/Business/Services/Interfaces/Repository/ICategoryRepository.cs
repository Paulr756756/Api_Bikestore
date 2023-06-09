using BusinessLayer_PaulBikeStore.Business.DTOs;

namespace BusinessLayer_PaulBikeStore.Repository.Implementations
{
    public interface ICategoryRepository
    {
        Task<List<DTOCategory>> GetCategories();
    }
}