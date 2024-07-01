using BusinessObjects.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Request.TypeOfCourt
{
    public class TypeOfCourtRequest
    {
        [Required(ErrorMessage = MessageConstant.Vi.TypeOfCourt.Require.TypeNameRequired)]
        public string TypeName { get; set; }
        [Required(ErrorMessage = MessageConstant.Vi.TypeOfCourt.Require.TypeDescriptionRequired)]
        public string TypeDescription { get; set; }

    }
}
