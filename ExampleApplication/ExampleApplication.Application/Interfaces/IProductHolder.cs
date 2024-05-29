using ExampleApplication.Domain.ProductModels;
namespace ExampleApplication.Application.Interfaces;


/// <summary>
/// A holder for products.
/// </summary>
public interface IProductHolder
{
    /// <summary>
    /// Get all products.
    /// </summary>
    /// <returns> Collection of Products </returns>
    Task<IEnumerable<Product>> GetAllProducts();
    /// <summary>
    /// get specific product by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns> a single Product </returns>
    Task<Product?> GetProductById(int id);
    
    /// <summary>
    /// adds a given Product to the collection
    /// </summary>
    /// <param name="product"></param>
    /// <returns> nothing </returns>
    Task AddProduct(Product product);
}

