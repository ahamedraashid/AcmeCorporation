using System;
using System.Linq;
using AcmeCorporation.API.Data.Models;
using AcmeCorporation.API.Dto;
using AcmeCorporation.API.Shared.Enums;
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
            .ForMember(x => x.TransactionCount, opt => opt.MapFrom(s => s.Transactions.Count()))
            .ForMember(x => x.Status, opt => opt.MapFrom(t => UpdateStatus(t.StartingTime, t.EndingTime, t.Transactions.Count)));
            CreateMap<User, UserDto>();

            // Dto's to domain objects
            CreateMap<ProductDto, Product>().ForMember(x => x.Photos, opt => opt.Ignore())
            .ForMember(x => x.Status, opt => opt.MapFrom(t => UpdateStatus(t.StartingTime, t.EndingTime, t.TransactionCount))); 
            CreateMap<UserDto, User>();
        }

        private ProductStatus UpdateStatus(DateTime startingTime, DateTime endingTime, int transactionCount)
        {
            if (startingTime != null && endingTime != null)
            {
                if (startingTime < DateTime.Now && endingTime > DateTime.Now)
                {
                    return ProductStatus.Active;
                }
                else if (startingTime > DateTime.Now && endingTime > DateTime.Now)
                {
                    return ProductStatus.Inactive;

                }
                else if (endingTime < DateTime.Now && transactionCount > 0)
                {
                    return  ProductStatus.Sold;
                }
                else
                {
                     return ProductStatus.Unsold;
                }
            }
            else
            {
                return ProductStatus.Inactive;
            }
        }
    }
}