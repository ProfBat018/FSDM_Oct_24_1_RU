#region BaseDifference
/*
Person p1 = new()
{
    Name = "John",
    Surname = "Doe"
};

Person p2 = new()
{
    Name = "John",
    Surname = "Doe"
};

Car c1 = new()
{
    Make = "Toyota",
    Model = "Corolla"
};

Car c2 = new()
{
    Make = "Toyota",
    Model = "Corolla"
};

Console.WriteLine(p1 == p2);
Console.WriteLine(c1 == c2);


public record Person
{
    public string Name;
    public string Surname;
}

public class Car
{
    public string Make;
    public string Model;
}
*/
#endregion

#region ShortDeclaration
/*
Person p1 = new("John", "Doe");
Person p2 = new("John", "Doe");

Car c1 = new("Toyota", "Corolla");
Car c2 = new("Toyota", "Corolla");

public record Person(string Name, string Surname);
public class Car(string Make, string Model);
*/

#endregion

#region InitDeclaration
/*
var p1 = new Person
{
    Name = "John",
    Age = 30
};


public record Person
{
    public string Name { get; init; }
    public int Age { get; init; }
}

*/

#endregion

#region ConstructorPropertyDeclaration

// var p1 = new Person("John", 30);
// public record Person(string Name, int Age)
// {
//     // тут должна быть логтика инициализации
//     public string Name { get; init; } = Name;
//     public int Age { get; init; } = Age;
// }

#endregion

#region Immutability

// var p1 = new Person("John", 30);
//
// p1.Name = "Jane"; // Ошибка компиляции, свойство Name только для чтения
//
// record Person(string Name, int Age);
/*
Person p1 = new()
{
    Name = "John",
    Age = 30
};

p1.Name = "Jane";


record Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
*/
#endregion

#region GetHashCode
/*
var p1 = new Person("John", 30);
var p2 = new Person("John", 30);

Console.WriteLine(p1.GetHashCode() == p2.GetHashCode());

var c1 = new Car("Toyota", "Corolla");
var c2 = new Car("Toyota", "Corolla");

Console.WriteLine(c1.GetHashCode() == c2.GetHashCode());

record Person(string Name, int Age);
class Car (string Make, string Model);
*/
#endregion

//
// Person p1 = new("John", "Doe", new Car { Make = "Toyota", Model = "Corolla" });
// Person p2 = new("John", "Doe", new Car { Make = "Toyota", Model = "Corolla" });
//
// Console.WriteLine(p1 == p2); 
//
// record Person(string Name, string Surname, Car Car);
//
// class Car
// {
//     public string Make { get; set; }
//     public string Model { get; set; }
// }