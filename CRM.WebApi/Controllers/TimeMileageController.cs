using CRM.WebApi.Controllers.Base;
using CRM.Domain.RequestIdentity;
using System.Web.Http;
using CRM.Service.Services.TimeMileages;
using AutoMapper;
using CRM.WebApi.Dto.TimeMileages.In;
using System.Threading.Tasks;
using CRM.Domain.Model;
using System;

namespace CRM.WebApi.Controllers
{
    [RoutePrefix("api/TimeMileage")]
    public class TimeMileageController : BaseController
    {
        ITimeMileageService timeMileageService;
        IMapper mapper;

        public TimeMileageController(IMapper mapper, ITimeMileageService timeMileageService, IRequestIdentityProvider requestIdentityProvider) : base(requestIdentityProvider)
        {
            this.timeMileageService = timeMileageService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody]TimeMileageDtoIn timeMileage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await timeMileageService.InsertTimeMileageAsync(mapper.Map<TimeMileageModel>(timeMileage));
            return Ok(created);
        }


        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Update([FromBody]TimeMileageDtoIn timeMileage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await timeMileageService.UpdateTimeMileageAsync(mapper.Map<TimeMileageModel>(timeMileage));
            return Ok(created);
        }

        [HttpGet]
        [Route("DateRange")]
        public async Task<IHttpActionResult> Read(DateTime dateFrom, DateTime dateTo)
        {
            var created = await timeMileageService.GetTimeMileageAsync(dateFrom, dateTo);
            return Ok(created);
        }

        [HttpGet]
        [Route("Rep")]
        public async Task<IHttpActionResult> ReadByRep(DateTime dateFrom, DateTime dateTo,string rep)
        {
            var created = await timeMileageService.GetTimeMileageAsync(dateFrom, dateTo,rep);
            return Ok(created);
        }


    }
}