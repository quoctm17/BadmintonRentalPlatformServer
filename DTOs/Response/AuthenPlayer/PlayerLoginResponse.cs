using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Response.AuthenPlayer
{
    public class PlayerLoginResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public PlayerLoginResponse(int id, string fullName, string email)
        {
            Id = id;
            FullName = fullName;
            Email = email;
        }
    }
}

