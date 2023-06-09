using BusinessLayer_PaulBikeStore.Business.DTOs;

namespace BusinessLayer_PaulBikeStore.Repository.Interfaces
{
    public interface IBikeRepository
    {
        Task<List<DTOBike>> GetBikes();
        Task<List<DTOBike>> GetBikeCategoryById(int Id);
    }
}