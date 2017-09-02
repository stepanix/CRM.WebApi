using CRM.WebApi.Controllers.Base;
using System.Web.Http;
using CRM.Domain.RequestIdentity;
using CRM.Service.Services.Users;
using AutoMapper;
using System.Threading.Tasks;

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
    }
}