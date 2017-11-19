

using AutoMapper;
using CRM.Service.Services.OrderItems;
using CRM.WebApi.Controllers.Base;
using System.Web.Http;
using CRM.Domain.RequestIdentity;
using CRM.WebApi.Dto.OrderItems.In;
using System.Threading.Tasks;
using CRM.Domain.Model;
using System.Collections.Generic;
using System;

namespace CRM.WebApi.Controllers
{
    [RoutePrefix("api/OrderItem")]
    public class OrderItemController : BaseController
    {
        IOrderItemService orderItemService;
        IMapper mapper;

        public OrderItemController(IOrderItemService orderItemService, IMapper mapper, IRequestIdentityProvider requestIdentityProvider) : base(requestIdentityProvider)
        {
            this.orderItemService = orderItemService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("List")]
        public async Task<IHttpActionResult> CreateList([FromBody]IEnumerable<OrderItemDtoIn> orderItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await orderItemService.InsertOrderListAsync(mapper.Map<IEnumerable<OrderItemModel>>(orderItems));
            return Ok(created);
        }

        [HttpGet]
        [Route("DateRange")]
        public async Task<IHttpActionResult> ReadAllByDateRange(DateTime dateFrom, DateTime dateTo)
        {
            var created = await orderItemService.GetOrderItemsAsync(dateFrom, dateTo);
            return Ok(created);
        }
    }
}