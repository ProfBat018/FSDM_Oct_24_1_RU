using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MovieApp.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.ViewModels;

class SearchViewModel : ViewModelBase
{
    private readonly IMessenger _messenger;

    public SearchViewModel(IMessenger messenger)
    {
        _messenger = messenger;

        //_messenger.Send(new NavigationMessage(typeof(LoginViewModel)));

        var a = App.Container.GetInstance<MainViewModel>();
        a.CurrentView = App.Container.GetInstance<LoginViewModel>();
    }
}
