using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.DTOs.Requests
{
   public class DocumentToUpdateDto
    {
        public bool? IsActive { get; set; }
        [Required]
        public string Version { get; set; }
    }
}
