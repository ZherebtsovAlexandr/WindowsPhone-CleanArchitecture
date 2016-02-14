using Data.Model;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapper
{
    public class UserEntityMapper : IEntityMapper<UserEntity, User>
    {
        public UserEntityMapper() { }

        public User TransformTo(UserEntity userEntity)
        {
            if (userEntity == null)
                throw new ArgumentNullException("User null");
            var user = new User()
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Age = userEntity.Age
            };
            return user;
        }

        public IEnumerable<User> TransformTo(IEnumerable<UserEntity> userEntityCollection)
        {
            if (userEntityCollection == null)
                throw new ArgumentNullException("Users  collection null");
            var userCollection = new List<User>();
            foreach (var user in userEntityCollection)
            {
                userCollection.Add(TransformTo(user));
            }
            return userCollection;
        }
    }
}
