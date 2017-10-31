
using CRM.Domain.Entities;
using System.Collections.Generic;

namespace CRM.Domain.Repositories
{
    public interface IOrderItemRepository : IBaseRepository<OrderItem>
    {
        IEnumerable<OrderItem> InsertOrderList(IEnumerable<OrderItem> orderItems);
    }
}
