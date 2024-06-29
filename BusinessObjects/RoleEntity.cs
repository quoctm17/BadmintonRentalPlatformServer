using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class RoleEntity
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();
    }

}
