using CareFlow.Core.DTOs.Response;
using CareFlow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.DTOs.FilterDTOs
{
   public class ClinicFilterDto : PaginationDto
    {
        //public string? Name { get; set; }
        //public string? Country { get; set; }
        //public string? City { get; set; }
        //public string? Street { get; set; }
        //public string? AddressLine1 { get; set; }

        private string? search;

        public string? Search
        {
            get => search;
            set => search = value?.ToLower();
        }
    }
}
