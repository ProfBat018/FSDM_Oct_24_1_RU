using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Abstractions;

interface IDataService
{
    public IEnumerable<T> GetAllData<T>() where T : IEntity;
    public void AddData<T>(T data) where T : IEntity;
}


