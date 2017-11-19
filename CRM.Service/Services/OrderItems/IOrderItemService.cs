
using CRM.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Service.Services.OrderItems
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemModel>> InsertOrderListAsync(IEnumerable<OrderItemModel> orderItems);
        Task<IEnumerable<OrderItemModel>> GetOrderItemsAsync(DateTime dateFrom, DateTime dateTo);
    }
}
