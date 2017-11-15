

using System;
using System.Collections.Generic;
using CRM.Domain.Model;
using CRM.Domain.Repositories;
using AutoMapper;
using System.Threading.Tasks;
using CRM.Domain.RequestIdentity;
using CRM.Domain.Entities;

namespace CRM.Service.Services.OrderItems
{
    public class OrderItemService : IOrderItemService
    {
        IOrderItemRepository orderItemRepository;
        IMapper mapper;
        IUserRepository userRepository;
        IRequestIdentityProvider requestIdentityProvider;

        public OrderItemService(IMapper mapper, IOrderItemRepository orderItemRepository, IUserRepository userRepository, IRequestIdentityProvider requestIdentityProvider)
        {
            this.mapper = mapper;
            this.orderItemRepository = orderItemRepository;
            this.userRepository = userRepository;
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public async Task<IEnumerable<OrderItemModel>> InsertOrderListAsync(IEnumerable<OrderItemModel> orderItems)
        {
            var user = await userRepository.GetUser();

            List<OrderItemModel> orderItemList = new List<OrderItemModel>();

            foreach (var orderItem in orderItems)
            {
                var orderItemVar = new OrderItemModel
                {
                    SyncId = orderItem.SyncId,
                    RepoId = orderItem.RepoId,
                    Amount = orderItem.Amount,
                    OrderId = orderItem.OrderId,
                    ProductId = orderItem.ProductId,
                    Quantity = orderItem.Quantity,
                    AddedDate = DateTime.Now,
                    TenantId = user.TenantId,
                    CreatorUserId = requestIdentityProvider.UserId,
                    LastModifierUserId = requestIdentityProvider.UserId
                };
                orderItemList.Add(orderItemVar);
            }
            var newOrderItemList = orderItemRepository.InsertOrderList(mapper.Map<IEnumerable<OrderItem>>(orderItemList));
            await orderItemRepository.SaveChangesAsync();
            return orderItemList;
        }
    }
}
