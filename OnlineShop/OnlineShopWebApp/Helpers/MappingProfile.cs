using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Сharacteristics, СharacteristicsViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<BasketItem, BasketItemViewModel>().ReverseMap();
            CreateMap<Basket, BasketViewModel>().ReverseMap();       
            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ForMember(x => x.Login, opt => opt.MapFrom(o => o.Email)).ReverseMap();
            CreateMap<IdentityRole, RoleViewModel>().ReverseMap();
        }
    }
}
