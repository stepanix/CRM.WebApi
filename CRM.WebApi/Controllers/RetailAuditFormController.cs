
using CRM.WebApi.Controllers.Base;
using System.Web.Http;
using CRM.Domain.RequestIdentity;
using CRM.Service.Services.RetailAuditForms;
using AutoMapper;
using CRM.Domain.Model;
using System.Threading.Tasks;

namespace CRM.WebApi.Controllers
{
    [RoutePrefix("api/RetailAuditForm")]
    public class RetailAuditFormController : BaseController
    {
        IRetailAuditFormService retailAuditFormService;
        IMapper mapper;

        public RetailAuditFormController(IMapper mapper, IRetailAuditFormService retailAuditFormService, IRequestIdentityProvider requestIdentityProvider) : base(requestIdentityProvider)
        {
            this.retailAuditFormService = retailAuditFormService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody]RetailAuditFormModel retailAuditForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await retailAuditFormService.InsertRetailAuditFormAsync(retailAuditForm);
            return Ok(created);
        }


        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Update([FromBody]RetailAuditFormModel retailAuditForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await retailAuditFormService.UpdateRetailAuditFormAsync(retailAuditForm);
            return Ok(created);
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Read(int id)
        {
            var created = await retailAuditFormService.GetRetailAuditFormAsync(id);
            return Ok(created);
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> ReadAll()
        {
            var created = await retailAuditFormService.GetRetailAuditFormsAsync();
            return Ok(created);
        }


    }
}