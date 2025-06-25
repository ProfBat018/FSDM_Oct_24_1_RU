

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MovieApp.Messages;
using MovieApp.Services.Abstractions;

namespace MovieApp.Services.Implementations;

class NavigationService : INavigationService
{
    private readonly IMessenger _messenger;

    public NavigationService(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void NavigateTo<T>(NavigationMessage message) where T: ViewModelBase
    {
        _messenger.Send<NavigationMessage>(message);
    }
}
