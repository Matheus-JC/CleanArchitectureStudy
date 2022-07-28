using AutoMapper;
using CleanArchitectureStudy.Application.DTOs;
using CleanArchitectureStudy.Application.Products.Commands;

namespace CleanArchitectureStudy.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}
