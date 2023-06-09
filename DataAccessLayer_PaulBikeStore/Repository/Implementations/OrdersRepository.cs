using BusinessLayer_PaulBikeStore.Business.DTOs;
using BusinessLayer_PaulBikeStore.Business.Services.Interfaces;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer_PaulBikeStore.Repository.Implementations
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly BaseRepository<OrdersRepository> _baseRepository;
        public OrdersRepository(BaseRepository<OrdersRepository> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<(List<DTOOrders> Orders, List<DTOOrderItems> OrderItems)> GetOrders(int customerId)
        {
            List<SqlParameter> objParam1 = new List<SqlParameter>()
               {
                new SqlParameter { ParameterName = "@customer_id", Direction = ParameterDirection.Input, DbType = DbType.String, Value = customerId },
                new SqlParameter { ParameterName = "@fetchOrderItems", Direction = ParameterDirection.Input, DbType = DbType.Boolean, Value = 0 }
               };
            DatabaseModel databaseModel1 = new DatabaseModel() { CommandType = CommandType.StoredProcedure, ProcedureName = OrderRepositoryProcedure.Proc_GetOrdersOfACustomer, SqlParameters = objParam1 };
            List<DTOOrders> dTOOrders = await _baseRepository.GetById<DTOOrders>(databaseModel1);
            StringBuilder orderIds = new StringBuilder();
            foreach (var el in dTOOrders)
            {
                orderIds.Append(el.order_id);
                orderIds.Append(',');
            }
            orderIds.Remove(orderIds.Length - 1, 1);
            List<SqlParameter> objParam2 = new List<SqlParameter>()
               {
                new SqlParameter { ParameterName = "@order_ids", Direction = ParameterDirection.Input, DbType = DbType.String, Value = orderIds.ToString() },
                new SqlParameter { ParameterName = "@fetchOrderItems", Direction = ParameterDirection.Input, DbType = DbType.Boolean, Value = 1}
            };
            DatabaseModel databaseModel2 = new DatabaseModel() { CommandType = CommandType.StoredProcedure, ProcedureName = OrderRepositoryProcedure.Proc_GetOrdersOfACustomer, SqlParameters = objParam2 };
            List<DTOOrderItems> dTOOrderItems = await _baseRepository.GetById<DTOOrderItems>(databaseModel2);
            return (dTOOrders, dTOOrderItems);
        }

        public async Task<List<T>> GetTopOrders<T>(bool isBrand) where T : class
        {
            List<SqlParameter> objParam = new List<SqlParameter>()
               {
                new SqlParameter { ParameterName = "@brand_product", Direction = ParameterDirection.Input, DbType = DbType.Boolean, Value = isBrand }
            };
            DatabaseModel databaseModel2 = new DatabaseModel() { CommandType = CommandType.StoredProcedure, ProcedureName = OrderRepositoryProcedure.Proc_GetTopOrders, SqlParameters = objParam };
            List<T> dTOOrderItems = await _baseRepository.GetById<T>(databaseModel2);
            return dTOOrderItems;
        }
    }
}
