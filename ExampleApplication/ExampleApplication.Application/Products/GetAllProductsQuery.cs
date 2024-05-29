using System.Collections.Generic;
using MediatR;
using ExampleApplication.Domain.ProductModels;

namespace ExampleApplication.Application.Products
{
    public record GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}