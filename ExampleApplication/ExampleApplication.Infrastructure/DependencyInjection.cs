using Microsoft.Extensions.DependencyInjection;
using MediatR;
using ExampleApplication.Application.Products; // Make sure to import the namespace containing your handlers
using ExampleApplication.Infrastructure.ProductDataHolders;
using ExampleApplication.Infrastructure.Products;
using ExampleApplication.Application.Interfaces;

namespace ExampleApplication.Infrastructure;

/// <summary>
/// Methods for dependency injection.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds the necessary dependencies for the application layer.
    /// </summary>
    /// <param name="serviceCollection">The service collection.</param>
    /// <returns>The service collection with the add dependencies.</returns>
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProductHolder, ProductHolder>();
        serviceCollection.AddSingleton<ProductDataHolder>();
        return serviceCollection;
    }
}