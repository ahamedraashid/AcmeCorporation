using System.Linq;
using AcmeCorporation.API.Data.Models;
using AcmeCorporation.API.Dto;
using AutoMapper;

namespace AcmeCorporation.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain objects to Dto's
            CreateMap<Product, ProductDto>()
            .ForMember(x => x.Photos, opt => opt.Ignore())
            .ForMember(x => x.ImageUrls, opt => opt.MapFrom(s => s.Photos.Select(m => m.Filename)))
            .ForMember(x => x.TransactionCount, opt => opt.MapFrom(s => s.Transactions.Count()));
            CreateMap<User, UserDto>();


            // Dto's to domain objects
            CreateMap<ProductDto, Product>().ForMember(x => x.Photos, opt => opt.Ignore()); 
            // .ForMember(x => x.StartingTime, opt => opt.MapFrom(s => s.StartingTime.ToUniversalTime()))
            // .ForMember(x => x.EndingTime, opt => opt.MapFrom(s => s.EndingTime.ToUniversalTime()));
            CreateMap<UserDto, User>();
        }
    }
}