using AutoMapper;
using MorelyTrends.Domain.Entities;
using MorelyTrends.Application.DTOs;

public class SellerProfile : Profile
{
    public SellerProfile()
    {
        CreateMap<CreateEditSellerDto, Seller>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.User, opt => opt.Ignore())
            .ForMember(dest => dest.Payouts, opt => opt.Ignore())
            .ForMember(dest => dest.Products, opt => opt.Ignore())
            .ForMember(dest => dest.Orders, opt => opt.Ignore())
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

        CreateMap<SellerAddressDto, SellerAddress>();
    }
}
