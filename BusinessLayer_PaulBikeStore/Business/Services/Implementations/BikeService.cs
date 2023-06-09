using AutoMapper;
using BusinessLayer_PaulBikeStore.Business.DTOs;
using BusinessLayer_PaulBikeStore.Business.Services.Interfaces.Application;
using BusinessLayer_PaulBikeStore.Repository.Interfaces;
using DomainLayer_PaulBikeStore.Models;

namespace BusinessLayer_PaulBikeStore.Business.Services.Implementations
{
    public class BikeService : IBikeService
    {
        private readonly IBikeRepository _bikeRepository;
        private readonly IMapper _mapper;
        public BikeService(IBikeRepository bikeRepository,IMapper mapper)
        {
            _bikeRepository = bikeRepository;
            _mapper = mapper;
        }

        public async Task<List<Brand>> GetAllBikes()
        {
            return _mapper.Map<List<DTOBike>,List<Brand>>(await _bikeRepository.GetBikes());

        }

        public async Task<List<Brand>> GetBikesById(int id)
        {
            return _mapper.Map<List<DTOBike>, List<Brand>>(await _bikeRepository.GetBikeCategoryById(id));
        }
    }
}
