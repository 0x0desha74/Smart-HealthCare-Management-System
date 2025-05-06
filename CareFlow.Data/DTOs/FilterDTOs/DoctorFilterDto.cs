using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.DTOs.FilterDTOs
{
    public class DoctorFilterDto : PaginationDto
    {
        public string? Search { get; set; }
        public string? Clinic { get; set; }
    }
}
