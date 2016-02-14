using Data.SqLite;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IRepository<T, K>
     where T : IKeyedTable<K>, new()
    {
        Task<T> LoadByIdAsync(K id);
        Task<IEnumerable<T>> LoadAllAsync();
        Task InsertAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
        AsyncTableQuery<T> Query();

    }
}
