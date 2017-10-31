using System.Collections.Generic;
using CRM.Domain.Entities;
using CRM.Domain.Repositories;
using CRM.EntityFramework.Repositories.Base;

namespace CRM.EntityFramework.Repositories
{
    public class OrderItemRepository : ORMBaseRepository<OrderItem, int>, IOrderItemRepository
    {
        public OrderItemRepository(DataContext context) : base(context)
        {
        }

        public IEnumerable<OrderItem> InsertOrderList(IEnumerable<OrderItem> orderItems)
        {
            GetDataContext().OrderItems.AddRange(orderItems);
            return orderItems;
        }
    }
}
