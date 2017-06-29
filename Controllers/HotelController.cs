using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BestPresent.WebAPI.Models;
using System.Threading.Tasks;

namespace BestPresent.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class HotelController : BaseController
    {
        Entities context = new Entities();

        public async Task<IHttpActionResult> Get(int? page = 1, int pageSize = 5, string orderBy = nameof(Hotel.Id), bool ascending = true)
        {
            if (page == 1)
            {
                var hotels = from r in context.Hotels.Take(pageSize)
                             select new
                             {
                                 Id = r.Id,
                                 Name = r.Name,
                                 ImageData = r.ImageData,
                                 Category = r.Category,
                                 Description = r.Description,
                             };
                return Ok(hotels);
            }
            var hotel = await CreatePagedResults<Hotel, HotelsModel>
            (context.Hotels, page.Value, pageSize, orderBy, ascending);
            return Ok(hotel);
        }
       
        public HttpResponseMessage Get(int id)
        {
            var hotel = context.Hotels.First(p => p.Id == id);
            return Request.CreateResponse(
                HttpStatusCode.OK,
                hotel);
        }
    }
}
