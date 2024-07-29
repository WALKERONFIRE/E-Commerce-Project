using AutoMapper;
using E_CommerceProject0.Model;

namespace E_CommerceProject0.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegister, User>();

            CreateMap<User, UserRegister>();

            CreateMap<Order, OrderDTO>();

            CreateMap<OrderItem, OrderData>();

            CreateMap<OrderData, OrderItem>();

            CreateMap<OrderDTO, Order>();

            CreateMap<Vendor , VendorRegister>();

            CreateMap<VendorRegister, Vendor>();

            CreateMap<Product, ProductAdder>();

            CreateMap<ProductAdder, Product>();
        }
    }
}
