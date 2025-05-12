using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.DTOs.Requests
{
   public class ReviewToUpdateDto
    {
        [MaxLength(2000)]
        public string? Comment { get; set; }
        [Required, Range(1, 5)]
        public int Rating { get; set; }
    }
}
