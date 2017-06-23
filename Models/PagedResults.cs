using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestPresent.WebAPI.Models
{
    public class PagedResults<T>
    {
        public Pagination Pagination { get; set; }
        public IEnumerable<T> data { get; set; }
    }
}