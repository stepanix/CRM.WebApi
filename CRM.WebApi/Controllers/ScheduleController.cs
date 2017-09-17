using AutoMapper;
using CRM.Domain.Model;
using CRM.Domain.RequestIdentity;
using CRM.Service.Services.Schedules;
using CRM.WebApi.Controllers.Base;
using CRM.WebApi.Dto.Schedules.In;
using System;
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
        [Route("ByStatus")]
        public async Task<IHttpActionResult> ReadByStatus(bool isVisited, bool isScheduled, bool isUnScheduled, bool isMissed)
        {
            var created = await scheduleService.GetSchedulesAsync(isVisited, isScheduled, isUnScheduled, isMissed);
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
        [Route("DateRange")]
        public async Task<IHttpActionResult> ReadAllByDateRange(DateTime dateFrom,DateTime dateTo)
        {
            var created = await scheduleService.GetSchedulesAsync(dateFrom,dateTo);
            return Ok(created);
        }

        [HttpGet]
        [Route("Rep")]
        public async Task<IHttpActionResult> ReadAllByRep(DateTime dateFrom, DateTime dateTo, string rep)
        {
            var created = await scheduleService.GetSchedulesAsync(dateFrom, dateTo, rep);
            return Ok(created);
        }

        [HttpGet]
        [Route("Place")]
        public async Task<IHttpActionResult> ReadAllByPlace(DateTime dateFrom, DateTime dateTo, int place)
        {
            var created = await scheduleService.GetSchedulesAsync(dateFrom, dateTo, place);
            return Ok(created);
        }

        [HttpGet]
        [Route("RepAndPlace")]
        public async Task<IHttpActionResult> ReadAllByRepAndPlace(DateTime dateFrom, DateTime dateTo, string rep, int place)
        {
            var created = await scheduleService.GetSchedulesAsync(dateFrom, dateTo, rep, place);
            return Ok(created);
        }

        [HttpGet]
        [Route("MySchedules")]
        public async Task<IHttpActionResult> ReadMyAll(DateTime scheduleDate)
        {
            var created = await scheduleService.GetMySchedulesAsync(scheduleDate);
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