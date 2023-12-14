using System; // 2611
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;

namespace API.Helpers;

public static class IQueryableExtensions
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginacionDto paginacionDto)
    {
        return queryable.Skip((paginacionDto.Page - 1) * paginacionDto.RecordsPerPage).Take(paginacionDto.RecordsPerPage);
    }
}