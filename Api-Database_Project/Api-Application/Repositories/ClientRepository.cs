using Api_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Application.Repositories
{
    public class ClientRepository : IDisposable
    {
        API_Entities context = new API_Entities();

        public Client ValidateClient(string ClientID, string ClientSecret)
        {
            return context.Clients.FirstOrDefault(user =>
             user.ClientId == ClientID
            && user.ClientSecret == ClientSecret);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}