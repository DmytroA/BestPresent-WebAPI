using BestPresent.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BestPresent.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CountryController : BaseController
    {
        Entities context = new Entities();

        public async Task<IHttpActionResult> Get(int? page = 1, int pageSize = 5, string orderBy = nameof(Country.Id), bool ascending = true)
        {
            if (page == 1)
            {
                var countries = from r in context.Countries.Take(pageSize)
                             select new
                             {
                                 Id = r.Id,
                                 Name = r.Name,
                                 ImageData = r.ImageData,
                                 Description = r.Description,
                             };
                return Ok(countries);
            }
            var country = await CreatePagedResults<Country, CountriesModel>
            (context.Countries, page.Value, pageSize, orderBy, ascending);
            return Ok(country);
        }

        public HttpResponseMessage Get(int id)
        {
            var country = context.Countries.First(p => p.Id == id);
            return Request.CreateResponse(
                HttpStatusCode.OK,
                country);
        }
    }
}
