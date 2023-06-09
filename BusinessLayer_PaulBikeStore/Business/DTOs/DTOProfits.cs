using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BusinessLayer_PaulBikeStore.Business.DTOs
{
    public class DTOProfits
    {
        public int MyProperty { get; set; }

        public string? MyProperty2 { get; set; }

        public double TotalSales { get; set; }
    }


    public class DTOBrandProfits 
    {
        public int brand_id
        { get; set; }
        public string? brand_name
        { get; set; }

        public decimal TotalSales
        { get; set; }
    }
    public class DTOStoreProfits 
    {
        public int store_id { get; set; }
        public string? store_name
        { get; set; }

        public decimal TotalSales
        { get; set; }
    }
    public class DTOCategoryProfits
    {
        public int category_id
        { get; set; }
        public string? category_name
        { get; set; }

        public decimal TotalSales
        { get; set; }
    }
}

