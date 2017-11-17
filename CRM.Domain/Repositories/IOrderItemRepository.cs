
using CRM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Domain.Repositories
{
    public interface IOrderItemRepository : IBaseRepository<OrderItem>
    {
        IEnumerable<OrderItem> InsertOrderList(IEnumerable<OrderItem> orderItems);
        Task<IEnumerable<OrderItem>> GetOrderItems(string repoId);
    }
}
