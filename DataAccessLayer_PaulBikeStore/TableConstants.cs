using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_PaulBikeStore
{
    public class BikeRepositoryProcedures : RepositoryProcedures
    {
        public const string Proc_GetAllBikes = "BKS_GetAllBikeBrands";
        public const string Proc_GetBikesById = "BKS_GetAllBikeBrands";
        public const string Proc_AddBike = "";
        public const string Proc_UpdateBike = "";
        public const string Proc_DeleteBike = "";
    }

    public class CategoryRepositoryProcedures
    {
        public const string Proc_GetAllCategories = "BKS_GetAllBikeCategories";   
    }

    public class EmployeeRepositoryProcedures
    {

        public const string Proc_GetAllEmployees = "BKS_GetAllEmployeesFiltered";
    
    }
    public class ProfitRepositoryProcedure
    {
        public const string Proc_GetAllProfits = "BKS_GetAllStoreProfit";
    }
    public class OrderRepositoryProcedure
    {
        public const string Proc_GetOrdersOfACustomer = "BKS_GetOrdersForCustomer";
        public const string Proc_GetTopOrders = "BKS_GetTopOrders";
    }

    public abstract class RepositoryProcedures
    { 
    
    
    }
}
