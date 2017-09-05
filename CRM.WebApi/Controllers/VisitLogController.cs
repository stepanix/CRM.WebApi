

using AutoMapper;
using CRM.Domain.Model;
using CRM.Domain.RequestIdentity;
using CRM.Service.Services.VisitLogs;
using CRM.WebApi.Controllers.Base;
using CRM.WebApi.Dto.VisitLogs.In;
using System.Threading.Tasks;
using System.Web.Http;

namespace CRM.WebApi.Controllers
{
    [RoutePrefix("api/VisitLog")]
    public class VisitLogController : BaseController
    {
        IVisitLogService visitLogService;
        IMapper mapper;

        public VisitLogController(IMapper mapper,IVisitLogService visitLogService,IRequestIdentityProvider requestIdentityProvider) : base(requestIdentityProvider)
        {
            this.visitLogService = visitLogService;
            this.mapper = mapper;
        }


        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody]VisitLogDtoIn vistlog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await visitLogService.InsertVisitLogAsync(mapper.Map<VisitLogModel>(vistlog));
            return Ok(created);
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Update([FromBody]VisitLogDtoIn vistlog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await visitLogService.UpdateVisitLogAsync(mapper.Map<VisitLogModel>(vistlog));
            return Ok(created);
        }


        [HttpGet]
        [Route("{scheduleid:int}")]
        public async Task<IHttpActionResult> Read(int scheduleid)
        {
            var created = await visitLogService.GetVisitLogAsync(scheduleid);
            return Ok(created);
        }


    }
}