using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Response.AuthenPlayer
{
   public class PlayerRegisterResponse : PlayerLoginResponse
    {
        public PlayerRegisterResponse(int id, string fullName, string email) : base(id, fullName, email)
        {
        }
    }
}
