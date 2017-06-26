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
using BestPresent.WebAPI.Models;
using System.Threading.Tasks;
using BestPresent.WebAPI.Extensions;
using AutoMapper.QueryableExtensions;

namespace BestPresent.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class HomeController : ApiController
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
        protected async Task<PagedResults<TReturn>> CreatePagedResults<T, TReturn>(
            IQueryable<T> queryable,
            int page,
            int pageSize,
            string orderBy,
            bool ascending)
        {
            var skipAmount = pageSize * (page - 1);

            var projection = queryable
                .OrderByPropertyOrField(orderBy, ascending)
                .Skip(skipAmount)
                .Take(pageSize).ProjectTo<TReturn>();

            var totalNumberOfRecords = queryable.Count();
            var results = projection.ToList();

            var mod = totalNumberOfRecords % pageSize;
            var totalPageCount = (totalNumberOfRecords / pageSize) + (mod == 0 ? 0 : 1);

            return new PagedResults<TReturn>
            {
                data = results,
                Pagination = new Pagination {
                    PageNumber = page,
                    PageSize = results.Count,
                    TotalNumberOfPages = totalPageCount,
                    TotalNumberOfRecords = totalNumberOfRecords,
                },
            };
        }
    }
}
