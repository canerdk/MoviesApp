using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Entities.Common
{
    public class PaginationResponse<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Total_pages { get; set; }
        public int Total_results { get; set; }
        public List<T> Results { get; set; } = new List<T>();
    }
}
