using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Messages;

class NavigationMessage(Type viewModelType, object? data=null)
{
    public Type ViewModelType = viewModelType;
    public object? data = data;
}