using CleanArchitectureStudy.Domain.Entities;
using MediatR;

namespace CleanArchitectureStudy.Application.Products.Commands
{
    public class ProductRemoveCommand : IRequest<Product>
    {
        public int Id { get; set; }
        public ProductRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
