using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.RequestIdentity
{
    public interface IRequestIdentityProvider
    {
        string UserId { get; set; }
        string UserName { get; }
    }
}
