using BusinessLayer_PaulBikeStore.Business.DTOs;

namespace BusinessLayer_PaulBikeStore.Business.Services.Interfaces.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<DTOEmployee>> GetAllEmployees(PageModel pageModel);
        Task<List<DTOEmployee>> GetEmployeesById(int employeeId);
    }
}
