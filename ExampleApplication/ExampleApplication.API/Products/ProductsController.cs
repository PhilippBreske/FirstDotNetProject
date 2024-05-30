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
    public async Task<ActionResult<IEnumerable<ProductResponse>>> GetAllProducts()
    {
        var query = new GetAllProductsQuery();
        var products = await _mediator.Send(query);
        var response = products.Select(p => new ProductResponse{ Name = p.Name, Price = p.Price});
        return Ok(response);
    }

    //show product by ID
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        var query = new GetProductByIdQuery(id);
        var product = await _mediator.Send(query);
        return Ok(new ProductResponse{Name = product.Name, Price = product.Price});
    }

    //create new product
    [HttpPost ("{nid:int}/{nname}/{nprice:double}")]
    public async Task<ActionResult> CreateProduct(int nid, string nname, double nprice)
    {
        var product = new Product {Id = nid, Name = nname, Price = nprice};
        var query = new AddProductCommand(product);
        var answer = await _mediator.Send(query);
        return Ok(new ProductResponse{Name = product.Name, Price = product.Price});
    }
}