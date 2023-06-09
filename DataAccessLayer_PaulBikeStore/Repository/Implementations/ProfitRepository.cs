using BusinessLayer_PaulBikeStore.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer_PaulBikeStore.Models;
using BusinessLayer_PaulBikeStore.Repository.Implementations;

namespace DataAccessLayer_PaulBikeStore.Repository.Implementations
{
    public class ProfitRepository : IProfitRepository
    {
        private readonly BaseRepository<ProfitRepository> baseRepository;
        public ProfitRepository(BaseRepository<ProfitRepository> baseRepository)
        {
            this.baseRepository = baseRepository;
        }
        public async Task<List<T>> GetProfits<T>(ProfitCheckValue dataObject) where T : class
        {
            List<SqlParameter> objParam = new List<SqlParameter>()
            {
                new SqlParameter {ParameterName ="@BrandID",Direction=ParameterDirection.Input,DbType=DbType.Int32 ,Value=dataObject.IsBrand},
                new SqlParameter {ParameterName ="@CategoryID",Direction=ParameterDirection.Input,DbType=DbType.Int32 ,Value=dataObject.IsCategory},
                new SqlParameter {ParameterName ="@StoreID",Direction=ParameterDirection.Input,DbType=DbType.Int32 ,Value=dataObject.IsStore}
            };
            DatabaseModel databaseModel = new DatabaseModel() { ProcedureName = ProfitRepositoryProcedure.Proc_GetAllProfits, CommandType = CommandType.StoredProcedure, SqlParameters = objParam };
            return await baseRepository.Get<T>(databaseModel);
        }
    }
}
