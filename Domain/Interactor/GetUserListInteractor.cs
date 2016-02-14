using Domain.Model;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Interactor
{
    public class GetUserListInteractor : IGetUserListInteractor
    {
        private readonly IUserRepository _userRepository;

        public GetUserListInteractor(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IObservable<IEnumerable<User>> Execute()
        {
            return _userRepository.GetAllUsers();
        }

    }
}
