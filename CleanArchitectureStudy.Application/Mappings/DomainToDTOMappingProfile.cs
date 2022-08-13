using AutoMapper;
using CleanArchitectureStudy.Application.DTOs;
using CleanArchitectureStudy.Domain.Entities;

namespace CleanArchitectureStudy.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
    }
}
