﻿

using CRM.WebApi.Controllers.Base;
using System.Web.Http;
using CRM.Domain.RequestIdentity;
using CRM.Service.Services.Places;
using AutoMapper;
using CRM.Domain.Model;
using System.Threading.Tasks;
using CRM.WebApi.Dto.Places.In;
using System;
using System.Collections.Generic;

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
        public async Task<IHttpActionResult> Create([FromBody]PlaceDtoIn place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await placeService.InsertPlaceAsync(mapper.Map<PlaceModel>(place));
            return Ok(created);
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Update([FromBody]PlaceDtoIn place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await placeService.UpdatePlaceAsync(mapper.Map<PlaceModel>(place));
            return Ok(created);
        }

        [HttpPost]
        [Route("List")]
        public async Task<IHttpActionResult> CreateList([FromBody]IEnumerable<PlaceDtoIn> places)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await placeService.InsertPlaceListAsync(mapper.Map<IEnumerable<PlaceModel>>(places));
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

        [HttpGet]
        [Route("DateRange")]
        public async Task<IHttpActionResult> ReadAllByDateRange(DateTime dateFrom, DateTime dateTo)
        {
            var created = await placeService.GetPlacesAsync(dateFrom,dateTo);
            return Ok(created);
        }

        [HttpGet]
        [Route("Rep")]
        public async Task<IHttpActionResult> ReadAllByDateRange(DateTime dateFrom, DateTime dateTo,string rep)
        {
            var created = await placeService.GetPlacesAsync(dateFrom, dateTo,rep);
            return Ok(created);
        }


        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            placeService.DeletePlace(id);
            return Ok("");
        }

    }

}