﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string PasswordEncrypt { get; set; }
        public string ProfileImage { get; set; }
        public string PhoneNumber { get; set; }

        public int RoleId { get; set; }
        public virtual RoleEntity Role { get; set; } = null!;

        public ICollection<BadmintonCourtEntity> BadmintonCourts { get; set; } = new List<BadmintonCourtEntity>();
        public ICollection<NotificationEntity> Notifications { get; set; }
        public ICollection<BookingReservationEntity> BookingReservations { get; set; }
    }

}
