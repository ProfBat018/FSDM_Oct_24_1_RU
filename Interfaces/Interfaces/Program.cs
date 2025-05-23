#region IComparable 

/*
 


List<IEntity> entities = new List<IEntity>
{
    new Person { Name = "Alice", Age = 30 },
    new Animal { Name = "Dog", Age = 5 },
    new Person { Name = "Bob", Age = 25 },
    new Animal { Name = "Cat", Age = 3 }
};

List<Person> people = new List<Person>
{
    new Person { Name = "Alice", Age = 30 },
    new Person { Name = "Abdulla", Age = 30 },
    new Person { Name = "Charlie", Age = 35 }
};

people.Sort();

foreach (var person in people)
{
    Console.WriteLine($"{person.Name} - {person.Age}");
}
// entities.Sort();

// foreach (var entity in entities)
// {
//     Console.WriteLine($"{entity.Name} - {entity.Age}");
// }


interface IEntity: IComparable<IEntity>
{
    public string Name { get; set; }
    public int Age { get; set; }
    
    int IComparable<IEntity>.CompareTo(IEntity? other)
    {
        if (other == null) return 1;

        return this.Age.CompareTo(other.Age);
    }
}


class Animal : IEntity
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Person : IEntity
{
    public string Name { get; set; }
    public int Age { get; set; }
  
    int IComparable<IEntity>.CompareTo(IEntity? other)
    {
        if (other == null) return 1;
        
        int nameComparison = string.Compare(this.Name, other.Name, StringComparison.Ordinal);
        if (nameComparison != 0)
            return nameComparison;

        return this.Age.CompareTo(other.Age);
    }
}


// List<Person> people = new List<Person>
// {
//     new Person { Name = "Alice", Age = 30 },
//     new Person { Name = "Bob", Age = 25 },
//     new Person { Name = "Charlie", Age = 35 }
// };
//
// people.Sort(); // Сортировка по возрасту

// class Person : IComparable<Person>
// {
//     public string Name { get; set; }
//     public int Age { get; set; }
//
//     public int CompareTo(Person? obj)
//     {
//         if (obj == null) return 1;
//
//         return this.Age.CompareTo(obj.Age);
//         // Если возраст больше, то вернется положительное число 
//         // Если возраст меньше, то вернется отрицательное число
//         // Если равны, то вернется 0
//     }
// }

// class Person : IComparable
// {
//     public string Name { get; set; }
//     public int Age { get; set; }
//     
//     public int CompareTo(object? obj)
//     {
//         if (obj == null) return 1;
//
//         Person? otherPerson = obj as Person;
//         if (otherPerson != null)
//         {
//             return this.Age.CompareTo(otherPerson.Age);
//         }
//         else
//         {
//             throw new ArgumentException("Object is not a Person");
//         }
//     }
// }

*/

#endregion

#region IEnumerable

/*
using System.Collections;

// 1 
// People people = new People(new List<Person>
// {
//     new Person { Name = "Alice", Age = 30 },
//     new Person { Name = "Bob", Age = 25 },
//     new Person { Name = "Charlie", Age = 35 }
// });


// 2
People people = new People([

    new Person { Name = "Alice", Age = 30 },
    new Person { Name = "Bob", Age = 25 },
    new Person { Name = "Charlie", Age = 35 }
]);

foreach (var person in people)
{
    Console.WriteLine(person);
}

class People : IEnumerable<Person>
{
    private List<Person> _people;

    public People(IEnumerable<Person> people)
    {
        _people = new List<Person>(people);
    }

    public IEnumerator<Person> GetEnumerator()
    {
        foreach (var person in _people)
        {
            yield return person;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
class Person
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public int Age { get; set; }

    public override string ToString()
    {
        return $"ID: {Id}\n\tName: {Name},\tAge: {Age}";
    }
}
*/

#endregion


// SortedList vs SortedDictionary 

// SortedList<string, string> people = new();
//
//
// people.Add("Alice", "30");
// people.Add("Bob", "25");
// people.Add("Charlie", "35");
// people.Add("Charlie", "35");
//
// foreach (var person in people)
// {
//     Console.WriteLine($"{person.Key} - {person.Value}");
// }


// SortedDictionary<string, string> people = new();
// people.Add("Alice", "30");
// people.Add("Bob", "25");
// people.Add("Charlie", "35");
// people.Add("Charlie", "35");
//
// foreach (var person in people)
// {
//     Console.WriteLine($"{person.Key} - {person.Value}");
// }


#region ICloneable


/*
Person a = new()
{
    Name = "Elvin",
    SurName = "Azimov"
};


// Person b = new()
// {
//     Name = a.Name,
//     SurName = a.SurName
// };

Person c = a.Clone();

a.Name = "Samir";


class Person
{
    public string Name { get; set; }
    public string SurName { get; set; }
    
    public Person Clone()
    {
        return new ()
        {
            Name = this.Name,
            SurName = this.SurName
        };
    }

    public override string ToString()
    {
        return $"{Name}\t{SurName}";
    }
}




Person a = new()
{
    Name = "Elvin",
    SurName = "Azimov"
};

Person b = (Person)a.Clone();
Person? c = a.Clone() as Person;




class Person : ICloneable
{
    public string Name { get; set; }
    public string SurName { get; set; }
    

    public override string ToString()
    {
        return $"{Name}\t{SurName}";
    }

    public object Clone()
    {
        return new Person
        {
            Name = this.Name,
            SurName = this.SurName
        };
    }
}
*/

