#region Exceptions

/*


using Lesson5;

var service = new TestService(new SecondTestService());

try
{
    service.Foo();
    return 404;
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine(e.StackTrace);
    return 404;
}
finally
{
    Console.WriteLine("Doing some cleanup work...");
}
*/

#endregion

#region CheckedUnchecked

// var a = Int32.MaxValue;
//
// checked
// {
//     int c = a + 1;
// }


// var a = Int32.MaxValue;
//
// int c = checked(a + 1);

// var a = Int32.MaxValue;
//
// int c = a + 1;


// Console.WriteLine(c);


#endregion

#region IDisposable

/*

using MyClass a = new();

Console.WriteLine("End of program...");

class MyClass : IDisposable
{
    public void Dispose()
    {
       this.Close();
    }

    void Close()
    {
        Console.WriteLine("Closing resources...");   
    }
}
*/

#endregion

/*
using Generic = System.Collections.Generic; // Alias 

Generic.List<int> nums = new() { 1, 2, 3 };

List<int> a = new();

class List<T>
{
    
}

*/

#region Enums

var color = COLOR.RED;

Console.WriteLine(color.ToString());

int colorValue = (int)color;
Console.WriteLine(colorValue);

enum COLOR
{
    RED,
    GREEN,
    BLUE
}



#endregion
