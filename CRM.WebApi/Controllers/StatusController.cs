using CRM.WebApi.Controllers.Base;

using CRM.Domain.RequestIdentity;
using System.Web.Http;
using CRM.Service.Services.Statuses;
using AutoMapper;
using CRM.Domain.Model;
using System.Threading.Tasks;
using CRM.WebApi.Dto.Statuses.In;

namespace CRM.WebApi.Controllers
{
    [RoutePrefix("api/Status")]
    public class StatusController : BaseController
    {
        IStatusService statusService;
        IMapper mapper;


        public StatusController(IMapper mapper,IStatusService statusService,IRequestIdentityProvider requestIdentityProvider) : base(requestIdentityProvider)
        {
            this.statusService = statusService;
            this.mapper = mapper;
        }


        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody]StatusDtoIn status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await statusService.InsertStatusAsync(mapper.Map<StatusModel>(status));
            return Ok(created);
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Update([FromBody]StatusDtoIn status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await statusService.UpdateStatusAsync(mapper.Map<StatusModel>(status));
            return Ok(created);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Read(int id)
        {
            var created = await statusService.GetStatusAsync(id);
            return Ok(created);
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> ReadAll()
        {
            var created = await statusService.GetStatusesAsync();
            return Ok(created);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            statusService.DeleteStatus(id);
            return Ok("");
        }


    }
}