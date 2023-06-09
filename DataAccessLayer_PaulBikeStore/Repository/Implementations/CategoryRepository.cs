using BusinessLayer_PaulBikeStore.Business.DTOs;
using BusinessLayer_PaulBikeStore.Repository.Implementations;
using System.Data;

namespace DataAccessLayer_PaulBikeStore.Repository.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BaseRepository<CategoryRepository> baseRepository;
        public CategoryRepository(BaseRepository<CategoryRepository> baseRepository)
        {
            this.baseRepository = baseRepository;
        }
        public async Task<List<DTOCategory>> GetCategories()
        {
            DatabaseModel databaseModel = new DatabaseModel() { ProcedureName = CategoryRepositoryProcedures.Proc_GetAllCategories, CommandType = CommandType.StoredProcedure, SqlParameters = null };
            return await baseRepository.Get<DTOCategory>(databaseModel);
        }
    }
}
