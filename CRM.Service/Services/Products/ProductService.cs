using AutoMapper;
using CRM.Domain.Entities;
using CRM.Domain.Model;
using CRM.Domain.Repositories;
using CRM.Domain.RequestIdentity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Service.Services.Products
{
    public class ProductService : IProductService
    {
        IProductRepository productRepository;
        IMapper mapper;
        IRequestIdentityProvider requestIdentityProvider;

        public ProductService(IMapper mapper, IProductRepository productRepository, IRequestIdentityProvider requestIdentityProvider)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public void DeleteProduct(int id)
        {
            productRepository.Delete(id);            
        }

        public async Task<ProductModel> GetProductAsync(int id)
        {
            return mapper.Map<ProductModel>(await productRepository.GetAsync(id));
        }

        public async Task<IEnumerable<ProductModel>> GetProductsAsync()
        {
            return mapper.Map<IEnumerable<ProductModel>>(await productRepository.GetAllAsync());
        }

        public async Task<ProductModel> InsertProductAsync(ProductModel product)
        {
            product.AddedDate = DateTime.Now;
            product.CreatorUserId = requestIdentityProvider.UserId;
            var newProduct = await productRepository.InsertAsync(mapper.Map<Product>(product));
            await productRepository.SaveChangesAsync();
            return mapper.Map<ProductModel>(newProduct);
        }

        public async Task<ProductModel> UpdateProductAsync(ProductModel product)
        {
            var productForUpdate = await productRepository.GetAsync(product.Id);
            productForUpdate.ModifiedDate = DateTime.Now;
            productForUpdate.Name = product.Name;
            productForUpdate.LastModifierUserId = product.LastModifierUserId;
            await productRepository.SaveChangesAsync();
            return mapper.Map<ProductModel>(productForUpdate);
        }

    }
}
