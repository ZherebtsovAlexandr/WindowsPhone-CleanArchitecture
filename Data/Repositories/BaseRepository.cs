using Data.Services;
using Data.SqLite;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public abstract class BaseRepository<TTable, K> : IRepository<TTable, K>
        where TTable : IKeyedTable<K>, new()
    {
        protected ILocalService _localService;

        public BaseRepository(ILocalService localService)
        {
            _localService = localService;
        }

        public Task<TTable> LoadByIdAsync(K id)
        {
            var query = _localService.Conn.Table<TTable>().Where(item => item.Id.Equals(id));
            return query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TTable>> LoadAllAsync()
        {
            var query = _localService.Conn.Table<TTable>();
            var array = (await query.ToListAsync()).ToArray();
            return array;
        }

        public Task InsertAsync(TTable item)
        {
            return _localService.Conn.InsertAsync(item);
        }

        public Task UpdateAsync(TTable item)
        {
            return _localService.Conn.UpdateAsync(item);
        }

        public Task DeleteAsync(TTable item)
        {
            return _localService.Conn.DeleteAsync(item);
        }

        public AsyncTableQuery<TTable> Query()
        {
            return _localService.Conn.Table<TTable>();
        }
    }
}
