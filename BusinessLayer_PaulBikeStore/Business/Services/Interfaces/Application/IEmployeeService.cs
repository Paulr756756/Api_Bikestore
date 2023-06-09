using BusinessLayer_PaulBikeStore.Business.DTOs;
using DomainLayer_PaulBikeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_PaulBikeStore.Business.Services.Interfaces.Application
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees(PageModel pageModel);
    }
}
