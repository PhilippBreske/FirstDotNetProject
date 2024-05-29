using Microsoft.Extensions.DependencyInjection;
using MediatR;
using ExampleApplication.Application.Products; // Make sure to import the namespace containing your handlers

namespace ExampleApplication.Application;

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
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection)));
        
        return serviceCollection;
    }
}