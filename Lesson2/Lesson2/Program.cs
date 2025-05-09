#region Part1

/*


// bool findEven(int number) => number % 2 == 0; // стрелочная функция
// void sum(int a, int b) => Console.WriteLine(a + b);

var a = new Person();



class Person
{
    private int _age;
    public string Name { get; set; }


    public int Age
    {
        get => _age == 18 ? _age : 0;
        set
        {
            if (value <= 18)
            {
                throw new Exception("Age must be more than 18");
            }
            _age = value;
        }
    }


}
*/

#endregion

#region Part2
/*
 
// var - это анонимный тип как auto в С++ 
// new - создает объект, а не выделяет место в Heap

// Car car = new Car(); // 1 способ
// var car = new Car(); // 2 способ
// Car car = new(); // 3 способ


// Car car = new()
// {
//     VIN = "dfgsdfgsdfg"
// };

// Car car = new("dfgdfg");

Car car = new()
{
    Make = "Mercedes",
    Model = "CLS"
};

Console.WriteLine(Car.a);

class Car
{
    public string Make { get; set; }

    public string Model { get; set; }
    // public string VIN { get; private set; }
    // public string VIN { get; init; }

    public Car() { }

    public Car(string vin)
    {
        this.vin = vin;
    }

    public readonly string vin;

    public const int a = 12;
}
*/
#endregion

#region Part3

// var a = new Person("Elvin", 23);
//
// public class Person(string name, int age)
// {
//     public string Name { get; set; } = name;
//     public int Age { get; set; } = age;
// }

#endregion

#region Part4
/*
var a = new MyStruct();
var b = default(MyStruct);

Console.WriteLine(a.num);
Console.WriteLine(b.num);

struct MyStruct
{
    public int num = 5;

    public MyStruct()
    {
        
    }
}
*/
#endregion

#region Part5

// abstract class MyClass
// {
//     public abstract void test();
//
//     public virtual void test2()
//     {
//         
//     }
// }

// class Test : MyClass
// {
//     public override void test()
//     {
//         throw new NotImplementedException();
//     }
// }

// abstract class MyClass
// {
//     public abstract string Name { get; set; }
//     public virtual string SurName { get; set; }
// }




#endregion

#region Part6
/*
var a = new A();

public class A
{
    public B bObj;
    public struct B
    {
        
    }
}
*/

#endregion

#region Part7
/*
void sumOfTwo(int num1, int num2, ref int sum)
{
    sum = num1 + num2;
}

int result = 0;

Console.WriteLine("Enter first number: ");
int num1 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter second number: ");
int num2 = Convert.ToInt32(Console.ReadLine());

sumOfTwo(num1, num2, ref result);

Console.WriteLine(result);
*/


// void sumOfTwo(int num1, int num2, out int sum)
// {
//     sum = num1 + num2;
// }
//
// int result;
//
// Console.WriteLine("Enter first number: ");
// int num1 = Convert.ToInt32(Console.ReadLine());
//
// Console.WriteLine("Enter second number: ");
// int num2 = Convert.ToInt32(Console.ReadLine());
//
// sumOfTwo(num1, num2, out result);
//
// Console.WriteLine(result);
#endregion

#region Part8

// Variant1
// int number1 = Int32.Parse(Console.ReadLine());

// Variant2 
// int number1 = Convert.ToInt32(Console.ReadLine());

// Variant3
//
// int number1;
// bool res = Int32.TryParse(Console.ReadLine(), out number1);
//
// if (true)
// {
//     Console.WriteLine(number1);
// }
//
// Console.WriteLine(number1);

#endregion