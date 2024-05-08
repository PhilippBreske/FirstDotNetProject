namespace WebApplication1.Models;


//Database simulation class for products
public class ProductHolder {
    //underscore is a naming convention for private fields
    private readonly List<Product> _products;
    
    //initialize the list with a single product
    public ProductHolder() {
        _products = new List<Product>{
            new Product {
                Id = 1, Name = "Product 1", Price = 10.0 
            }
        };
    }
    
    //return product for given ID
    public Product? GetProductById(int id) {
        return _products.FirstOrDefault(p => p.Id == id);
    }
    
    //return all products
    public List<Product> GetProducts() {
        return _products;
    }
    
    //add product to the list
    public void AddProduct(Product product) {
        _products.Add(product);
    }
    
    //remove product from the list
    public void RemoveProduct(int id){
        _products.Remove(_products.First(p => p.Id == id));
    }
}