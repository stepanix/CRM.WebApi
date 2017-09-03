
using CRM.WebApi.Controllers.Base;
using System.Web.Http;
using CRM.Domain.RequestIdentity;
using CRM.Service.Services.ProductRetailAudits;
using AutoMapper;
using CRM.WebApi.Dto.ProductretailAudits.In;
using System.Threading.Tasks;
using CRM.Domain.Model;

namespace CRM.WebApi.Controllers
{
    [RoutePrefix("api/ProductRetailAudit")]
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

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            productRetailAuditService.DeleteProductRetailAudit(id);
            return Ok("");
        }

    }
}