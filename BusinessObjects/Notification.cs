using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class NotificationEntity
    {
        public int Id { get; set; }
        public string NotificationContent { get; set; }
        public DateTime Timestamp { get; set; }
        public string NotificationType { get; set; }

        public int UserId { get; set; }
        public UserEntity User { get; set; }
    }

}
