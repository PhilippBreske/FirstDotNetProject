using MediatR;
using ExampleApplication.Domain.ProductModels;
using System.Collections.Generic;

namespace ExampleApplication.Application.Products
{
    public record AddProductCommand(Product Prodcut) : IRequest<Unit>;
}