//
// Pc a = new()
// {
//     Name = "My PC",
//     Components = new List<PcComponent>
//     {
//         new Cpu
//         {
//             Name = "Intel Core i7",
//             Description = "High performance CPU",
//             Socket = "LGA 1151",
//             Cores = 8,
//             Threads = 16,
//             BaseClock = 3.6,
//             BoostClock = 4.9
//         },
//         new Gpu
//         {
//             Name = "NVIDIA GeForce RTX 3080",
//             Description = "High performance GPU",
//             MemoryType = "GDDR6X",
//             MemorySize = 10,
//             CudaCores = 8704,
//             BaseClock = 1440,
//             BoostClock = 1710
//         },
//         new Motherboard
//         {
//             Name = "ASUS ROG Strix Z490-E",
//             Description = "High performance motherboard",
//             Socket = "LGA 1200",
//             RamSlots = 4,
//             MaxRam = 128,
//             FormFactor = "ATX"
//         }
//     }
// };
// Pc b = a.Clone() as Pc;
//
// b.Name = "My PC Clone";
// b.Components[1].Name = "NVIDIA GeForce RTX 3090";
// Console.WriteLine(a);
// Console.WriteLine(b);
//
// class Pc : ICloneable
// {
//     public Guid Id { get; set; } = Guid.NewGuid();
//     public string Name { get; set; }
//     public List<PcComponent> Components { get; set; }
//     public object Clone()
//     {
//         var clonedComponents =  new List<PcComponent>();
//
//         foreach (var component in Components)
//         {
//             clonedComponents.Add(component.Clone() as PcComponent);
//         }
//
//         return new Pc()
//         {
//             Id = Guid.NewGuid(),
//             Name = this.Name,
//             Components = clonedComponents
//         };
//     }
//
//     public override string ToString()
//     {
//         return $"ID: {Id}\n\tName: {Name}\n\tComponents: {string.Join(", ", Components.Select(c => c.Name))}";
//     }
// }
//
// class PcComponent : ICloneable
// {
//     public Guid Id { get; set; }
//     public string Name { get; set; }
//     public string Description { get; set; }
//     public object Clone()
//     {
//         return new PcComponent
//         {
//             Id = Guid.NewGuid(),
//             Name = this.Name,
//             Description = this.Description
//         };
//     }
// }
//
// class Cpu : PcComponent, ICloneable
// {
//     public string Socket { get; set; }
//     public int Cores { get; set; }
//     public int Threads { get; set; }
//     public double BaseClock { get; set; }
//     public double BoostClock { get; set; }
//     
//     public object Clone()
//     {
//         return new Cpu
//         {
//             Id = Guid.NewGuid(),
//             Name = this.Name,
//             Description = this.Description,
//             Socket = this.Socket,
//             Cores = this.Cores,
//             Threads = this.Threads,
//             BaseClock = this.BaseClock,
//             BoostClock = this.BoostClock
//         };
//     }
// }
//
// class Gpu : PcComponent, ICloneable
// {
//     public string MemoryType { get; set; }
//     public int MemorySize { get; set; }
//     public int CudaCores { get; set; }
//     public double BaseClock { get; set; }
//     public double BoostClock { get; set; }
//     
//     public object Clone()
//     {
//         return new Gpu
//         {
//             Id = Guid.NewGuid(),
//             Name = this.Name,
//             Description = this.Description,
//             MemoryType = this.MemoryType,
//             MemorySize = this.MemorySize,
//             CudaCores = this.CudaCores,
//             BaseClock = this.BaseClock,
//             BoostClock = this.BoostClock
//         };
//     }
// }
//
// class Motherboard : PcComponent, ICloneable
// {
//     public string Socket { get; set; }
//     public int RamSlots { get; set; }
//     public int MaxRam { get; set; }
//     public string FormFactor { get; set; }
//     
//     public object Clone()
//     {
//         return new Motherboard
//         {
//             Id = Guid.NewGuid(),
//             Name = this.Name,
//             Description = this.Description,
//             Socket = this.Socket,
//             RamSlots = this.RamSlots,
//             MaxRam = this.MaxRam,
//             FormFactor = this.FormFactor
//         };
//     }
// }

#endregion
#region IEquatable
/*
// class Person
// {
//     public override bool Equals(object? obj)
//     {
//         return base.Equals(obj);
//     }
// }


using System.Security.AccessControl;

Person a = new()
{
    Name = "Elvin",
    Age = 23
};

Person b = new()
{
    Name = "Elvin",
    Age = 23
};

Console.WriteLine(a == b);
Console.WriteLine(a.Equals(b));

class Person : IEquatable<Person>, IEquatable<int>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public bool Equals(Person? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name == other.Name && Age == other.Age;
    }

    public bool Equals(int other)
    {
        if (other == 0) return false;
        return Age == other;
    }
    
    public static bool operator == (Person a, Person b)
    {
        if (a is null && b is null) return true;
        if (a is null || b is null) return false;
        return a.Equals(b);
    }

    public static bool operator !=(Person a, Person b)
    {
        return !(a == b);
    }
}

*/
#endregion

