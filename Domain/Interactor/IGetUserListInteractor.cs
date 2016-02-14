using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interactor
{
    public interface IGetUserListInteractor
    {
        IObservable<IEnumerable<User>> Execute();
    }
}
