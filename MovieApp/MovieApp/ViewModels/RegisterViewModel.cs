using GalaSoft.MvvmLight;
using MovieApp.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.ViewModels;

class RegisterViewModel : ViewModelBase
{
    private readonly IAccountService _accountService;

    public RegisterViewModel(IAccountService accountService)
    {
        _accountService = accountService;

    }

}
