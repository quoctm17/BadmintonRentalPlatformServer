using BusinessObjects.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Request.Court
{
    public class CourtRequest
    {
        [Required(ErrorMessage = MessageConstant.Vi.Court.Require.CourtCodeRequired)]
        public string CourtCode { get; set; }
        [Required(ErrorMessage = MessageConstant.Vi.Court.Require.TypeOfCourtRequired)]
        public int TypeOfCourtId { get; set; }
        [Required(ErrorMessage = MessageConstant.Vi.Court.Require.BadmintonCourtRequired)]
        public int BadmintonCourtId { get; set; }
    }
}
