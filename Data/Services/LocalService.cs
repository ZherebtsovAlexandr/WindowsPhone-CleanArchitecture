using Data.Model;
using SQLite;
using System.Threading.Tasks;

namespace Data.Services
{
    [Table("Information")]
    public class Information
    {
        [Column("Version")]
        public int Version { get; set; }
    }

    public class LocalService : ILocalService
    {
        private readonly SQLiteAsyncConnection _conn;

        public LocalService()
        {
            _conn = new SQLiteAsyncConnection("sample.db");
            InitDb();
        }

        public SQLiteAsyncConnection Conn
        {
            get { return _conn; }
        }

        private async Task<object> InitDb()
        {
            // Create tables - does nothing if the tables already exist (except add missing columns)
            var createTasks = new Task[]
            {         
                Conn.CreateTableAsync<UserEntity>()
            };

            Task.WaitAll(createTasks);            

            return InsertTestDataAsync();
        }

        private async Task InsertTestDataAsync()
        {
            if (await Conn.Table<UserEntity>().CountAsync() == 0)
            {
                await Conn.InsertAllAsync(new[]
                {
                    new UserEntity {Id = 1, Name = "Alexandr", Age = 25},
                    new UserEntity {Id = 2, Name = "John", Age = 36},
                    new UserEntity {Id = 3, Name = "Deniel", Age = 45},
                    new UserEntity {Id = 4, Name = "Albert", Age = 34},
                    new UserEntity {Id = 5, Name = "Elena", Age = 44},
                    new UserEntity {Id = 6, Name = "Matilda", Age = 32},
                    new UserEntity {Id = 7, Name = "Mark", Age = 42},
                    new UserEntity {Id = 8, Name = "Martin", Age = 52},
                    new UserEntity {Id = 9, Name = "Rebeka", Age = 24},
                    new UserEntity {Id = 10, Name = "Bob", Age = 20},
                });
            }
        }

        public async Task<object> ClearLocalDb()
        {
            await Conn.DropTableAsync<UserEntity>();          
            return await InitDb();
        }
    }
}
