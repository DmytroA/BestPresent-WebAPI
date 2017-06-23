using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestPresent.WebAPI.Models
{
    public class Pagination
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalNumberOfPages { get; set; }

        public int TotalNumberOfRecords { get; set; }
    }
}