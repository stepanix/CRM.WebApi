using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Domain.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<IEnumerable<Order>> GetOrders(DateTime dateFrom, DateTime dateTo);
        Task<IEnumerable<Order>> GetOrders(DateTime dateFrom, DateTime dateTo, string rep, int place);
        Task<IEnumerable<Order>> GetOrders(DateTime dateFrom, DateTime dateTo, string rep);
        Task<IEnumerable<Order>> GetOrders(DateTime dateFrom, DateTime dateTo, int place);
        Task<Order> GetOrder(int id);
        Task<Order> GetOrder(string repoId);
        Task<Order> InsertOrder(Order order);
        IEnumerable<Order> InsertOrderList(IEnumerable<Order> orders);
        Task<Order> UpdateOrder(Order order);
        void DeleteOrder(int id);
    }
}
