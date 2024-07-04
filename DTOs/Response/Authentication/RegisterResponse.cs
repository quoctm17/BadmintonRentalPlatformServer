using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Response.Authentication
{
    public class RegisterResponse : LoginResponse
    {
        public RegisterResponse(int id, string fullName, string email, string gender, DateTime dateOfBirth, string address, string profileImage, string phoneNumber, RoleEnum role) : base(id, fullName, email, gender, dateOfBirth, address, profileImage, phoneNumber, role)
        {
        }
    }
}
