using AutoMapper;
using BusinessLayer_PaulBikeStore.Business.DTOs;
using BusinessLayer_PaulBikeStore.Business.Services.Interfaces.Application;
using BusinessLayer_PaulBikeStore.Repository.Implementations;
using DomainLayer_PaulBikeStore.Models;

namespace BusinessLayer_PaulBikeStore.Business.Services.Implementations
{
    public class ProfitsService : IProfitsService
    {
        private readonly IProfitRepository _profitRepository;
        private readonly IMapper _mapper;
        public ProfitsService(IProfitRepository profitRepository,IMapper mapper)
        {
            _profitRepository = profitRepository;
            _mapper = mapper;
        }
        public async Task<List<T>> GetAllProfits<T>(ProfitCheckValue dataObject)
        {
            if (typeof(T) == typeof(DTOStoreProfits))
            {
                return (List<T>)Convert.ChangeType(await _profitRepository.GetProfits<DTOStoreProfits>(dataObject), typeof(List<T>));

            }
            else if (typeof(T) == typeof(DTOBrandProfits))
            {
                return (List<T>)Convert.ChangeType(await _profitRepository.GetProfits<DTOBrandProfits>(dataObject), typeof(List<T>));
            }
            else
            {
                return (List<T>)Convert.ChangeType(await _profitRepository.GetProfits<DTOCategoryProfits>(dataObject), typeof(List<T>));
            }
        }
    }
}
