using ExampleApplication.Application.Interfaces;
using ExampleApplication.Domain.ProductModels;
namespace ExampleApplication.Application.Products;
using MediatR;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly IProductHolder _productHolder;
    
    public GetProductByIdQueryHandler(IProductHolder productHolder)
    {
        _productHolder = productHolder;
    }
    
    public async Task<Product?> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await _productHolder.GetProductById(query.id);
        //check if Product is null and mark not found with Id = -1 and Price = 0.0
        return product ?? new Product{Id = -1, Price = 0.0};
    }
    
    public async Task<Product?> Handle(int id)
    {
        var product = await _productHolder.GetProductById(id);
        //check if Product is null and mark not found with Id = -1 and Price = 0.0
        return product ?? new Product{Id = -1, Price = 0.0};
    }
}