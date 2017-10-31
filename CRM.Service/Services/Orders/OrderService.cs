using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.Model;
using CRM.Domain.Repositories;
using AutoMapper;
using CRM.Domain.RequestIdentity;
using CRM.Domain.Entities;

namespace CRM.Service.Services.Orders
{
    public class OrderService : IOrderService
    {
        IOrderRepository orderRepository;
        IMapper mapper;
        IUserRepository userRepository;
        IRequestIdentityProvider requestIdentityProvider;

        public OrderService(IMapper mapper, IOrderRepository orderRepository, 
            IUserRepository userRepository, 
            IRequestIdentityProvider requestIdentityProvider)
        {
            this.mapper = mapper;
            this.orderRepository = orderRepository;
            this.userRepository = userRepository;
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public void DeleteOrder(int id)
        {
            orderRepository.Delete(id);
        }

        public async Task<OrderModel> GetOrderAsync(int id)
        {
            return mapper.Map<OrderModel>(await orderRepository.GetAsync(id));
        }

        public async Task<IEnumerable<OrderModel>> GetOrdersAsync()
        {
            return mapper.Map<IEnumerable<OrderModel>>(await orderRepository.GetOrders());
        }

        public async Task<IEnumerable<OrderModel>> GetOrdersAsync(DateTime dateFrom, DateTime dateTo)
        {
            return mapper.Map<IEnumerable<OrderModel>>(await orderRepository.GetOrders(dateFrom, dateTo));
        }

        public async Task<IEnumerable<OrderModel>> GetOrdersAsync(DateTime dateFrom, DateTime dateTo, int place)
        {
            return mapper.Map<IEnumerable<OrderModel>>(await orderRepository.GetOrders(dateFrom, dateTo, place));
        }

        public async Task<IEnumerable<OrderModel>> GetOrdersAsync(DateTime dateFrom, DateTime dateTo, string rep)
        {
            return mapper.Map<IEnumerable<OrderModel>>(await orderRepository.GetOrders(dateFrom, dateTo, rep));
        }

        public async Task<IEnumerable<OrderModel>> GetOrdersAsync(DateTime dateFrom, DateTime dateTo, string rep, int place)
        {
            return mapper.Map<IEnumerable<OrderModel>>(await orderRepository.GetOrders(dateFrom, dateTo, rep, place));
        }

        public async Task<OrderModel> InsertOrderAsync(OrderModel order)
        {
            var user = await userRepository.GetUser();

            order.AddedDate = DateTime.Now;
            order.TenantId = user.TenantId;
            order.CreatorUserId = requestIdentityProvider.UserId;
            order.LastModifierUserId = requestIdentityProvider.UserId;

            var newOrder = await orderRepository.InsertAsync(mapper.Map<Order>(order));
            await orderRepository.SaveChangesAsync();
            return mapper.Map<OrderModel>(newOrder);
        }

        public async Task<IEnumerable<OrderModel>> InsertOrderListAsync(IEnumerable<OrderModel> orders)
        {
            var user = await userRepository.GetUser();

            List<OrderModel> orderList = new List<OrderModel>();

            foreach (var order in orders)
            {
                var orderVar = new OrderModel
                {
                    SyncId = order.SyncId,
                    PlaceId = order.PlaceId,
                    ScheduleId = order.ScheduleId,
                    Amount = order.Amount,
                    DiscountAmount = order.DiscountAmount,
                    DiscountRate = order.DiscountRate,
                    DueDate = order.DueDate,
                    DueDays = order.DueDays,
                    Note = order.Note,
                    OrderDate = order.OrderDate,                   
                    Quantity = order.Quantity,
                    signature = order.signature,
                    TaxAmount = order.TaxAmount,
                    TaxRate = order.TaxRate,
                    TotalAmount = order.TotalAmount,
                    AddedDate = DateTime.Now,
                    TenantId = user.TenantId,
                    CreatorUserId = requestIdentityProvider.UserId,
                    LastModifierUserId = requestIdentityProvider.UserId
                };
                orderList.Add(orderVar);
            }
            var newOrderList = orderRepository.InsertOrderList(mapper.Map<IEnumerable<Order>>(orderList));
            await orderRepository.SaveChangesAsync();
            return orderList;
        }

        public Task<OrderModel> UpdateOrderAsync(OrderModel order)
        {
            throw new NotImplementedException();
        }
    }
}
