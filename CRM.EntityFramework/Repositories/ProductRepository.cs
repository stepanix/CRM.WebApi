using CRM.Domain.Entities;
using CRM.Domain.Repositories;
using CRM.EntityFramework.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.EntityFramework.Repositories
{
    public class ProductRepository : ORMBaseRepository<Product, int>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Product> InsertProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
