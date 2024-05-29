using Microsoft.AspNetCore.Mvc;  
using MediatR;
using ExampleApplication.Domain.ProductModels;
using ExampleApplication.Application.Products;

namespace ExampleApplication.API.Products;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    //dependency injection of ProductHolder
    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    //show all products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
    {
        var query = new GetAllProductsQuery();
        var products = await _mediator.Send(query);
        return Ok(products);
    }

    //show product by ID
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        var query = new GetProductByIdQuery(id);
        var product = await _mediator.Send(query);
        return Ok(product);
    }

    //create new product
    [HttpPost]
    public async Task<ActionResult> CreateProduct([FromBody] Product product)
    {
        var query = new AddProductCommand(product);
        var answer = await _mediator.Send(query);
        return Ok();
    }
}