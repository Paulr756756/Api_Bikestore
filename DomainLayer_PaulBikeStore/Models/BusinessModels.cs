using System.Data.SqlTypes;
using System.Runtime;

namespace DomainLayer_PaulBikeStore.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string? BrandName { get; set; }
    }
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
    public class Store
    {
        public int StoreId { get; set; }
        public string? StoreName { get; set; }
    }

    public class Order
    {
        public int CustomerId { get; set; }
        public int OrderStatus { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int StoreId { get; set; }
        public int StaffId { get; set; }
        public List<OrderItems>? OrderItems { get; set; }

    }

    public class OrderItems
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal ListPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountedPrice { get; set; }

    }
    public class BrandOrders
    {
        public int BrandId { get; set; }
        public string? BrandName { get; set; }
        public int TotalOrders { get; set; }
    }
    public class ProductOrders
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int TotalOrders { get; set; }

    }
    //
    public class Employee
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int StoreId { get; set; }
//        public int ManagerId { get; set; }
    }
}
