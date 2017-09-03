using AutoMapper;
using CRM.Domain.Model;
using CRM.Domain.RequestIdentity;
using CRM.Service.Services.Tenants;
using CRM.WebApi.Controllers.Base;
using System.Threading.Tasks;
using System.Web.Http;

namespace CRM.WebApi.Controllers
{
    [RoutePrefix("api/Tenant")]
    public class TenantController : BaseController
    {

        ITenantService tenantService;
        IMapper mapper;

        public TenantController(IMapper mapper,ITenantService tenantService,IRequestIdentityProvider requestIdentityProvider) : base(requestIdentityProvider)
        {
            this.tenantService = tenantService;
            this.mapper = mapper;
        }


        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody]TenantModel tenant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await tenantService.InsertTenantAsync(tenant);
            return Ok(created);
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Update([FromBody]TenantModel tenant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await tenantService.UpdateTenantAsync(tenant);
            return Ok(created);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Read(int id)
        {
            var created = await tenantService.GetTenantAsync(id);
            return Ok(created);
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> ReadAll()
        {
            var created = await tenantService.GetTenantsAsync();
            return Ok(created);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            tenantService.DeleteTenant(id);
            return Ok("");
        }


    }
}