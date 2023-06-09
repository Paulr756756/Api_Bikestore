using Xunit;
using Moq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DataAccessLayer_PaulBikeStore.Repository.Implementations;

namespace Test_PaulBikeStore
{
    public class OrderRepositoryTests
    {
        private readonly Mock<BaseRepository> _mockBaseRepository;
        private readonly OrderRepository _orderRepository;

        public OrderRepositoryTests()
        {
            _mockBaseRepository = new Mock<IBaseRepository>();
            _orderRepository = new OrderRepository(_mockBaseRepository.Object);
        }

        [Fact]
        public async Task GetTopOrders_WithIsBrand_ReturnsListOfOrders()
        {
            // Arrange
            bool isBrand = true;

            List<SqlParameter> expectedParams = new List<SqlParameter>()
        {
            new SqlParameter { ParameterName = "@brand_product", Direction = ParameterDirection.Input, DbType = DbType.Boolean, Value = isBrand }
        };

            List<T> expectedOrders = new List<T>() { /* add expected orders here */ };

            _mockBaseRepository
                .Setup(repo => repo.GetById<T>(It.IsAny<DatabaseModel>()))
                .ReturnsAsync(expectedOrders);

            // Act
            List<T> actualOrders = await _orderRepository.GetTopOrders<T>(isBrand);

            // Assert
            Assert.Equal(expectedOrders, actualOrders);
            _mockBaseRepository.Verify(repo =>
                repo.GetById<T>(It.Is<DatabaseModel>(dm =>
                    dm.CommandType == CommandType.StoredProcedure &&
                    dm.ProcedureName == OrderRepositoryProcedure.Proc_GetTopOrders &&
                    dm.SqlParameters == expectedParams)),
                Times.Once);
        }
    }
}