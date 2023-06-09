using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_PaulBikeStore.Business.DTOs
{
    public class DTOOrders
    {
        public int order_id { get; set; }
        public int customer_id { get; set; }
        public int order_status { get; set; }
        public DateTime? order_date { get; set; }
        public DateTime? required_date { get; set; }
        public DateTime? shipped_date { get; set; }
        public int staff_id { get; set; }
        public int store_id { get; set; }

    }

    public class DTOOrderItems
    {
        public int order_id { get; set; }
        public int store_id { get; set; }
        public int staff_id { get; set; }
        public int item_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public decimal list_price { get; set; }
        public decimal discount { get; set; }
    }

    public class DTOBrandOrders
    {
        public int brand_id { get; set; }
        public string? brand_name { get; set; }
        public int total_Orders { get; set; }
    }
    public class DTOProductOrders
    {
        public int product_id { get; set; }
        public string? product_name { get; set; }
        public int total_Orders { get; set; }
    }

}
