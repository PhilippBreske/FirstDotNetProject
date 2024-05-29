using ExampleApplication.Application.Interfaces;
using ExampleApplication.Domain.ProductModels;
using MediatR;
namespace ExampleApplication.Application.Products;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Unit>
{
    private readonly IProductHolder _productHolder;
    
    public AddProductCommandHandler(IProductHolder productHolder)
    {
        _productHolder = productHolder;
    }
    
    public async Task<Unit> Handle(AddProductCommand query, CancellationToken cancellationToken)
    {
        await _productHolder.AddProduct(query.Prodcut);
        return Unit.Value;
    }
}