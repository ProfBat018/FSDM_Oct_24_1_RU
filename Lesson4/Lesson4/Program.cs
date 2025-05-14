#region StringvsStringBuilder

// using System.Text;

/*
using System.Text;

string name = "Elvin";

// name[0] = 'A';

// name = name.ToUpper();
//
// Console.WriteLine(name);
//
// People students = new();
//
// students[0].Name = "Samir";


StringBuilder sb = new(8, 10);

Console.WriteLine(sb.Capacity);

sb.Append("Elvin");
Console.WriteLine(sb.Capacity);

sb.Append("Azimov");
Console.WriteLine(sb.Capacity);

Console.WriteLine(sb.ToString());


class People
{
    private Person[] people;

    public People()
    {
        people = new Person[2]
        {
            new()
            {
                Name = "Elvin",
                SurName = "Azimov",
                Age = 23
            },
            new()
            {
                Name = "Sahib",
                SurName = "Quliyev",
                Age = 25
            }
        };
    }

    public Person[] GetAllPeople()
    {
        return people;
    }

    public Person this[int index]
    {
        get => people[index];
    }

}


class Person
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public int Age { get; set; }
    public bool IsEdited { get; set; }
}
*/

#endregion

#region StaticConstructor

/*
var a = new MyClass();

class MyClass
{
    public static int a = 20;
    public static int b = a * 10 / 2;
    public int c = 30;

    static MyClass()
    {
        Console.WriteLine("Called static");
    }

    public MyClass()
    {
        Console.WriteLine("Called constructor");
    }
}

*/

/*
using static Lesson4.Statics.A;

foo();


namespace Lesson4.Statics
{
    class A
    {
        public static void foo()
        {
            Console.WriteLine("Hello from A");
        }
    }
}
*/

#endregion

#region Overloading

// class MyClass
// {
//     public static bool operator >(MyClass a, MyClass b)
//     {
//         return true;
//     }
//     
//     public static bool operator <(MyClass a)
//     {
//         return true;
//     }
// }

/*
using System;
using System.Data.SqlTypes;
using System.Globalization;

Temperature c = 36d;

if (c)
{
    Console.WriteLine("Aloha");
}

class Temperature
{
    public double Celsius { get; }

    public Temperature(double celsius)
    {
        Celsius = celsius;
    }

    // Явное преобразование: Temperature → double
    public static explicit operator double(Temperature t)
    {
        return t.Celsius;
    }

    public static explicit operator int(Temperature t)
    {
        return (int)t.Celsius;
    }

    public static bool operator true(Temperature c)
    {

        if (c.Celsius > 25)
        {
            Console.WriteLine("It's hot");
        }
        else
        {
            Console.WriteLine("It's cold");
        }
        return c.Celsius > 25;
    }
    public static bool operator false(Temperature c)
    {

        if (c.Celsius > 25)
        {
            Console.WriteLine("It's hot");
        }
        else
        {
            Console.WriteLine("It's cold");
        }
        return c.Celsius > 25;
    }
    // Неявное преобразование: double → Temperature
    public static implicit operator Temperature(double celsius)
    {
        return new Temperature(celsius);
    }
    
    

    public override string ToString() => $"{Celsius}°C";
}

// class Program
// {
//     static void Main()
//     {
//         Temperature temp = 36.6; // implicit: double → Temperature
//         Console.WriteLine(temp); // 36.6°C
//
//         double value = (double)temp; // explicit: Temperature → double
//         Console.WriteLine(value);    // 36.6
//
//         double value2 = 45d;
//
//         Temperature temp2 = value;
//     }
// }

*/
#endregion

#region Tuple

/*
using System.Net.Mime;
using Lesson4;

Tuple<int, int, int, int> t = new(1, 2, 3, 4);

Console.WriteLine(t);

#endregion

A aObj = new();

*/

#endregion



