using CRM.Domain.Model;
using System.Collections.Generic;
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
