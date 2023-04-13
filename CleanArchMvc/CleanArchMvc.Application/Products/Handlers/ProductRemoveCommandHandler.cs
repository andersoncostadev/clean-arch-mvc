using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entites;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private IProductRepository _repository;

        public ProductRemoveCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetProductByIdAsync(request.Id);

            if (product == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                var result = await _repository.RemoveProductAsync(product);
                return result;
            }
        }
    }
}
