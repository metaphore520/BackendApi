using System.Linq.Expressions;

namespace BackendApi.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {

        Task BulkAdd(List<T> listData);
        T Add(T obj);
        Task<T> Delete(T obj);
        T Edit(T obj);
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAll();
       // CustomerDBContext GetContext();
        Task SaveChangesAsync();
    }
}
