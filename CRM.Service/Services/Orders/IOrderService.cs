using CRM.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Service.Services.Orders
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderModel>> GetOrdersAsync();
        Task<IEnumerable<OrderModel>> GetOrdersAsync(DateTime dateFrom, DateTime dateTo);
        Task<IEnumerable<OrderModel>> GetOrdersAsync(DateTime dateFrom, DateTime dateTo, string rep, int place);
        Task<IEnumerable<OrderModel>> GetOrdersAsync(DateTime dateFrom, DateTime dateTo, string rep);
        Task<IEnumerable<OrderModel>> GetOrdersAsync(DateTime dateFrom, DateTime dateTo, int place);
        Task<OrderModel> GetOrderAsync(int id);
        Task<OrderModel> InsertOrderAsync(OrderModel order);
        Task<IEnumerable<OrderModel>> InsertOrderListAsync(IEnumerable<OrderModel> orders);
        Task<OrderModel> UpdateOrderAsync(OrderModel order);
        void DeleteOrder(int id);
    }
}
