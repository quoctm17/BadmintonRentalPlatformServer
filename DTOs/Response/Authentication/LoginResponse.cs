using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Response.Authentication
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public LoginResponse(int id, string fullName, string email)
        {
            Id = id;
            FullName = fullName;
            Email = email;
        }       
    }
}
