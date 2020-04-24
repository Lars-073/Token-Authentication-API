using Api_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Application.Repositories
{
    public class UserRepository : IDisposable
    {
        private API_Entities _context = new API_Entities();
        
        public User ValidateUser(string username, string password)
        {
            return _context.Users.FirstOrDefault(user =>
            user.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
            && user.UserPassword == password);
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}