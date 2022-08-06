using AutoMapper;
using CleanArchitectureStudy.Application.DTOs;
using CleanArchitectureStudy.Application.Intrerfaces;
using CleanArchitectureStudy.Application.Products.Commands;
using CleanArchitectureStudy.Application.Products.Queries;
using MediatR;

namespace CleanArchitectureStudy.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
            {
                throw new Exception($"Error when searching for products");
            }

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var productByIdQuery = new GetProductByIdQuery(id.Value);

            if(productByIdQuery == null)
            {
                throw new Exception($"Product could not be loaded");
            }

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        public async Task Create(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            if(id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var productRemoveCommand = new ProductRemoveCommand(id.Value);

            if(productRemoveCommand == null)
            {
                throw new Exception($"Error removing product");
            }

            await _mediator.Send(productRemoveCommand);
        }
    }
}
