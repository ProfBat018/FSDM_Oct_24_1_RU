#region Console

// using System.Text;
//
// string text = "a";
//         
// foreach (char symbol in text)
// {
//     int unicodeValue = Convert.ToInt32(symbol);
//     Console.WriteLine($"Unicode значение символа '{symbol}': {unicodeValue}");
// }

// Console.WriteLine(key);

// var key = Console.ReadKey();




// Console.ReadLine();

#endregion


#region CastingAndNullable

// для преобразования в строку ToString()

// класс Convert
// преобразование в int, то у нас есть Parse и TryParse

// У нас есть два типа преобразования
// 1. C style casting 
// 2. ключевое слово as 

// Для проверки типа можно использовать is 

// int intValue = 97;
// char res = (char)intValue;
// Console.WriteLine(res);

//
// using System.Collections;
//
// ArrayList nums = new() { 1, 2, "Elvin", false, 3.25f };
//
// int? num = nums[0] as int?;
//
// if (num is int)
// {
//     Console.WriteLine("Yes");
// }
//
// class Transport
// {
//     public string Make { get; set; }
//     public string Model { get; set; }
//
//     public override string ToString()
//     {
//         return $"{Make}\t{Model}";
//     }
// }
//
//
// class Car : Transport
// {
//     public string VIN { get; set; }
// }
//
// struct MyStruct
// {
//     
// }


// null conditional vs null coalescing operator 

// string name = null;

//// null coalescing operator
// string res = name ?? "Azimov";
// name ??= "Azimov";
//
// Console.WriteLine(name);

//// null conditional operator

// Console.WriteLine(name.Length);
//
// if (name != null)
// {
//     Console.WriteLine(name.Length);    
// }
//



#endregion

#region SwitchExpression

/*
void findColor(Color color)
{
    switch (color)
    {
        case Color.RED:
        {
            Console.WriteLine("RED");
            break;
        } 
        case Color.GREEN:
        {
            Console.WriteLine("GREEN");
            break;
        } 
        case Color.BLUE:
        {
            Console.WriteLine("BLUE");
            break;
        }
        default:
        {
            Console.WriteLine("Black");
            break;
        }
    }
}

void FindColor(Color color)
{
    string result = color switch
    {
        Color.RED => "RED",
        Color.GREEN => "GREEN",
        Color.BLUE => "BLUE",
        _ => "Black"
    };

    Console.WriteLine(result);
}

string FindColor2(Color color) => color switch
{
    Color.RED => "RED",
    Color.GREEN => "GREEN",
    Color.BLUE => "BLUE",
};

findColor(Color.RED);

enum Color
{
    RED = 1,
    GREEN = 2,
    BLUE = 3
}

*/

#endregion

#region NameoffAndArrays

// string name = "Elvin";
//
// Console.WriteLine(nameof(name));


// int[] arr = new int[4];
//
// foreach (var i in arr)
// {
//     Console.WriteLine(i);
// }

// int[][] arr = new int[][3]
// {
//     new[] { 1, 2, 3 },
//     new[] { 4, 5, 6 },
//     new[] { 7, 8, 9, 10 },
// };
//
// int[,] arr = new int[3, 3]
// {
//     { 1, 2, 3 },
//     { 4, 5, 6 },
//     { 7, 8, 9 },
// };

// int[][] arr = new int[][3]
// {
//     new[] { 1, 2 },
//     new[] { 4, 5, 6 },
//     new[] { 7, 8, 9, 10 },
// };
//
// for (int i = 0; i < arr.Length; i++)
// {
//     for (int j = 0; j < arr[i].Length; j++)
//     {
//         Console.WriteLine(arr[i][j]);
//     }
// }

// List<string> names = new() { "Elvin", "Sahib", "Aziz"};

#endregion