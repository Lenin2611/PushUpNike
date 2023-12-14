using System; // 2611
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Helpers;

public static class HttpContextExtension
{
    public async static Task InsertPaginationHeader<T>(this HttpContext httpContext, IQueryable<T> queryable)
    {
        if (httpContext == null)
        {
            throw new ArgumentNullException(nameof(httpContext));
        }
        double quantity = await queryable.CountAsync();
        httpContext.Response.Headers.Append("TotalRegisters", quantity.ToString());
    }
}