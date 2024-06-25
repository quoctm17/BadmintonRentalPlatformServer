using BusinessObjects.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Request.AuthenPlayer
{
    public class PlayerRegisterRequest
    {
        [Required(ErrorMessage = MessageConstant.Vi.User.Require.FullNameRequired)]
        public string FullName { get; set; } = string.Empty;
        [Required(ErrorMessage = MessageConstant.Vi.User.Require.EmailRequired)]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = MessageConstant.Vi.User.Require.GenderRequired)]
        public string Phone { get; set; } = string.Empty;
        [Required(ErrorMessage = MessageConstant.Vi.User.Require.PhoneNumberRequired)]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = MessageConstant.Vi.User.Require.ProfileImageRequired)]
        public string Address { get; set; } = string.Empty;
    }
}
