#region Action

/*

Action<string> printAction = printMessage;
Action? fooAction = null;




void printMessage(string message)
{
    Console.WriteLine(message);
}

void foo()
{
    Console.WriteLine("Foo");
}

*/
#endregion

#region Predicate
/*
bool isEven(int number)
{
    return number % 2 == 0;
}

Predicate<int> isEvenPredicate = isEven;

Predicate<int> isEvenLambda = (num) => num % 2 == 0; // Lambda expression

Action actionLambda = () => Console.WriteLine("Aloha");
*/
#endregion

#region Func

/*
Func<int, int, bool> isGreaterThan = (x, y) => x > y;
Func<int> getRandomNumber = () => new Random().Next(1, 100);

Predicate<int> test;
Func<int, bool> test2;

List<int> nums = new();

*/

#endregion

#region CustomDelegateExample

/*
List<int> nums = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
Console.WriteLine(nums.Sum((x) => x));


Employee a = new("Elvin", 5000, new()
{
    (salary) => (salary * 0.2f),
    (salary) => 84f,
    (salary) => 20f
});

Console.WriteLine(a.CalculateAllTaxes());

Employee b = new("Sahib", 2500);

*/




#endregion

#region MulticastDelegates

TaxDelegate taxes = CalculateFederalTax;
taxes += CalculateStateTax;
taxes -= CalculateStateTax;

taxes(2000m);

 void CalculateFederalTax(decimal income)
{
    decimal federalTax = income * 0.15m; // 15% федеральный налог
    Console.WriteLine($"Federal Tax: {federalTax:C}");
}

 void CalculateStateTax(decimal income)
{
    decimal stateTax = income * 0.05m; // 5% государственный налог
    Console.WriteLine($"State Tax: {stateTax:C}");
}

public delegate void TaxDelegate(decimal income);


#endregion