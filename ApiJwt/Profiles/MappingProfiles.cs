using ApiJwt.Dtos;
using AutoMapper;
using Domain.Entities;

namespace ApiJwt.Profiles;
    public class MappingProfiles : Profile
    {
        public MappingProfiles(){
            CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName ))
            .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.CreatedDate))
            .ReverseMap();
            CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CategoryName ))
            .ReverseMap();
            CreateMap<Brand, BrandDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.BrandName ))            
            .ReverseMap();
            CreateMap<Product, ProductListDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName ))   
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.BrandName ))           
            .ReverseMap()
            .ForMember(org => org.Brand, dest => dest.Ignore())           
            .ForMember(org => org.Category, dest => dest.Ignore());    
        
        
        }
    }