using ExampleApplication.Application.Interfaces;
using ExampleApplication.Domain.ProductModels;
using MediatR;

namespace ExampleApplication.Application.Products;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
{
    private readonly IProductHolder _productHolder;
    
    public GetAllProductsQueryHandler(IProductHolder productHolder)
    {
        _productHolder = productHolder;
    }
    
    public Task<IEnumerable<Product>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
    {
        return _productHolder.GetAllProducts();
    }
}