using BusinessObjects;
using BusinessObjects.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Response.Court
{
    public class CourtDto
    {
        public int Id { get; set; }
        public string CourtCode { get; set; }
        public int TypeOfCourtId { get; set; }
        public int BadmintonCourtId { get; set; }
    }
}
