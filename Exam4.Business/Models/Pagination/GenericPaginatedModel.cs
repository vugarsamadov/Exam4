using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam4.Business.Models.Pagination
{
    public class GenericPaginatedModel<T>
    {
        public GenericPaginatedModel(int perPage, int currentPage, int rowCount, IEnumerable<T> data)
        {
            PerPage = perPage;
            CurrentPage = currentPage;
            RowCount = rowCount;
            Data = data;
        }

        public int PerPage { get; set; }
        public int CurrentPage { get; set; }
        public int RowCount { get; set; }
        public IEnumerable<T> Data { get; set; }

        public int PageCount { get => (int)Math.Ceiling(RowCount*1.0/PerPage); }
        public bool HasNext { get => CurrentPage < PageCount; }
        public bool HasPrev { get => CurrentPage > 1; }

        public string Next { get; set; }
        public string Prev { get; set; }



    }
}
