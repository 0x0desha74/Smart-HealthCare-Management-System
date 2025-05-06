using CareFlow.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.DTOs.FilterDTOs
{
    public class PrescriptionFilterDto : PaginationDto
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public PrescriptionStatus Status { get; set; }

        private string? search;

        public string? Search
        {
            get => search;
            set => search = value?.ToLower();
        }
    }
}
