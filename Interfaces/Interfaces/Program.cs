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

#endregion
