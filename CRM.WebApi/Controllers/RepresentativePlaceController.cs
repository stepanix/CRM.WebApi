

using AutoMapper;
using CRM.Domain.Model;
using CRM.Domain.RequestIdentity;
using CRM.Service.Services.RepresentativePlaces;
using CRM.WebApi.Controllers.Base;
using CRM.WebApi.Dto.RepresentativePlaces.In;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace CRM.WebApi.Controllers
{
    [RoutePrefix("api/RepresentativePlace")]
    public class RepresentativePlaceController : BaseController
    {
        IRepresentativePlaceService representativePlaceService;
        IMapper mapper;

        public RepresentativePlaceController(IMapper mapper, IRepresentativePlaceService representativePlaceService, IRequestIdentityProvider requestIdentityProvider) : base(requestIdentityProvider)
        {
            this.representativePlaceService = representativePlaceService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody]RepresentativePlaceDtoIn repPlace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await representativePlaceService.InsertRepresentativePlaceAsync(mapper.Map<RepresentativePlaceModel>(repPlace));
            return Ok(created);
        }


        [HttpPost]
        [Route("List")]
        public async Task<IHttpActionResult> CreateList([FromBody]IEnumerable<RepresentativePlaceDtoIn> repPlace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await representativePlaceService.InsertRepresentativePlaceListAsync(mapper.Map<IEnumerable<RepresentativePlaceModel>>(repPlace));
            return Ok(created);
        }


        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Update([FromBody]RepresentativePlaceDtoIn repPlace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await representativePlaceService.UpdateRepresentativePlaceAsync(mapper.Map<RepresentativePlaceModel>(repPlace));
            return Ok(created);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Read(int id)
        {
            var created = await representativePlaceService.GetRepresentativePlaceAsync(id);
            return Ok(created);
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> ReadAll()
        {
            var created = await representativePlaceService.GetRepresentativePlaceAsync();
            return Ok(created);
        }

        [HttpGet]
        [Route("ByPlaceId")]
        public async Task<IHttpActionResult> ReadAllByPlaceId(int id)
        {
            var created = await representativePlaceService.GetRepresentativeByPlaceIdAsync(id);
            return Ok(created);
        }


    }
}