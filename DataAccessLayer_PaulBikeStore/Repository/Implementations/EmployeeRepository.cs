using BusinessLayer_PaulBikeStore.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer_PaulBikeStore.Business.Services.Interfaces.Repository;

namespace DataAccessLayer_PaulBikeStore.Repository.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly BaseRepository<EmployeeRepository> baseRepository;

        public EmployeeRepository(BaseRepository<EmployeeRepository> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public async Task<List<DTOEmployee>> GetAllEmployees(PageModel pageModel)
        {
            List<SqlParameter> objParam = new List<SqlParameter>()
               {
                new SqlParameter { ParameterName = "@searchText", Direction = ParameterDirection.Input, DbType = DbType.String, Value = pageModel.SearchText },
                new SqlParameter { ParameterName = "@pageLimit", Direction = ParameterDirection.Input, DbType = DbType.Int32, Value = pageModel.PageSize }, 
                new SqlParameter { ParameterName = "@pageNumber", Direction = ParameterDirection.Input, DbType = DbType.Int32, Value = pageModel.PageNumber}
               };
            DatabaseModel databaseModel = new DatabaseModel() { ProcedureName = EmployeeRepositoryProcedures.Proc_GetAllEmployees, CommandType = CommandType.StoredProcedure, SqlParameters = objParam };
            return await baseRepository.Get<DTOEmployee>(databaseModel);
        }

        public Task<List<DTOEmployee>> GetEmployeesById(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
