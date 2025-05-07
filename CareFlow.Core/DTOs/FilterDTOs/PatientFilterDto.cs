using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.DTOs.FilterDTOs
{
    public class PatientFilterDto :PaginationDto
    {
		private string? search;

		public string? Search
		{
			get => search;
			set => search = value?.ToLower();
		}

	}
}
