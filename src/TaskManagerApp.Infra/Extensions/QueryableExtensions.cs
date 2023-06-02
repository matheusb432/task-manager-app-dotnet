using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<T?> RunFirstOrDefaultAsync<T>(
            this IQueryable<T> query,
            Expression<Func<T, bool>> predicate
        ) where T : Entity
        {
            return await query.FirstOrDefaultAsync(predicate);
        }

        public static async Task<List<T>> RunToListAsync<T>(this IQueryable<T> query)
            where T : Entity
        {
            return await query.ToListAsync();
        }
    }
}
