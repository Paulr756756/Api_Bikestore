using AutoMapper;
using BusinessLayer_PaulBikeStore.Business.DTOs;
using BusinessLayer_PaulBikeStore.Business.Services.Interfaces.Application;
using BusinessLayer_PaulBikeStore.Repository.Implementations;
using BusinessLayer_PaulBikeStore.Repository.Interfaces;
using DomainLayer_PaulBikeStore.Models;

namespace BusinessLayer_PaulBikeStore.Business.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _catRepository;
        private readonly IMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="catRepository"></param>
        /// <param name="mapper"></param>
        public CategoryService(ICategoryRepository catRepository,IMapper mapper)
        {
            _catRepository = catRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Category>> GetAllCategories()
        {
            return _mapper.Map<List<DTOCategory>, List<Category>>(await _catRepository.GetCategories());
        }
    }
}
