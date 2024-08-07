﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class CourtEntity
    {
        [Key]
        public int Id { get; set; }
        public string CourtCode { get; set; }

        public int TypeOfCourtId { get; set; }
        public TypeOfCourtEntity TypeOfCourt { get; set; }

        public int BadmintonCourtId { get; set; }
        public BadmintonCourtEntity BadmintonCourt { get; set; }
        public float Price { get; set; }
        public string CourtImage {  get; set; }
        public ICollection<CourtSlotEntity> CourtSlots { get; set; }
        public ICollection<BookingDetailEntity> BookingDetailEntities { get; set; }
    }

}
