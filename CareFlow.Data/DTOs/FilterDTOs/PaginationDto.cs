namespace CareFlow.Core.DTOs.FilterDTOs
{
    public class PaginationDto
    {
        private const int maxPageSize = 10;
        private int pageSize = 5;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > maxPageSize ? value : value; }
        }
        public int PageIndex { get; set; } = 1;

    }
}
