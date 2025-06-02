#region BinarySerializationExample
/*
using System.Runtime.Serialization.Formatters.Binary;

#pragma warning disable SYSLIB0011

BinaryFormatter a = new();
using var fs = new FileStream("person.bin", FileMode.OpenOrCreate);

Person p1 = new()
{
    Name = "Elvin",
    SurName = "Azimov",
    Age = 23
};

a.Serialize(fs, p1);



#pragma warning restore SYSLIB0011


// Атрибут, который обязательно нужен для бинарной сериализации
[Serializable] 
class Person
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public int Age { get; set; }
}
*/
#endregion

#region XmlSerializationExample
/*
/*

#region Serialization

/*

using System.Xml.Serialization;

var people = new List<Person>
{
    new Person { Name = "Elvin", SurName = "Azimov", Age = 23 },
    new Person { Name = "John", SurName = "Doe", Age = 30 }
};

XmlSerializer serializer = new(typeof(List<Person>));

using FileStream fs = new("people.xml", FileMode.OpenOrCreate);
serializer.Serialize(fs, people);

#endregion


#region DeSerialization
/*
using System.Xml.Serialization;

using FileStream fs = new("people.xml", FileMode.OpenOrCreate);
XmlSerializer serializer = new(typeof(List<Person>));

var res = serializer.Deserialize(fs) as List<Person>;

if (res != null)
{
    foreach (var person in res)
    {
        Console.WriteLine(person);
    }
}
#endregion





// В случае с XML, нам обязательно нужно создать конструктор по умолчанию
// и сделать класс публичным, чтобы XMLSerializer мог работать с ним.
public class Person
{
    public Person()
    {
        
    }
    
    public string Name { get; set; }
    public string SurName { get; set; }
    public int Age { get; set; }

    public override string ToString()
    {
        return $"{Name} {SurName}, {Age} years old";
    }
}
*/

#endregion

#region JsonSerializationExample

/*
using System.Text.Json;
using System.Text.Json.Serialization;

using FileStream fs = new("data.json", FileMode.Truncate);
using StreamWriter sw = new(fs);

var people = new List<Person>
{
    new Person { Name = "Elvin", Surname = "Azimov", Age = 23 },
    new Person { Name = "John", Surname = "Doe", Age = 30 }
};

var group = new Group
{
    People = people
};

var json = JsonSerializer.Serialize(people);

sw.Write(json);


class Group
{
    public List<Person> People { get; set; }
}

class Person
{
    // [JsonIgnore]
    
    [JsonPropertyName("FirstName")]
    public string Name { get; set; }
    
    [JsonPropertyName("LastName")]
    public string Surname { get; set; }
    public int Age { get; set; }
}
*/

#endregion

#region WeatherApi
/*
using System.Text.Json;
using System.Text.Json.Serialization;

HttpClient client = new();

HttpRequestMessage message = new()
{
    Method = HttpMethod.Get,
    RequestUri =
        new(
            "https://api.openweathermap.org/data/2.5/weather?q=Baku&units=metric&appid=5191fee1957155f779bfd029a4a97e18"),
    Headers =
    {
        { "Accept", "application/json" }
    }
};

HttpResponseMessage response = client.Send(message);

if (response.IsSuccessStatusCode)
{
    using var fs =  response.Content.ReadAsStream();
    using StreamReader sr = new(fs);
    string json = sr.ReadToEnd();

    var forecast = JsonSerializer.Deserialize<Forecast>(json);

    if (forecast != null)
    {
        Console.WriteLine($"City: {forecast.Name}, Temperature: {forecast.Main.Temp}°C");
        Console.WriteLine($"Weather: {forecast.Weather[0].Description}");
    }
}
else
{
    Console.WriteLine("Error fetching data from API.");
}



public class Forecast
{
    [JsonPropertyName("coord")]
    public Coord Coord { get; set; }

    [JsonPropertyName("weather")]
    public Weather[] Weather { get; set; }

    [JsonPropertyName("base")]
    public string Base { get; set; }

    [JsonPropertyName("main")]
    public Main Main { get; set; }

    [JsonPropertyName("visibility")]
    public int Visibility { get; set; }

    [JsonPropertyName("wind")]
    public Wind Wind { get; set; }

    [JsonPropertyName("clouds")]
    public Clouds Clouds { get; set; }

    [JsonPropertyName("dt")]
    public int Dt { get; set; }

    [JsonPropertyName("sys")]
    public Sys Sys { get; set; }

    [JsonPropertyName("timezone")]
    public int Timezone { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("cod")]
    public int Cod { get; set; }
}

public class Coord
{
    [JsonPropertyName("lon")]
    public double Lon { get; set; }

    [JsonPropertyName("lat")]
    public double Lat { get; set; }
}

public class Weather
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("main")]
    public string Main { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }
}

public class Main
{
    [JsonPropertyName("temp")]
    public double Temp { get; set; }

    [JsonPropertyName("feels_like")]
    public double FeelsLike { get; set; }

    [JsonPropertyName("temp_min")]
    public double TempMin { get; set; }

    [JsonPropertyName("temp_max")]
    public double TempMax { get; set; }

    [JsonPropertyName("pressure")]
    public int Pressure { get; set; }

    [JsonPropertyName("humidity")]
    public int Humidity { get; set; }

    [JsonPropertyName("sea_level")]
    public int SeaLevel { get; set; }

    [JsonPropertyName("grnd_level")]
    public int GrndLevel { get; set; }
}

public class Wind
{
    [JsonPropertyName("speed")]
    public double Speed { get; set; }

    [JsonPropertyName("deg")]
    public int Deg { get; set; }

    [JsonPropertyName("gust")]
    public double Gust { get; set; }
}

public class Clouds
{
    [JsonPropertyName("all")]
    public int All { get; set; }
}

public class Sys
{
    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("sunrise")]
    public int Sunrise { get; set; }

    [JsonPropertyName("sunset")]
    public int Sunset { get; set; }
}
*/
#endregion

#region NewtonsoftJsonExample

/*

var people = new List<Person>
{
    new Person { Name = "Elvin", Surname = "Azimov", Age = 23 },
    new Person { Name = "John", Surname = "Doe", Age = 30 }
};

var group = new Group
{
    Name = "Group A",
    Students = people.Select(p => new Student
    {
        Name = p.Name,
        Surname = p.Surname,
        Age = p.Age,
        Marks = new List<Mark>
        {
            new Mark { Subject = new Subject { Name = "Math" }, Value = 90 },
            new Mark { Subject = new Subject { Name = "Science" }, Value = 85 }
        }
    }).ToList()
};

var jsonOptions = new JsonSerializerSettings
{
    Formatting = Formatting.Indented
};

var json = JsonConvert.SerializeObject(group, jsonOptions);

using var fs = new FileStream("group.json", FileMode.Open);
using StreamWriter sw = new(fs);

sw.Write(json);


class Student : Person
{
    public List<Mark> Marks { get; set; } = new();
}

class Group
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; }
    public List<Student> Students { get; set; } = new();
}
class Mark
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Subject Subject { get; set; }
    public int Value { get; set; }
}

class Subject
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; }
}

class Person
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
}
*/

#endregion



