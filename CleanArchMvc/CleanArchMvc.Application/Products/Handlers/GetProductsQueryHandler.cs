﻿using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entites;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _repository;
        public GetProductsQueryHandler(IProductRepository productRepository) 
        {
            _repository= productRepository;
        }

        async Task<IEnumerable<Product>> IRequestHandler<GetProductsQuery, IEnumerable<Product>>.Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetProductsAsync();
        }
    }
}
