using AutoMapper;
using BusinessLayer_PaulBikeStore.Business.DTOs;
using DomainLayer_PaulBikeStore.Models;

namespace BusinessLayer_PaulBikeStore.Helpers
{
    public class MapProfiles : Profile
    {
        public MapProfiles()
        {
            CreateMap<DTOBike, Brand>()
                    .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.brand_id))
                    .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.brand_name));
            CreateMap<DTOCategory, Category>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.category_id))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.category_name));
            CreateMap<DTOStore, Store>()
                .ForMember(dest => dest.StoreId, opt => opt.MapFrom(src => src.store_Id))
                .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.store_Name));

            CreateMap<DTOOrderItems, OrderItems>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.order_id))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.product_id))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.quantity))
                .ForMember(dest => dest.ListPrice, opt => opt.MapFrom(src => src.list_price))
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.discount))
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.item_id))
                .AfterMap((src, dest) => dest.DiscountedPrice = dest.ListPrice - dest.Discount);

            CreateMap<DTOOrders, Order>()
                .ForMember(dest => dest.StaffId, opt => opt.MapFrom(src => src.staff_id))
                .ForMember(dest => dest.StoreId, opt => opt.MapFrom(src => src.store_id))
                .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.order_status))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.customer_id))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.order_date))
                .ForMember(dest => dest.RequiredDate, opt => opt.MapFrom(src => src.required_date))
                .ForMember(dest => dest.ShippedDate, opt => opt.MapFrom(src => src.shipped_date));

            CreateMap<DTOBrandOrders, BrandOrders>()
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.brand_id))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.brand_name))
                .ForMember(dest => dest.TotalOrders, opt => opt.MapFrom(src => src.total_Orders));

            CreateMap<DTOProductOrders,ProductOrders>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.product_id))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.product_name))
                .ForMember(dest => dest.TotalOrders, opt => opt.MapFrom(src => src.total_Orders));
            //
            CreateMap<DTOEmployee, Employee>()
                .ForMember(dest => dest.StaffId, opt => opt.MapFrom(src => src.staff_id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.first_name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.last_name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.phone))
                .ForMember(dest => dest.StoreId, opt => opt.MapFrom(src => src.store_id));
        }
    }
}
