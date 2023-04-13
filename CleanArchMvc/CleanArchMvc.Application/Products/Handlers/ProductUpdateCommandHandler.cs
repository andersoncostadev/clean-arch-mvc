using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entites;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _repository;

        public ProductUpdateCommandHandler(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetProductByIdAsync(request.Id);

            if (product == null)
            {
                throw new ArgumentException($"Error creating entity.");
            }
            else
            {
                product.UpdateProduct(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);

                return await _repository.UpdateProductAsync(product);
            }
        }
    }
}
