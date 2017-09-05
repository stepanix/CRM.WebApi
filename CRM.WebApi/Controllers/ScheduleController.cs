using AutoMapper;
using CRM.Domain.Model;
using CRM.Domain.RequestIdentity;
using CRM.Service.Services.Schedules;
using CRM.WebApi.Controllers.Base;
using CRM.WebApi.Dto.Schedules.In;
using System.Threading.Tasks;
using System.Web.Http;

namespace CRM.WebApi.Controllers
{
    [RoutePrefix("api/Schedule")]
    public class ScheduleController : BaseController
    {
        IScheduleService scheduleService;
        IMapper mapper;

        public ScheduleController(IMapper mapper, IScheduleService scheduleService, IRequestIdentityProvider requestIdentityProvider) : base(requestIdentityProvider)
        {
            this.scheduleService = scheduleService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody]ScheduleDtoIn schedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await scheduleService.InsertScheduleAsync(mapper.Map<ScheduleModel>(schedule));
            return Ok(created);
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Update([FromBody]ScheduleDtoIn schedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await scheduleService.UpdateScheduleAsync(mapper.Map<ScheduleModel>(schedule));
            return Ok(created);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Read(int id)
        {
            var created = await scheduleService.GetScheduleAsync(id);
            return Ok(created);
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> ReadAll()
        {
            var created = await scheduleService.GetSchedulesAsync();
            return Ok(created);
        }

        [HttpGet]
        [Route("MySchedules")]
        public async Task<IHttpActionResult> ReadMyAll()
        {
            var created = await scheduleService.GetMySchedulesAsync();
            return Ok(created);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            scheduleService.DeleteSchedule(id);
            return Ok("");
        }

    }
}