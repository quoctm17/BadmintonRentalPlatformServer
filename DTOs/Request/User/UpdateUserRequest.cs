using BusinessObjects.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Request.User
{
    public class UpdateUserRequest
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = MessageConstant.Vi.User.Require.FullNameRequired)]
        public string FullName { get; set; }
        [Required(ErrorMessage = MessageConstant.Vi.User.Require.EmailRequired)]
        public string Email { get; set; }
        [Required(ErrorMessage = MessageConstant.Vi.User.Require.GenderRequired)]
        public string Gender { get; set; }
        [Required(ErrorMessage = MessageConstant.Vi.User.Require.DateOfBirthRequired)]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = MessageConstant.Vi.User.Require.AddressRequired)]
        public string Address { get; set; }
        [Required(ErrorMessage = MessageConstant.Vi.User.Require.PasswordRequired)]
        public string Password { get; set; }
        [Required(ErrorMessage = MessageConstant.Vi.User.Require.ProfileImageRequired)]
        public string ProfileImage { get; set; }
        [Required(ErrorMessage = MessageConstant.Vi.User.Require.PhoneNumberRequired)]
        public string PhoneNumber { get; set; }
    }
}
