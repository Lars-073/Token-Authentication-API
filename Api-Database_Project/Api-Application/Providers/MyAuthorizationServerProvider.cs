using Api_Application.Repositories;
using Api_Domain;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Api_Application.Providers
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using (UserRepository _repo = new UserRepository())
            {
                var user = _repo.ValidateUser(context.UserName, context.Password);
                if (user == null)
                {
                    context.SetError("invalid_grant", "Provided username and password is incorrect");
                    return;
                }
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Role, user.UserRole));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
                identity.AddClaim(new Claim("Email", user.UserEmail));

                context.Validated(identity);
            }     
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId = string.Empty;
            string clientSecret = string.Empty;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.SetError("invalid_client", "Client credentials could not be retrieved through the Authorization header.");
                context.Rejected();
                return;
            }
            Client client = (new ClientRepository()).ValidateClient(clientId, clientSecret);
            if (client != null)
            {
                context.OwinContext.Set<Client>("oauth:client", client);
                context.Validated(clientId);
            }
            else
            {
                context.SetError("invalid_client", "Client credentials are invalid.");
                context.Rejected();
            }
            context.Validated();
        }
    }
}