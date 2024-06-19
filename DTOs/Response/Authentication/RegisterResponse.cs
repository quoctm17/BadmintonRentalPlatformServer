using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Response.Authentication
{
    public class RegisterResponse : LoginResponse
    {
        public RegisterResponse(int id, string fullName, string email) : base(id, fullName, email)
        {
        }
    }
}
