using AutoMapper;
using BussinessObject.DTOS;
using DataAccess.DataAccess;

namespace BussinessObject.Mapper;

public class ApplicationMapper : Profile
{
    public ApplicationMapper()
    {
        CreateMap<Product, Menu>()
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
            .ForMember(dest => dest.Image, act => act.MapFrom(src => src.Image))
            .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
            .ForMember(dest => dest.Quantity, act => act.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.UnitPrice, act => act.MapFrom(src => src.UnitPrice))
            .ForMember(dest => dest.CategoryName, act => act.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.SupplierName, act => act.MapFrom(src => src.Supplier.CompanyName));

        CreateMap<CustomerDTOS, Customer>()
            .ForMember(dest => dest.Id, mO => mO.MapFrom(src => new Guid()))
            .ForMember(dest => dest.City, mO => mO.MapFrom(src => src.City))
            .ForMember(dest => dest.Country, mO => mO.MapFrom(src => src.Country))
            .ForMember(dest => dest.Email, mO => mO.MapFrom(src => src.Email))
            .ForMember(dest => dest.City, mO => mO.MapFrom(src => src.City))
            .ForMember(c => c.Account, act => act.MapFrom(src => new Account
            {
                Password = src.Password,
                UserName = src.UserName,
                Status = "ACTIVE",
                Type = "CUSTOMER"
            }));
        
        
    }
}