using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Specifications
{
    public class SpecificationParameters
    {
        private const int maxPageSize = 10;
        private int pageSize = 5;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > maxPageSize ? value : value; }
        }

        private string? search;

        public string? Search
        {
            get { return search; }
            set { search = value?.ToLower(); }
        }


        public int PageIndex { get; set; } = 1;
    }
}
