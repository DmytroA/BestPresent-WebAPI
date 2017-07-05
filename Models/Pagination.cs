using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestPresent.WebAPI.Models
{
    public class Pagination
    {
        public int page { get; set; }

        public int perPage { get; set; }

        public int totalNumberOfPages { get; set; }

        public int total { get; set; }
    }
}