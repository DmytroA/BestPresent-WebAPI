using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http.Headers;

namespace BestPresent.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class HomeController : ApiController
    {
        Entities context = new Entities();

        public HttpResponseMessage Get()
        {
            var hotels = from r in context.Hotels.Take(5)
               select new
            {
                Id = r.Id,
                Name = r.Name,
                ImageData = r.ImageData,
            };
            Console.WriteLine(hotels);
           // var result = hotels.ToList();
            return Request.CreateResponse(
                HttpStatusCode.OK,
                hotels);
        }
    }
}
