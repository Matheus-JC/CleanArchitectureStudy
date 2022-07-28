using CleanArchitectureStudy.Domain.Entities;
using MediatR;

namespace CleanArchitectureStudy.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
