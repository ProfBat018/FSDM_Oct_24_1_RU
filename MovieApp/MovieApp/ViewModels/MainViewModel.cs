using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MovieApp.Messages;
using MovieApp.Services.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MovieApp.ViewModels;


class MainViewModel : ViewModelBase, INotifyPropertyChanged
{
    private readonly IMessenger _messenger;
    private ViewModelBase _currentView = App.Container.GetInstance<RegisterViewModel>();


    public MainViewModel(IMessenger messenger)
    {
        _messenger = messenger;

        _messenger.Register<NavigationMessage>(this, message =>
        {
            CurrentView = App.Container.GetInstance(message.ViewModelType) as ViewModelBase;

        });
    }

    public ViewModelBase CurrentView
    {
        get => _currentView; set
        {
            Set(ref _currentView, value);
        }
    }

    public MyRelayCommand LoginPageCommand
    {
        get => 
        new(
            () =>
            {
                _messenger.Send<NavigationMessage>(new(typeof(LoginViewModel)));
            },
            () => CurrentView.GetType() != typeof(LoginViewModel));
    }

    public MyRelayCommand RegisterPageCommand
    {
        get =>
        new(
            () =>
            {
                _messenger.Send<NavigationMessage>(new(typeof(RegisterViewModel)));
            },
            () => CurrentView.GetType() != typeof(RegisterViewModel));
    }

  
}
