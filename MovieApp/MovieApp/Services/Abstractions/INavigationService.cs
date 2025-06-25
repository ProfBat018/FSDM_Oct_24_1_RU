using GalaSoft.MvvmLight;
using MovieApp.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Abstractions;

interface INavigationService
{
    public void NavigateTo<T>(NavigationMessage message) where T : ViewModelBase;
}
