using BusinessObjects;
using BusinessObjects.Enums;
using BusinessObjects.Helpers;
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
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string ProfileImage { get; set; }
        public string PhoneNumber { get; set; }
        public RoleEnum Role { get; set; }

        public LoginResponse(int id, string fullName, string email, string gender, DateTime dateOfBirth, string address, string profileImage, string phoneNumber, RoleEnum role)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Address = address;
            ProfileImage = profileImage;
            PhoneNumber = phoneNumber;
            Role = role;
        }
    }
}
