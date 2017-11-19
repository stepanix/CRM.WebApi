using CRM.Domain.Entities;
using CRM.Domain.Repositories;
using CRM.EntityFramework.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using System;
using CRM.Domain.RequestIdentity;

namespace CRM.EntityFramework.Repositories
{
    public class OrderItemRepository : ORMBaseRepository<OrderItem, int>, IOrderItemRepository
    {
        IRequestIdentityProvider requestIdentityProvider;

        public OrderItemRepository(DataContext context, IRequestIdentityProvider requestIdentityProvider) : base(context)
        {
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItems(string repoId)
        {
            return await GetDataContext()
              .OrderItems
              .Where(r => r.RepoId == repoId)
              .ToListAsync();
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItems(DateTime dateFrom, DateTime dateTo)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .OrderItems
               .Where(t => t.TenantId == user.TenantId && t.IsDeleted == false && (DbFunctions.TruncateTime(t.AddedDate) >= dateFrom && DbFunctions.TruncateTime(t.AddedDate) <= dateTo))
               .Include(p=> p.Product)
               .Include(o=> o.Order)
               .Include(o => o.Order.Place)
               .ToListAsync();
        }

        public IEnumerable<OrderItem> InsertOrderList(IEnumerable<OrderItem> orderItems)
        {
            GetDataContext().OrderItems.AddRange(orderItems);
            return orderItems;
        }
    }
}
