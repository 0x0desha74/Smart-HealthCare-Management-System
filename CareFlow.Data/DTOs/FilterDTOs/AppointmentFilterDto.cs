using CareFlow.Data.Entities.Enums;


namespace CareFlow.Core.DTOs.FilterDTOs
{
    public class AppointmentFilterDto : PaginationDto
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public AppointmentStatus Status{ get; set; }
        public Guid? ClinicId { get; set; }
        public string? Doctor { get; set; }
        public string? Patient { get; set; }
        public string? Clinic { get; set; }
        private string? search ;

        public string? Search
        {
            get  =>  search ; 
            set  => search  = value?.ToLower(); 
        }

    }
}
