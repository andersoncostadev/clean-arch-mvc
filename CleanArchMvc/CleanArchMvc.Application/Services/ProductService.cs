﻿using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;   
        private readonly IMapper _mapper;
        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator= mediator;
            _mapper= mapper;
        }
        public async Task Add(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }

        public async Task<ProductDTO> GetProductById(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id!.Value);

            if (productByIdQuery == null)
                throw new Exception($"Entity could not be loaded");

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        //public async Task<ProductDTO> GetProductCategory(int? id)
        //{
        //    var productCategory = new GetProductByIdQuery(id!.Value);

        //    if (productCategory == null)
        //        throw new Exception($"Entity could not be loaded");

        //    var result = await _mediator.Send(productCategory);

        //    return _mapper.Map<ProductDTO>(result);
        //}

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();

            if(productsQuery == null)
                throw new Exception($"Entity could not be loaded");

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task Remove(int? id)
        {
            var productRemovcommand = new ProductRemoveCommand(id!.Value);


            if (productRemovcommand == null)
                throw new Exception($"Entity could not be loaded");

            await _mediator.Send(productRemovcommand);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateCommand);
        }
    }
}
