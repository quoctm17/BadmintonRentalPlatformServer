using BusinessObjects.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Request.BadmintonCourt
{
    public class CreateBadmintonCourtRequest
    {
        [Required(ErrorMessage = MessageConstant.Vi.BadmintonCourt.Require.CourtNameRequired)]
        public string CourtName { get; set; }
        [Required(ErrorMessage = MessageConstant.Vi.BadmintonCourt.Require.CourtNumberRequired)]
        public int CourtNumber { get; set; }
        [Required(ErrorMessage = MessageConstant.Vi.BadmintonCourt.Require.StartTimeRequired)]
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = MessageConstant.Vi.BadmintonCourt.Require.EndTimeRequired)]
        public DateTime EndTime { get; set; }
        [Required(ErrorMessage = MessageConstant.Vi.BadmintonCourt.Require.NumberOfCourtRequired)]
        public int NumberOfCourt { get; set; }
        [Required(ErrorMessage = MessageConstant.Vi.BadmintonCourt.Require.AddressRequired)]
        public string Address { get; set; }
        [Required(ErrorMessage = MessageConstant.Vi.BadmintonCourt.Require.DescriptionRequired)]
        public string Description { get; set; }
        public float Rating { get; set; }
        [Required(ErrorMessage = MessageConstant.Vi.BadmintonCourt.Require.CourtOwnerRequired)]
        public int CourtOwnerId { get; set; }
    }
}
