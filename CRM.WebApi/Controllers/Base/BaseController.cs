using CRM.Domain.RequestIdentity;
using System;
using System.Net;
using System.Web.Http;

namespace CRM.WebApi.Controllers.Base
{
    public class BaseController : ApiController
    {
        public IRequestIdentityProvider requestIdentityProvider;

        public BaseController(IRequestIdentityProvider requestIdentityProvider)
        {
            this.requestIdentityProvider = requestIdentityProvider;

            var requestId = Guid.NewGuid().ToString();

            //if (requestIdentityProvider.UserId != null)
            //{
            //    if (requestInfoProvider.Current.RequestId == null)
            //        requestInfoProvider.Current.RequestId = requestId;
            //}
        }

        protected HttpStatusCode NoContent()
        {
            return HttpStatusCode.NoContent;
        }
    }
}