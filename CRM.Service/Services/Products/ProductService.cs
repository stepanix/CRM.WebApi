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
        IUserRepository userRepository;
        IRequestIdentityProvider requestIdentityProvider;


        public ProductService(IMapper mapper, ITenantRepository tenantRepository, IUserRepository userRepository, IProductRepository productRepository, IRequestIdentityProvider requestIdentityProvider)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
            this.requestIdentityProvider = requestIdentityProvider;
            this.userRepository = userRepository;
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
            return mapper.Map<IEnumerable<ProductModel>>(await productRepository.GetProducts());
        }

        public async Task<ProductModel> InsertProductAsync(ProductModel product)
        {
            product.AddedDate = DateTime.Now;
            var user = await userRepository.GetUser();
            product.TenantId = user.TenantId;
            product.CreatorUserId = requestIdentityProvider.UserId;
            product.LastModifierUserId = requestIdentityProvider.UserId;
            var newProduct = await productRepository.InsertAsync(mapper.Map<Product>(product));
            await productRepository.SaveChangesAsync();
            return mapper.Map<ProductModel>(newProduct);
        }

        public async Task<ProductModel> UpdateProductAsync(ProductModel product)
        {
            var productForUpdate = await productRepository.GetAsync(product.Id);
            var user = await userRepository.GetUser();

            productForUpdate.ModifiedDate = DateTime.Now;
            productForUpdate.Name = product.Name;
            productForUpdate.Price = product.Price;
            productForUpdate.TenantId = user.TenantId;
            productForUpdate.LastModifierUserId = requestIdentityProvider.UserId;
            await productRepository.SaveChangesAsync();
            return mapper.Map<ProductModel>(productForUpdate);
        }

    }
}
