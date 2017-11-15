using AutoMapper;
using CRM.Domain.Model;
using CRM.Domain.RequestIdentity;
using CRM.Service.Services.Activities;
using CRM.WebApi.Controllers.Base;
using CRM.WebApi.Dto.Activities.In;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace CRM.WebApi.Controllers
{
    [RoutePrefix("api/Activity")]
    public class ActivityController : BaseController
    {
        IActivityService activityService;
        IMapper mapper;
        public ActivityController(IMapper mapper, IActivityService activityService, IRequestIdentityProvider requestIdentityProvider) : base(requestIdentityProvider)
        {
            this.activityService = activityService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("List")]
        public async Task<IHttpActionResult> CreateList([FromBody]IEnumerable<ActivityDtoIn> activities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await activityService.InsertActivityListAsync(mapper.Map<IEnumerable<ActivityModel>>(activities));
            return Ok(created);
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> ReadAll()
        {
            var created = await activityService.GetActivitiesAsync();
            return Ok(created);
        }

        [HttpGet]
        [Route("Summary")]
        public async Task<IHttpActionResult> ReadSummary(string userId, DateTime dateFrom,DateTime dateTo, int placeId)
        {
            var created = await activityService.GetActivitiesAsync(userId, dateFrom, dateTo, placeId);
            return Ok(created);
        }

        [HttpGet]
        [Route("RepSummary")]
        public async Task<IHttpActionResult> ReadRepSummary(string userId)
        {
            var created = await activityService.GetActivitiesAsync(userId);
            return Ok(created);
        }

        [HttpGet]
        [Route("AllSummary")]
        public async Task<IHttpActionResult> ReadAllSummary(DateTime dateFrom, DateTime dateTo)
        {
            var created = await activityService.GetActivitiesAsync(dateFrom, dateTo);
            return Ok(created);
        }



    }
}