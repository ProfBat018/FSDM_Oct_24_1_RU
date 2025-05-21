#region Finalizer




// Person a = new();
// Console.WriteLine(a.Name);
//
//
// class Person
// {
//     public string Name { get; set; }
//
//     public Person()
//     {
//         Console.WriteLine("Constructor called");
//         Name = "Elvin";
//     }
//     
//     ~Person() // Finalizer 
//     {
//         Console.WriteLine("Finalizer called");
//     }
// }

// class MyClass
// {
//
//     void Close()
//     {
//         Console.WriteLine("Closing...");
//     }
//
//     public void Dispose()
//     {
//         this.Close();
//     }
// }


#endregion

#region Using


/*
Console.WriteLine("Start of main...");


{
     using FileStream fs = new("test.txt", FileMode.Open);
     using StreamReader sr = new(fs);
     

    Console.WriteLine(sr.ReadToEnd());

    Console.WriteLine("End of using block");

}

Console.WriteLine("End of main...");
*/

#endregion

#region AccessModifiers

/*
using Lesson6.Data;

GermanCar a = new();

Console.WriteLine(a);

class GermanCar : Car
{
    public GermanCar()
    {
        VIN = "123456789";
        Make = "BMW";
    }
}


class A
{


    class B
    {
        
    }
}

*/
#endregion

#region СокрытиеИмен

/*
BaseClass a = new();
DerivedClass b = new();
BaseClass c = new DerivedClass();

a.Show();
b.Show();
c.Show();

class BaseClass
{
    public void Show() => Console.WriteLine("BaseClass.Show");
}

class DerivedClass : BaseClass
{
    public new void Show() => Console.WriteLine("DerivedClass.Show");
}
*/
#endregion

#region Abstract


/*
abstract class Shape
{
    public abstract double GetArea();
    public abstract string ShapeName { get; set; }
    
    public virtual void Show()
    {
        Console.WriteLine($"Shape: {ShapeName}, Area: {GetArea()}");
    }
}

class Circle : Shape
{
    public double Radius { get; set; }

    public override double GetArea() => Math.PI * Radius * Radius;
    public override string ShapeName { get; set; }
}
*/
#endregion

#region Interfaces

IShape a = new Circle { Radius = 5, ShapeName = "Circle" }; // interface reference
IShape b = new Rectangle { Width = 4, Height = 5, ShapeName = "Rectangle" };


interface IShape
{
    double GetArea();
    string ShapeName { get; set; }
}

class Circle : IShape
{
    public double Radius { get; set; }

    public double GetArea() => Math.PI * Radius * Radius;
    public string ShapeName { get; set; }
}

class Rectangle : IShape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public double GetArea() => Width * Height;
    public string ShapeName { get; set; }
}

#endregion

