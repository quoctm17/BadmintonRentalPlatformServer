using BusinessObjects.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Response.BadmintonCourt
{
    public class BadmintonCourtDto
    {
        public int Id { get; set; }
        public string CourtName { get; set; }
        public int CourtNumber { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int NumberOfCourt { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public int CourtOwnerId { get; set; }
        public List<string> CourtImagePaths { get; set; }
    }
}
