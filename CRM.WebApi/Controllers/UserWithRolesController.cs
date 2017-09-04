using CRM.WebApi.Controllers.Base;
using System.Web.Http;
using CRM.Domain.RequestIdentity;
using CRM.Domain.Repositories;
using System.Threading.Tasks;

namespace CRM.WebApi.Controllers
{
    [RoutePrefix("api/UserWithRoles")]
    public class UserWithRolesController : BaseController
    {
        IUserRepository userRepository;
        public UserWithRolesController(IUserRepository userRepository,IRequestIdentityProvider requestIdentityProvider) : base(requestIdentityProvider)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> Read(string id)
        {
            var created = await userRepository.GetUser(id);
            return Ok(created);
        }
    }
}