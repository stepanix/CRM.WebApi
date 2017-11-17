using CRM.Domain.Entities;
using CRM.Domain.Repositories;
using CRM.EntityFramework.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;


namespace CRM.EntityFramework.Repositories
{
    public class OrderItemRepository : ORMBaseRepository<OrderItem, int>, IOrderItemRepository
    {
        public OrderItemRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItems(string repoId)
        {
            return await GetDataContext()
              .OrderItems
              .Where(r => r.RepoId == repoId)
              .ToListAsync();
        }

        public IEnumerable<OrderItem> InsertOrderList(IEnumerable<OrderItem> orderItems)
        {
            GetDataContext().OrderItems.AddRange(orderItems);
            return orderItems;
        }
    }
}
