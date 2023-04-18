using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Entities.Common
{
    public class PaginationRequest
    {
        public PaginationRequest()
        {
            PageIndex = 1;
            PageSize = 10;
        }

        public PaginationRequest(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex < 1 ? 1 : pageIndex;
            PageSize = pageSize < 10 ? 10 : pageSize;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
