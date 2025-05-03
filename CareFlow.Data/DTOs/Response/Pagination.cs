using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.DTOs.Response
{
   public class Pagination<T>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }

        public Pagination(int pageSize, int pageIndex, int count, IReadOnlyList<T> data)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            Count = count;
            Data = data;
        }

    }
}
