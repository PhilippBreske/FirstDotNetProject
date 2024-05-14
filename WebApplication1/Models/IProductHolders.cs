namespace WebApplication1.Models;

public interface IProductHolders
{
    Product? GetProductById(int id);
    List<Product> GetProducts();
    void AddProduct(Product product);
    void RemoveProduct(int id);
}