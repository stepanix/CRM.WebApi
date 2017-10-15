
using CRM.WebApi.Controllers.Base;
using System.Web.Http;
using CRM.Domain.RequestIdentity;
using CRM.Service.Services.ProductRetailAudits;
using AutoMapper;
using CRM.WebApi.Dto.ProductretailAudits.In;
using System.Threading.Tasks;
using CRM.Domain.Model;
using System;
using System.Collections.Generic;

namespace CRM.WebApi.Controllers
{
    [RoutePrefix("api/ProductAuditRetail")]
    public class ProductRetailAuditController : BaseController
    {
        IProductRetailAuditService productRetailAuditService;
        IMapper mapper;

        public ProductRetailAuditController(IMapper mapper, IProductRetailAuditService productRetailAuditService, IRequestIdentityProvider requestIdentityProvider) : base(requestIdentityProvider)
        {
            this.productRetailAuditService = productRetailAuditService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody]ProductRetailAuditDtoIn productRetailAudit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await productRetailAuditService.InsertProductRetailAuditAsync(mapper.Map<ProductRetailAuditModel>(productRetailAudit));
            return Ok(created);
        }

        [HttpPost]
        [Route("List")]
        public async Task<IHttpActionResult> CreateList([FromBody]IEnumerable<ProductRetailAuditDtoIn> productRetailAudit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await productRetailAuditService.InsertProductRetailAuditListAsync(mapper.Map<IEnumerable<ProductRetailAuditModel>>(productRetailAudit));
            return Ok(created);
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Update([FromBody]ProductRetailAuditDtoIn productRetailAudit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await productRetailAuditService.UpdateProductRetailAuditAsync(mapper.Map<ProductRetailAuditModel>(productRetailAudit));
            return Ok(created);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Read(int id)
        {
            var created = await productRetailAuditService.GetProductRetailAuditAsync(id);
            return Ok(created);
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> ReadAll()
        {
            var created = await productRetailAuditService.GetProductRetailAuditsAsync();
            return Ok(created);
        }

        [HttpGet]
        [Route("DateRange")]
        public async Task<IHttpActionResult> ReadAllByDateRange(DateTime dateFrom,DateTime dateTo)
        {
            var created = await productRetailAuditService.GetProductRetailAuditsAsync(dateFrom,dateTo);
            return Ok(created);
        }

        [HttpGet]
        [Route("Rep")]
        public async Task<IHttpActionResult> ReadAllByRep(DateTime dateFrom, DateTime dateTo,string rep)
        {
            var created = await productRetailAuditService.GetProductRetailAuditsAsync(dateFrom, dateTo,rep);
            return Ok(created);
        }

        [HttpGet]
        [Route("Place")]
        public async Task<IHttpActionResult> ReadAllByPlace(DateTime dateFrom, DateTime dateTo, int place)
        {
            var created = await productRetailAuditService.GetProductRetailAuditsAsync(dateFrom, dateTo, place);
            return Ok(created);
        }


        [HttpGet]
        [Route("RepAndPlace")]
        public async Task<IHttpActionResult> ReadAllByRepAndPlace(DateTime dateFrom, DateTime dateTo, string rep, int place)
        {
            var created = await productRetailAuditService.GetProductRetailAuditsAsync(dateFrom, dateTo, rep, place);
            return Ok(created);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            productRetailAuditService.DeleteProductRetailAudit(id);
            return Ok("");
        }

    }
}