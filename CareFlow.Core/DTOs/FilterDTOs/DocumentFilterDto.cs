
namespace CareFlow.Core.DTOs.FilterDTOs
{
    public class DocumentFilterDto: PaginationDto
    {
        private string? search;

        public string? Search
        {
            get => search;
            set => search = value?.ToLower();
        }
    }
}
