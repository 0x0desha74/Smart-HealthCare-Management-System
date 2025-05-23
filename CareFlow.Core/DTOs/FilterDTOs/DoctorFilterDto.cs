﻿namespace CareFlow.Core.DTOs.FilterDTOs
{
    public class DoctorFilterDto : PaginationDto
    {
        public string? Sort { get; set; }
        private string? search;

        public string? Search
        {
            get => search;
            set => search = value?.ToLower();
        }
        private string? clinic;

        public string? Clinic
        {
            get => clinic;
            set => clinic = value?.ToLower();
        }

    }
}
