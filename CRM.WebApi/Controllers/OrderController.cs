using AutoMapper;
using CRM.WebApi.Controllers.Base;
using System.Web.Http;
using CRM.Domain.RequestIdentity;
using CRM.Service.Services.Orders;
using CRM.WebApi.Dto.Orders.In;
using System.Threading.Tasks;
using CRM.Domain.Model;
using System.Collections.Generic;
using System;

namespace CRM.WebApi.Controllers
{
    [RoutePrefix("api/Order")]
    public class OrderController : BaseController
    {
        IOrderService orderService;
        IMapper mapper;

        public OrderController(IOrderService orderService, IMapper mapper, IRequestIdentityProvider requestIdentityProvider) : base(requestIdentityProvider)
        {
            this.orderService = orderService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody]OrderDtoIn order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await orderService.InsertOrderAsync(mapper.Map<OrderModel>(order));
            return Ok(created);
        }

        [HttpPost]
        [Route("List")]
        public async Task<IHttpActionResult> CreateList([FromBody]IEnumerable<OrderDtoIn> orders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await orderService.InsertOrderListAsync(mapper.Map<IEnumerable<OrderModel>>(orders));
            return Ok(created);
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Update([FromBody]OrderDtoIn order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await orderService.UpdateOrderAsync(mapper.Map<OrderModel>(order));
            return Ok(created);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Read(int id)
        {
            var created = await orderService.GetOrderAsync(id);
            return Ok(created);
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> ReadAll()
        {
            var created = await orderService.GetOrdersAsync();
            return Ok(created);
        }

        [HttpGet]
        [Route("DateRange")]
        public async Task<IHttpActionResult> ReadAllByDateRange(DateTime dateFrom, DateTime dateTo)
        {
            var created = await orderService.GetOrdersAsync(dateFrom, dateTo);
            return Ok(created);
        }

        [HttpGet]
        [Route("Rep")]
        public async Task<IHttpActionResult> ReadAllByRep(DateTime dateFrom, DateTime dateTo, string rep)
        {
            var created = await orderService.GetOrdersAsync(dateFrom, dateTo, rep);
            return Ok(created);
        }

        [HttpGet]
        [Route("Place")]
        public async Task<IHttpActionResult> ReadAllByPlace(DateTime dateFrom, DateTime dateTo, int place)
        {
            var created = await orderService.GetOrdersAsync(dateFrom, dateTo, place);
            return Ok(created);
        }

        [HttpGet]
        [Route("RepAndPlace")]
        public async Task<IHttpActionResult> ReadAllByRepAndPlace(DateTime dateFrom, DateTime dateTo, string rep, int place)
        {
            var created = await orderService.GetOrdersAsync(dateFrom, dateTo, rep, place);
            return Ok(created);
        }


        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            orderService.DeleteOrder(id);
            return Ok("");
        }


    }
}