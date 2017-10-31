using CRM.Domain.Entities;
using CRM.Domain.Repositories;
using CRM.EntityFramework.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using CRM.Domain.RequestIdentity;

namespace CRM.EntityFramework.Repositories
{
    public class OrderRepository : ORMBaseRepository<Order, int>, IOrderRepository
    {
        IRequestIdentityProvider requestIdentityProvider;

        public OrderRepository(DataContext context, IRequestIdentityProvider requestIdentityProvider) : base(context)
        {
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public void DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .Orders
               .Where(t => t.TenantId == user.TenantId && t.IsDeleted == false)
               .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrders(DateTime dateFrom, DateTime dateTo)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();

            return await GetDataContext()
               .Orders
               .Where(t => t.TenantId == user.TenantId
               && (DbFunctions.TruncateTime(t.AddedDate) >= dateFrom && DbFunctions.TruncateTime(t.AddedDate) <= dateTo))
               .Include(u => u.CreatorUser)
               .Include(p => p.Place)              
               .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrders(DateTime dateFrom, DateTime dateTo, int place)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();

            return await GetDataContext()
               .Orders
               .Where(t => t.TenantId == user.TenantId
               && (DbFunctions.TruncateTime(t.AddedDate) >= dateFrom && DbFunctions.TruncateTime(t.AddedDate) <= dateTo)
               && t.PlaceId == place)
               .Include(u => u.CreatorUser)
               .Include(p => p.Place)               
               .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrders(DateTime dateFrom, DateTime dateTo, string rep)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();

            return await GetDataContext()
               .Orders
               .Where(t => t.TenantId == user.TenantId
               && (DbFunctions.TruncateTime(t.AddedDate) >= dateFrom && DbFunctions.TruncateTime(t.AddedDate) <= dateTo)
               && t.CreatorUserId == rep)
               .Include(u => u.CreatorUser)
               .Include(p => p.Place)
               .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrders(DateTime dateFrom, DateTime dateTo, string rep, int place)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();

            return await GetDataContext()
               .Orders
               .Where(t => t.TenantId == user.TenantId
               && (DbFunctions.TruncateTime(t.AddedDate) >= dateFrom && DbFunctions.TruncateTime(t.AddedDate) <= dateTo)
               && t.CreatorUserId == rep && t.PlaceId == place)
               .Include(u => u.CreatorUser)
               .Include(p => p.Place)               
               .ToListAsync();
        }

        public Task<Order> InsertOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> InsertOrderList(IEnumerable<Order> orders)
        {
            GetDataContext().Orders.AddRange(orders);
            return orders;
        }

        public Task<Order> UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
