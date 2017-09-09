

using AutoMapper;
using CRM.Domain.Model;
using CRM.Domain.RequestIdentity;
using CRM.Service.Services.Photos;
using CRM.WebApi.Controllers.Base;
using CRM.WebApi.Dto.Photos.In;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CRM.WebApi.Controllers
{
    [RoutePrefix("api/Photo")]
    public class PhotoController : BaseController
    {
        IPhotoService photoService;
        IMapper mapper;

        public PhotoController(IMapper mapper, IPhotoService photoService, IRequestIdentityProvider requestIdentityProvider) : base(requestIdentityProvider)
        {
            this.photoService = photoService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody]PhotoDtoIn photo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await photoService.InsertPhotoAsync(mapper.Map<PhotoModel>(photo));
            return Ok(created);
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Update([FromBody]PhotoDtoIn photo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await photoService.UpdatePhotoAsync(mapper.Map<PhotoModel>(photo));
            return Ok(created);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Read(int id)
        {
            var created = await photoService.GetPhotoAsync(id);
            return Ok(created);
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> ReadAll()
        {
            var created = await photoService.GetPhotosAsync();
            return Ok(created);
        }

        [HttpGet]
        [Route("DateRange")]
        public async Task<IHttpActionResult> ReadAllByDateRange(DateTime dateFrom, DateTime dateTo)
        {
            var created = await photoService.GetPhotosAsync();
            return Ok(created);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            photoService.DeletePhoto(id);
            return Ok("");
        }



    }
}