using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using CRM.WebApi.Identity;
using CRM.Domain.Identity;

namespace CRM.WebApi.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager, User user, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(user, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //Add Access-Control-Allow-Origin header as Enabling the Web Api CORS will not enable it for this provider request.
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            User user = await userManager.FindAsync(context.UserName, context.Password);
            string rolesString = string.Empty;
           

            if (user != null)
            {
                var roles = await userManager.GetRolesAsync(user.Id);
                rolesString = string.Join(",", roles);                
            }

            if (!user.IsActive)
            {
                context.SetError("in_active user", "user is currently inactive , please contact administrator");
                return;
            }

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            ClaimsIdentity oAuthIdentity = await GenerateUserIdentityAsync(userManager, user,
               OAuthDefaults.AuthenticationType);
            ClaimsIdentity cookiesIdentity = await GenerateUserIdentityAsync(userManager, user,
                CookieAuthenticationDefaults.AuthenticationType);

            string fullName = user.FirstName + " " + user.Surname;

            AuthenticationProperties properties = CreateProperties(user.UserName, rolesString,user.TenantId.ToString(), fullName,user.Id);
            AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(cookiesIdentity);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string username, string roles,string tenantid,string fullname,string userid)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userid", userid },
                { "fullname", fullname },
                { "username", username },
                { "roles", roles },
                { "tenantid", tenantid }
            };
            return new AuthenticationProperties(data);
        }
    }
}