using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BestPresent.WebAPI.Models;
using System.Threading.Tasks;
using System;

namespace BestPresent.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class HotelController : BaseController
    {
        Entities context = new Entities();

        public async Task<IHttpActionResult> Get(int? page = 1, int pageSize = 5, string orderBy = nameof(Hotel.Id), bool ascending = true)
        {
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
        public HttpResponseMessage Post(HotelsModel hotel)
        {
            byte[] imageBytes = Convert.FromBase64String(hotel.ImagePath);
            Hotel newHotel = new Hotel();
            newHotel.Description = hotel.Description;
            newHotel.Name = hotel.Name;
            newHotel.ImageData = imageBytes;
            context.Hotels.Add(newHotel);
            context.SaveChanges();
            return Request.CreateResponse(
                HttpStatusCode.Created);
        }
    }
}
