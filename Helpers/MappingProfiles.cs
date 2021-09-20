using System.Linq;
using AutoMapper;
using ELSAPI.Dto;
using ELSAPI.Entities;
using ELSAPI.Entities.OrderAggregate;

namespace ELSAPI.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<Product, GetProductDto>()
                .ForMember(s => s.Category, o => o.MapFrom(d => d.Category))
                .ForMember(s => s.MainImageUrl, o => o.MapFrom(d => d.Colors.FirstOrDefault(c => c.IsMain == true).Url));

            CreateMap<ProductColor, ProductColorDto>();
            CreateMap<ProductColorDto, ProductColor>();

            CreateMap<ColorSize, ColorSizeDto>()
                .ForMember(s => s.ColorId, o => o.MapFrom(d => d.ProductColor.Id));

            CreateMap<Product, GetSingleProductDto>()
                .ForMember(s => s.Category, o => o.MapFrom(d => d.Category))
                .ForMember(s => s.MainImageUrl, o => o.MapFrom(d => d.Colors.FirstOrDefault(c => c.IsMain == true).Url))
                .ForMember(s => s.Colors, o => o.MapFrom(d => d.Colors));

            CreateMap<ProductColor, MiniProductColorDto>();

            CreateMap<BasketItem, BasketItemDto>();
            CreateMap<BasketItemDto, BasketItem>();

            CreateMap<CreateBasketItemDto, BasketItemDto>();

            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderDto>();

            CreateMap<PersonalInfoDto, PersonalInfo>();
            CreateMap<PersonalInfo, PersonalInfoDto>();

            CreateMap<CreateAddressDto, Address>();
            CreateMap<Address, CreateAddressDto>();

            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>();
        }
    }
}