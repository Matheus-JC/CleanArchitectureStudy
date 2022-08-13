using CleanArchitectureStudy.Application.DTOs;
using CleanArchitectureStudy.Application.Intrerfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureStudy.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
    {
        var products = await _productService.GetProducts();

        if(products == null)
        {
            return NotFound("Products not found");
        }

        return Ok(products);
    }

    [HttpGet("{id:int}", Name = "GetProduct")]
    public async Task<ActionResult<ProductDTO>> Get(int id)
    {
        var product = await _productService.GetById(id);

        if(product == null)
        {
            return NotFound("Product not found");
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProductDTO productDto)
    {
        if(productDto == null)
        {
            return BadRequest("Invalid Data");
        }

        await _productService.Create(productDto);

        return new CreatedAtRouteResult(
            "GetProduct",
            new { id = productDto.Id },
            productDto
        );
    }

    [HttpPut]
    public async Task<ActionResult<ProductDTO>> Put(int id, [FromBody] ProductDTO productDto)
    {
        if(id != productDto.Id || productDto == null)
        {
            return BadRequest();
        }

        await _productService.Update(productDto);

        return Ok(productDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ProductDTO>> Delete(int id)
    {
        var product = await _productService.GetById(id);

        if (product == null)
        {
            return NotFound("Product not found");
        }

        await _productService.Remove(id);

        return Ok(product);
    }
}
