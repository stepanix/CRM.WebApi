

using AutoMapper;
using CRM.Domain.Model;
using CRM.Domain.RequestIdentity;
using CRM.Service.Services.FormValues;
using CRM.WebApi.Controllers.Base;
using CRM.WebApi.Dto.FormValues.In;
using System.Threading.Tasks;
using System.Web.Http;

namespace CRM.WebApi.Controllers
{
    [RoutePrefix("api/FormValue")]
    public class FormValueController : BaseController
    {
        IFormValueService formValueService;
        IMapper mapper;

        public FormValueController(IMapper mapper,IFormValueService formValueService,IRequestIdentityProvider requestIdentityProvider) : base(requestIdentityProvider)
        {
            this.formValueService = formValueService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody]FormValueDtoIn formValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await formValueService.InsertFormValueAsync(mapper.Map<FormValueModel>(formValue));
            return Ok(created);
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Update([FromBody]FormValueDtoIn formValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await formValueService.UpdateFormValueAsync(mapper.Map<FormValueModel>(formValue));
            return Ok(created);
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Read(int id)
        {
            var created = await formValueService.GetFormValueAsync(id);
            return Ok(created);
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> ReadAll()
        {
            var created = await formValueService.GetFormValuesAsync();
            return Ok(created);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            formValueService.DeleteFormValue(id);
            return Ok("");
        }


    }
}