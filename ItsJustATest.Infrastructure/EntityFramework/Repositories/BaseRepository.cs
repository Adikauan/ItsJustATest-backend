using Microsoft.EntityFrameworkCore;
using ItsJustATest.Domain.Interfaces;
using ItsJustATest.Infrastructure.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ItsJustATest.Infrastructure.EntityFramework.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly SampleDbContext context;

        public BaseRepository(SampleDbContext context) => this.context = context;

        public void Add(T entity) => context.Set<T>().Add(entity);

        public async Task<IEnumerable<T>> GetAllAsync() => await context.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate) => await context.Set<T>().FirstOrDefaultAsync(predicate);

        public void Remove(T entity) => context.Set<T>().Remove(entity);

        public void Update(T entity) => context.Set<T>().Update(entity);
    }
}
