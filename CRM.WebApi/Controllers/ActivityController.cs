using AutoMapper;
using CRM.Domain.Model;
using CRM.Domain.RequestIdentity;
using CRM.Service.Services.Activities;
using CRM.WebApi.Controllers.Base;
using CRM.WebApi.Dto.Activities.In;
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



    }
}