/*
var nums = new List<int>()
{
    1, 2, 3, 4, 5, 6, 7, 8, 9, 10
};


// Extensions functions
string name = "John";

name.Test(); // StringExtensions.Test(name);
name.Test2(5);

static class StringExtensions
{
    public static void Test(this string str)
    {
        Console.WriteLine($"Hello {str}");
    }
    public static void Test2(this string str, int a)
    {
        Console.WriteLine($"Hello {str}");
    }
}
*/

/*
List<Person> people = new()
{
    new() { Name = "John", Surname = "Doe", Age = 30 },
    new() { Name = "Jane", Surname = "Doe", Age = 25 },
    new() { Name = "Alice", Surname = "Smith", Age = 25 },
    new() { Name = "Bob", Surname = "Johnson", Age = 30 }
};

List<Person> students = new()
{
    new() { Name = "Charlie", Surname = "Brown", Age = 25 },
    new() { Name = "David", Surname = "Williams", Age = 22 }
};

var res1 = people
    .Where(p => p.Age > 25)
    .Select(p => p.Name);


var res2 = people
    .GroupBy(p => p.Age);

// foreach (var group in res2)
// {
//     Console.WriteLine($"Age: {group.Key}");
//     foreach (var person in group)
//     {
//         Console.WriteLine($"  Name: {person.Name}, Surname: {person.Surname}");
//     }
// }


var res3 = people.Join(students, person => person.Age, student => student.Age, (p, s) => new
{
    PersonName = p.Name,
    StudentName = s.Name
}).ToList();

foreach (var person in res3)
{
    Console.WriteLine($"Person: {person.PersonName}, Student: {person.StudentName}");
}


*/

List<Person> people = new()
{
    new() { Name = "John", Surname = "Doe", Age = 30 },
    new() { Name = "Jane", Surname = "Doe", Age = 25 },
    new() { Name = "Alice", Surname = "Smith", Age = 25 },
    new() { Name = "Bob", Surname = "Johnson", Age = 30 }
};

var res4 = people.Where(p => p.Age > 25)
                 .Select(p => new { FirstName = p.Name, LastName = p.Surname });

foreach (var obj in res4)
{
    Console.WriteLine(obj.FirstName, obj.LastName);
}

var a = new { FirstName = "John", LastName = "Doe" };


foo(new {FirstName = "John", LastName = "Doe"});
void foo(object a)
{
    Console.WriteLine(a);
}

class Person
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; } 
}


// https://www.tutorialsteacher.com/linq/linq-joining-operator-join

