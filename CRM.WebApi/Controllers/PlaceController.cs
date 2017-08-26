﻿

using CRM.WebApi.Controllers.Base;
using System.Web.Http;
using CRM.Domain.RequestIdentity;
using CRM.Service.Services.Places;
using AutoMapper;
using CRM.Domain.Model;
using System.Threading.Tasks;

namespace CRM.WebApi.Controllers
{
    [RoutePrefix("api/Place")]
    public class PlaceController : BaseController
    {
        IPlaceService placeService;
        IMapper mapper;

        public PlaceController(IMapper mapper, IPlaceService placeService, IRequestIdentityProvider requestIdentityProvider) : base(requestIdentityProvider)
        {
            this.placeService = placeService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody]PlaceModel place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await placeService.InsertPlaceAsync(place);
            return Ok(created);
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Update([FromBody]PlaceModel place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await placeService.UpdatePlaceAsync(place);
            return Ok(created);
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Read(int id)
        {
            var created = await placeService.GetPlaceAsync(id);
            return Ok(created);
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> ReadAll()
        {
            var created = await placeService.GetPlacesAsync();
            return Ok(created);
        }

    }

}