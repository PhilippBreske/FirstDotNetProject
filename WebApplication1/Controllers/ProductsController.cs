using Microsoft.AspNetCore.Mvc;  
using WebApplication1.Models;
namespace WebApplication1.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    
    private readonly ProductHolder _productHolder;
    
    //dependency injection of ProductHolder
    public ProductsController(ProductHolder productHolder){
        _productHolder = productHolder;
    }
    
    //show all products
    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = _productHolder.GetProducts();
        return Ok(products);
    }

    //show product by ID
    [HttpGet("{id:int}")]
    public IActionResult GetProductById(int id)
    {
        var product = _productHolder.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    //create new product
    [HttpPost]
    public IActionResult CreateProduct([FromBody] Product product)
    {
        _productHolder.AddProduct(product);
        return Created($"api/products/{product.Id}", product);
    }
    
    //Delete product by ID
    [HttpDelete("{id:int}")]
    public IActionResult DeleteProduct(int id) {
        _productHolder.RemoveProduct(id);
        return Ok("deleted: " + id);
    }
}