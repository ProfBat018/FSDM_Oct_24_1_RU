using MovieApp.Models;
using MovieApp.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MovieApp.Services.Implementations;

class DataService : IDataService
{
    public void AddData<T>(T data) where T : IEntity
    {
        List<T>? values = GetAllData<T>() as List<T>;

        using var fs = OpenOrCreateFile<T>();
        using StreamWriter sw = new(fs);


        if (values == null)
        {
            values = new();
        }
        values.Add(data);

        var dataToSave = JsonSerializer.Serialize(values);
        sw.Write(dataToSave);
    }

 
    public IEnumerable<T> GetAllData<T>() where T : IEntity
    {
        using var fs = OpenOrCreateFile<T>();
        using StreamReader sr = new(fs);

        var json = sr.ReadToEnd();

        if (String.IsNullOrEmpty(json))
        {
            return null;
        }

        var res = JsonSerializer.Deserialize<IEnumerable<T>>(json);

        return res;
    }


    private FileStream OpenOrCreateFile<T>()
    {
        var typeName = typeof(T);
        var path = $"{typeName}sData.json";

        var fs = new FileStream(path, FileMode.OpenOrCreate);

        return fs;
    }
}
