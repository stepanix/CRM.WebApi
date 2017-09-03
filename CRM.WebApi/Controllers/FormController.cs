using CRM.WebApi.Controllers.Base;
using System.Web.Http;
using CRM.Domain.RequestIdentity;
using CRM.Service.Services.Forms;
using AutoMapper;
using CRM.Domain.Model;
using System.Threading.Tasks;
using CRM.WebApi.Dto.Form.In;

namespace CRM.WebApi.Controllers
{
    [RoutePrefix("api/Form")]
    public class FormController : BaseController
    {
        IFormService formService;
        IMapper mapper;

        public FormController(IMapper mapper,IFormService formService,IRequestIdentityProvider requestIdentityProvider) : base(requestIdentityProvider)
        {
            this.formService = formService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody]FormDtoIn form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await formService.InsertFormAsync(mapper.Map<FormModel>(form));
            return Ok(created);
        }


        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Update([FromBody]FormDtoIn form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await formService.UpdateFormAsync(mapper.Map<FormModel>(form));
            return Ok(created);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Read(int id)
        {
            var created = await formService.GetFormAsync(id);
            return Ok(created);
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> ReadAll()
        {
            var created = await formService.GetFormsAsync();
            return Ok(created);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            formService.DeleteForm(id);
            return Ok("");
        }

    }
}