using MediatR;
using ExampleApplication.Domain.ProductModels;

namespace ExampleApplication.Application.Products;
    public record GetProductByIdQuery(int id) : IRequest<Product>
    {
    }   
