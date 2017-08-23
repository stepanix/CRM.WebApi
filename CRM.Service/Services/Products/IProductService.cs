using CRM.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Service.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetProductsAsync();
        Task<ProductModel> GetProductAsync(int id);
        Task<ProductModel> InsertProductAsync(ProductModel product);
        Task<ProductModel> UpdateProductAsync(ProductModel place);
        void DeleteProduct(int id);
    }
}
