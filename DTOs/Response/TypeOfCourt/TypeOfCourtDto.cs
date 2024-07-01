using BusinessObjects.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Response.TypeOfCourt
{
    public class TypeOfCourtDto
    {
        public int Id { get; set; } 
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }
    }
}
