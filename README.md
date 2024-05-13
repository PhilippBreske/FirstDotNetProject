## Endpunkte in Controllern
- Endpunkte sind Methoden oder Aktionen, die HTTP-Anfragen entgegennehmen
- Ein Endpunkt (auch Route genannt) definiert unter welcher URL und über welche HTTP-Methode (GET,POST,PUT,DELETE) Anfrage an bestimmten Controller gesendet wird

### Beispielcode für das Definieren von Endpunkten:
```C#
[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok("Here are some products.");
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        return Ok($"Product with ID: {id}");
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] Product product)
    {
        // Logik zum Hinzufügen eines Produkts
        return Created($"api/products/{product.Id}", product);
    }
}
```
### Beispiel für POST Anfrage mittels curl:
```sh
curl -X POST http://localhost:5076/api/products \
  -H 'Content-Type: application/json' \
  -d '{
    "Id": 2,
    "Name": "Example Product",
    "Price": 9.99
}'

curl -X POST http://localhost:5076/api/products \
  -H 'Content-Type: application/json' \
  -d '{
    "Id": 1,
    "Name": "Example Product",
    "Price": 9.99                                                                                                  
}'


```
### Beispiel für DELETE Anfrage mittels curl:
```sh
curl -X DELETE "http://localhost:5076/api/products/1"
```

## dependency injection
- design pattern, das dabei hilft Abhängigkeiten von Klassen auf andere Klassen zu vermeiden
- soll Kopplungen innerhalb der Applikation klein halten
### weitere Vorteile:
- **Wiederverwendbarkeit:** Entwickler können einen Codeblock wiederverwenden, da man Codeblöcke in anderen Klassen nutzen kann
- **Einfaches Testen:** für Unit-Testing-Verfahren ermöglicht Dependency Injection den Entwicklern, Mock-Objekte für das Testen der Anwendung zu verwenden
- **Erweiterbarkeit:** Anwendung wird flexibler und skalierbarer
- **losere Kopplung:** Kopplungen der Abhängigkeiten führt zu einem genaueren Ergebnis, auch wenn Sie eine einzelne Klasse ändern, ohne dass dies Auswirkungen auf die abhängige Klasse hat


### Beispielcode aus Program.cs
ProductHolder als MockUp für Datenbank
```C#
. . .

// Make the ProductHolder class available for dependency injection
builder.Services.AddSingleton<ProductHolder>();

. . .
```

### Beispielcode aus ProductsController.cs
```C#
. . .

private readonly ProductHolder _productHolder;
    
//dependency injection of ProductHolder
public ProductsController(ProductHolder productHolder){
    _productHolder = productHolder;
}

//show all products
[HttpGet]
public IActionResult GetProducts(){
    var products = _productHolder.GetProducts();
    return Ok(products);
}

. . .
```

## Quellen:
#### dependency injection:
- https://positiwise.com/blog/dependency-injection-in-net-core-with-example
- https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-8.0
- https://learn.microsoft.com/de-de/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio
#### Endpunkte in Controllern:
- https://learn.microsoft.com/de-de/aspnet/core/mvc/controllers/routing?view=aspnetcore-8.0
#### Beispiel Projekt
- https://github.com/PhilippBreske/FirstDotNetProject
