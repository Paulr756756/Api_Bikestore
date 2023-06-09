using BusinessLayer_PaulBikeStore.Business.DTOs;
using DomainLayer_PaulBikeStore.Models;

namespace BusinessLayer_PaulBikeStore.Business.Services.Interfaces.Application
{
    public interface IBikeService
    {
        Task<List<Brand>> GetAllBikes();
        Task<List<Brand>> GetBikesById(int id);

    }
}