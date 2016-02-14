using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public interface ILocalService
    {
        SQLiteAsyncConnection Conn { get; }
        Task<object> ClearLocalDb();
    }
}
