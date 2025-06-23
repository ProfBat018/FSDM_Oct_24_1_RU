using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MovieApp.DTOs.Requests;
using MovieApp.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MovieApp.ViewModels;

class RegisterViewModel : ViewModelBase
{
    private readonly IAccountService _accountService;
    public RegisterRequest Register { get; set; }

    public RegisterViewModel(IAccountService accountService)
    {
        _accountService = accountService;
        Register = new();
    }

    public RelayCommand RegisterCommand
    {
        get => new(() =>
    {
        var res = _accountService.RegisterUser(Register);

        if (res.Data == null)
        {
            MessageBox.Show("Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    });
    }

}
