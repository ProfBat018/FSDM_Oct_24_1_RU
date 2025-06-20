using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.ViewModels;


class MainViewModel : ViewModelBase
{
    public ViewModelBase CurrentView { get; set; } = App.Container.GetInstance<RegisterViewModel>();
}
