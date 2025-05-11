
namespace CareFlow.Core.DTOs.FilterDTOs
{
    public class DocumentFilterDto : PaginationDto
    {
        public string? Sort { get; set; }
        private string? search;

        public string? Search
        {
            get => search;
            set => search = value?.ToLower();
        }
    }
}
