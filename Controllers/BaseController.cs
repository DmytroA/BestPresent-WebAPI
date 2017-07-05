using AutoMapper.QueryableExtensions;
using BestPresent.WebAPI.Extensions;
using BestPresent.WebAPI.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace BestPresent.WebAPI.Controllers
{
    public abstract class BaseController : ApiController
    {
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
                Pagination = new Pagination
                {
                    page = page,
                    perPage = results.Count,
                    totalNumberOfPages = totalPageCount,
                    total = totalNumberOfRecords,
                },
            };
        }
    }
}
