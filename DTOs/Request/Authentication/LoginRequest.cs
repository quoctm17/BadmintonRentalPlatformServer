using BusinessObjects.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Request.Authentication
{
    public class LoginRequest
    {
        [Required(ErrorMessage = MessageConstant.Vi.User.Require.EmailRequired)]
        [MaxLength(50, ErrorMessage = "Email's max length is 50 characters")]
        public string Email { get; set; }
        [Required(ErrorMessage = MessageConstant.Vi.User.Require.PasswordRequired)]
        [MaxLength(64, ErrorMessage = "Password's max length is 64 characters")]
        public string Password { get; set; }
    }
}
