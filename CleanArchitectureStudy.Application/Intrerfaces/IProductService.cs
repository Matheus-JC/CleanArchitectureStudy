using CleanArchitectureStudy.Application.DTOs;

namespace CleanArchitectureStudy.Application.Intrerfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetById(int? id);
        Task Create(ProductDTO categoryDTO);
        Task Update(ProductDTO categoryDTO);
        Task Remove(int? id);
    }
}
