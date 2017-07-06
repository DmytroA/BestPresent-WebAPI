using BestPresent.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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

        public HttpResponseMessage Post(CountriesModel country)
        {
            byte[] imageBytes = Convert.FromBase64String(country.ImagePath);
            Country newCountry = new Country();
            newCountry.Description = country.Description;
            newCountry.Name = country.Name;
            newCountry.ImageData = imageBytes;
            context.Countries.Add(newCountry);
            context.SaveChanges();
            return Request.CreateResponse(
                HttpStatusCode.Created);
        }

        public HttpResponseMessage Put(int id, CountriesModel country) {
            Country dbEntry = context.Countries.Find(id);
            byte[] imageBytes = Convert.FromBase64String(country.ImagePath);
            dbEntry.Description = country.Description;
            dbEntry.Name = country.Name;
            dbEntry.ImageData = imageBytes;
            context.SaveChanges();
            return Request.CreateResponse(
                HttpStatusCode.Created);
        }
    }
}
