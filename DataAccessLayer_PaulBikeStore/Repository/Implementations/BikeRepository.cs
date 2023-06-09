using BusinessLayer_PaulBikeStore.Business.DTOs;
using BusinessLayer_PaulBikeStore.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer_PaulBikeStore.Repository.Implementations
{
    public class BikeRepository : IBikeRepository
    {
        private readonly BaseRepository<BikeRepository> baseRepository;
        public BikeRepository(BaseRepository<BikeRepository> baseRepository)
        {
            this.baseRepository = baseRepository;
        }
        public async Task<List<DTOBike>> GetBikes()
        {
            DatabaseModel databaseModel = new DatabaseModel() { ProcedureName = BikeRepositoryProcedures.Proc_GetAllBikes, CommandType = CommandType.StoredProcedure, SqlParameters = null };
            return await baseRepository.Get<DTOBike>(databaseModel);
        }

        public async Task<List<DTOBike>> GetBikeCategoryById(int Id)
        {
            List<SqlParameter> objParam = new List<SqlParameter>()
               {
                new SqlParameter { ParameterName = "@brand_id", Direction = ParameterDirection.Input, DbType = DbType.String, Value = Id }
               };
            DatabaseModel databaseModel = new DatabaseModel() { ProcedureName = BikeRepositoryProcedures.Proc_GetBikesById, CommandType = CommandType.StoredProcedure, SqlParameters = objParam};
            return await baseRepository.GetById<DTOBike>(databaseModel);
        }
    }
}
