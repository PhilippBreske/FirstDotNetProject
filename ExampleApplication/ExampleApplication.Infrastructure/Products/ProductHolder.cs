using ExampleApplication.Application.Interfaces;
using ExampleApplication.Domain.ProductModels;
using ExampleApplication.Infrastructure.ProductDataHolders;

namespace ExampleApplication.Infrastructure.Products;


public class ProductHolder: IProductHolder
{
    
    ProductDataHolder _ProductDataHolder;
    
    public ProductHolder(ProductDataHolder productDataHolder)
    {
        _ProductDataHolder = productDataHolder;
    }

    public Task AddProduct(Product product)
    {
        _ProductDataHolder.AddProduct(product);
        return Task.CompletedTask;
    }
    
    public Task<Product?> GetProductById(int id)
    {
        return Task.FromResult(_ProductDataHolder.GetProductById(id));
    }
    
    public Task<IEnumerable<Product>> GetAllProducts()
    {
        return Task.FromResult(_ProductDataHolder.GetProducts());
    }
}