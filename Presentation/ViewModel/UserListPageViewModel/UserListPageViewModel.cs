using Domain.Interactor;
using Domain.Model;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace Presentation.ViewModels
{
    public class UserListPageViewModel : ViewModel
    {
        private readonly IGetUserListInteractor _getUserListInteractor;

        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set { SetProperty(ref _users, value); }
        }

        public UserListPageViewModel(IGetUserListInteractor getUserListInteractor)
        {
            _getUserListInteractor = getUserListInteractor;
        }

        public override void OnNavigatedTo(object navigationParameter, Windows.UI.Xaml.Navigation.NavigationMode navigationMode, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(navigationParameter, navigationMode, viewModelState);
            Init();
        }

        public void Init()
        {
            //TODO: observeOn https://www.nuget.org/packages/Rx-WindowStoreApps/
            var usersObservable = _getUserListInteractor.Execute();
            usersObservable.Subscribe(users =>
            {
                CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                () =>
                {
                    Users = new ObservableCollection<User>(users);
                });
                
            });
        }
    }
}
