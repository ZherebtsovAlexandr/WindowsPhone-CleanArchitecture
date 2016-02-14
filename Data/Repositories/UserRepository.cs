using Data.Model;
using Domain.Model;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Threading.Tasks;
using System.Reactive.Linq;
using Data.Mapper;
using Data.Services;
using System.Text;

namespace Data.Repositories
{
    public class UserRepository : BaseRepository<UserEntity, int>, IUserRepository
    {
        private readonly UserEntityMapper _userEntityMapper;

        public UserRepository(ILocalService localService, UserEntityMapper userEntityMapper) 
            : base(localService)
        {
            _userEntityMapper = userEntityMapper;
        }

        public IObservable<IEnumerable<User>> GetAllUsers()
        {           
            return this.LoadAllAsync()
                .ToObservable()
                .Select(users => _userEntityMapper.TransformTo(users));
        }

        public IObservable<IEnumerable<User>> GetAllUsersAgeGreaterThan(int age)
        {           
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM User ");
            sql.AppendFormat("WHERE `Age` > {0}", age);
            return _localService.Conn.QueryAsync<UserEntity>(sql.ToString())
                                     .ToObservable()
                                     .Select(users => _userEntityMapper.TransformTo(users));
        }

    }
}
