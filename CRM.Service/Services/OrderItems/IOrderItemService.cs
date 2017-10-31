
using CRM.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Service.Services.OrderItems
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemModel>> InsertOrderListAsync(IEnumerable<OrderItemModel> orderItems);
    }
}
