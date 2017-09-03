using CRM.WebApi.Controllers.Base;
using System.Web.Http;
using CRM.Domain.RequestIdentity;
using CRM.Service.Services.Users;
using AutoMapper;
using System.Threading.Tasks;
using CRM.Domain.Model;

namespace CRM.WebApi.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : BaseController
    {
        IUserService userService;
        IMapper mapper;

        public UserController(IMapper mapper, IUserService userService, IRequestIdentityProvider requestIdentityProvider) : base(requestIdentityProvider)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("UnAssignedReps")]
        public async Task<IHttpActionResult> ReadUnAssignedReps(int placeId)
        {
            var created = await userService.GetUnAssignedRepsByPlaceIdAsync(placeId);
            return Ok(created);
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Update([FromBody]UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await userService.UpdateUserAsync(user);
            return Ok(created);
        }


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> Read(string id)
        {
            var created = await userService.GetUserAsync(id);
            return Ok(created);
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> ReadAll()
        {
            var created = await userService.GetUsersAsync();
            return Ok(created);
        }



    }
}