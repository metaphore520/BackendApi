using BackendApi.Contracts;
using BackendApi.DbContextFile;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BackendApi.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly AssesmentDbContext _context;
        public RepositoryBase(AssesmentDbContext context)
        {
            this._context = context;

        }

        public async Task BulkAdd(List<T> listData)
        {

            foreach (var item in listData)
            {
                Add(item);
            }
            await SaveChangesAsync();
        }

        public T Add(T obj)
        {
            _context.Set<T>().Add(obj);
            return obj;
        }
        public async Task<T> Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        public T Edit(T obj)
        {
            _context.Set<T>().Update(obj);
            return obj;
        }
        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> expression)
        {
            return await this._context.Set<T>().AsNoTracking().Where(expression).ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await this._context.Set<T>().AsNoTracking().ToListAsync();

        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}
