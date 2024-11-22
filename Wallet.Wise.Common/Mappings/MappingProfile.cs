using AutoMapper;
using System;
using Wallet.Wise.BLL.DTOs;
using Wallet.Wise.DAL.Entities;

namespace Wallet.Wise.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryWithAmontDto>()
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Records.Sum(r => r.Amount)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CurrencyCode, opt => opt.MapFrom(src => src.CurrencyCode))
                .ForMember(dest => dest.CategoryType, opt => opt.MapFrom(src => src.CategoryType))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            
            CreateMap<Record, RecordDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest=>dest.Id,opt=>opt.MapFrom(src=>src.Id));
            
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CurrencyCode, opt => opt.MapFrom(src => src.CurrencyCode))
                .ForMember(dest => dest.CategoryType, opt => opt.MapFrom(src => src.CategoryType))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
