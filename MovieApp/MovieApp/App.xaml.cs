using MovieApp.Services.Abstractions;
using MovieApp.Services.Implementations;
using MovieApp.ViewModels;
using MovieApp.Views;
using SimpleInjector;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MovieApp;

public partial class App : Application
{
    public static readonly Container Container = new();

    private void RegisterServices()
    {
        Container.RegisterSingleton<IDataService, DataService>();
        Container.RegisterSingleton<IAccountService, AccountService>();

        Container.RegisterSingleton<MainViewModel>();
        Container.RegisterSingleton<LoginViewModel>();
        Container.RegisterSingleton<RegisterViewModel>(); // var a = new RegisterViewModel()

        Container.Verify();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        RegisterServices();

        var mainWindow = new MainView();

        mainWindow.DataContext = Container.GetInstance<MainViewModel>();

        mainWindow.ShowDialog();

        base.OnStartup(e);
    }

}

