using AutoMapper;
using BusinessLayer_PaulBikeStore.Business.DTOs;
using BusinessLayer_PaulBikeStore.Business.Services.Interfaces.Application;
using BusinessLayer_PaulBikeStore.Business.Services.Interfaces.Repository;
using DomainLayer_PaulBikeStore.Models;

namespace BusinessLayer_PaulBikeStore.Business.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<Employee>> GetAllEmployees(PageModel pageModel)
        {
            return _mapper.Map< List<DTOEmployee>, List<Employee>>( await _employeeRepository.GetAllEmployees(pageModel) );

            //return await Task.FromResult(employeeRepository.GetAllEmployees(pageModel).Result.Skip(pageModel.PageSize * (pageModel.PageNumber - 1)).ToList());

        }

        //
        public async Task<List<Employee>> GetEmployeeById(int id)
        {
            return _mapper.Map<List<DTOEmployee>, List<Employee>>(await _employeeRepository.GetEmployeesById(id));
        }
    }
}
