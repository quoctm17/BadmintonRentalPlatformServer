using BusinessObjects;
using BusinessObjects.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Request.CourtSlot
{
    public class CourtSlotRequest
    {
        [Required(ErrorMessage = MessageConstant.Vi.CourtSlot.Require.CourtNumberRequired)]
        public int CourtNumberId { get; set; }
        [Required(ErrorMessage = MessageConstant.Vi.CourtSlot.Require.StartTimeRequired)]
        public TimeSpan StartTime { get; set; }
        [Required(ErrorMessage = MessageConstant.Vi.CourtSlot.Require.EndTimeRequired)]
        public TimeSpan EndTime { get; set; }
        [Required(ErrorMessage = MessageConstant.Vi.CourtSlot.Require.PriceRequired)]
        public float Price { get; set; }
    }
}
