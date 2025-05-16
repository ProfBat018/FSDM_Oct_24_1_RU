# Тема урока: 
- String class 
- String vs StringBuilder
- class syntax 
- - constructors
- - methods
- - properties
- - indexers
- - operator overloading
- endless arguments
- tuple 
- partial types 


## String class

В `C#` строка - это такой же массив как и в С++. Вы уже реализовывали что-то  на подобии этого в `C++`. У каждой строки есть свой Length. Дело в том, что самое главное что вам нужно знать про строку = это то, что она неизменяемая. 


## String vs StringBuilder

`String` - это неизменяемый тип данных. Это значит, что когда вы создаете строку, вы не можете изменить ее содержимое. Например, если вы создаете строку "Hello", вы не можете изменить ее на "Hello World". Вместо этого, если вы хотите изменить строку, вам нужно создать новую строку с новым содержимым.

`StringBuilder` - это изменяемый тип данных. Это значит, что вы можете изменять содержимое строки без создания новой строки. Например, если вы создаете `StringBuilder` с содержимым "Hello", вы можете изменить его на "Hello World" без создания новой строки.
`StringBuilder` более эффективен, чем `String`, когда вы работаете с большими строками или когда вы часто изменяете строки. Например, если вы хотите создать строку с 1000 символов, использование `StringBuilder` будет более эффективным, чем использование `String`.

## class syntax 

```csharp

class ClassName
{
    // поля
    private int field1;
    private string field2;

    // конструктор
    public ClassName(int field1, string field2)
    {
        this.field1 = field1;
        this.field2 = field2;
    }

    // методы
    public void Method1()
    {
        Console.WriteLine("Method1");
    }

    public int Method2(int a, int b)
    {
        return a + b;
    }

    // свойства
    public int Property1 { get; set; }
    public string Property2 { get; set; }
    public string Property2 { get; init; } // инициализация только при создании объекта



    // индексатор
    public string this[int index]
    {
        get { return field2[index].ToString(); }
        set { field2 = field2.Remove(index, 1).Insert(index, value); }
    }

}
```

### Конструкторы

Конструктор - это специальный метод, который вызывается при создании объекта класса. Он используется для инициализации полей класса. Конструктор имеет то же имя, что и класс, и не имеет возвращаемого типа.

```csharp
class ClassName
{
    private int _field1;
    private string _field2;

    // конструктор
    public ClassName(int field1, string field2)
    {
        _field1 = field1;
        _field2 = field2;
    }
}
```

Для делегирования конструктора можно использовать `base`: 

```csharp
class Transport 
{
    public Transport(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}

class Car : Transport
{
    public Car(string name, string color) : base(name)
    {
        Color = color;
    }

    public string Color { get; set; }
}
```

также в C# есть статические конструкторы, которые вызываются при первом обращении к классу. Они не могут принимать параметры и не могут быть вызваны явно.

```csharp
class ClassName
{
    static ClassName()
    {
        // статический конструктор
        Console.WriteLine("Static constructor");
    }

    public ClassName()
    {
        // обычный конструктор
        Console.WriteLine("Constructor");
    }
}
```

```csharp


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

```



### Методы

Методы - это функции, которые определены внутри класса. Они могут принимать параметры и возвращать значения. Методы могут быть статическими или нестатическими. Статические методы принадлежат классу, а нестатические - объекту класса.

```csharp

class ClassName
{
    private int _field1;
    private string _field2;

    // конструктор
    public ClassName(int field1, string field2)
    {
        _field1 = field1;
        _field2 = field2;
    }

    // метод
    public void Method1()
    {
        Console.WriteLine("Method1");
    }

    // метод с параметрами
    public int Method2(int a, int b)
    {
        return a + b;
    }
}
```

## Перегрузка операторов


| Оператор         | Описание                        | Пример символа |
|------------------|----------------------------------|----------------|
| Unary Plus       | Унарный плюс                     | `+a`           |
| Unary Negation   | Унарный минус                    | `-a`           |
| Logical NOT      | Логическое отрицание             | `!a`           |
| Bitwise NOT      | Побитовая инверсия               | `~a`           |
| Increment        | Инкремент                        | `++a` / `a++`  |
| Decrement        | Декремент                        | `--a` / `a--`  |
| True             | Проверка истинности              | `if (a)`       |
| False            | Проверка ложности                | `if (!a)`      |
| Addition         | Сложение                         | `a + b`        |
| Subtraction      | Вычитание                        | `a - b`        |
| Multiplication   | Умножение                        | `a * b`        |
| Division         | Деление                          | `a / b`        |
| Modulus          | Остаток от деления               | `a % b`        |
| Bitwise AND      | Побитовая конъюнкция             | `a & b`        |
| Bitwise OR       | Побитовая дизъюнкция             | `a | b`        |
| Exclusive OR     | Побитовая исключающая дизъюнкция | `a ^ b`        |
| Left Shift       | Сдвиг влево                      | `a << b`       |
| Right Shift      | Сдвиг вправо                     | `a >> b`       |
| Equality         | Равенство                        | `a == b`       |
| Inequality       | Неравенство                      | `a != b`       |
| Greater Than     | Больше                           | `a > b`        |
| Less Than        | Меньше                           | `a < b`        |
| Greater or Equal | Больше или равно                 | `a >= b`       |
| Less or Equal    | Меньше или равно                 | `a <= b`       |
| Logical AND      | Логическое И (условный)          | `a && b`¹      |
| Logical OR       | Логическое ИЛИ (условный)        | `a || b`¹      |
| Indexing         | Индексация (с C# 6.0)            | `a[b]`         |
| Implicit         | Неявное приведение типа          | `implicit`     |
| Explicit         | Явное приведение типа            | `explicit`     |

¹ `&&` и `||` нельзя перегрузить напрямую, но перегружаются через `true` и `false`.

> ❗ Операторы **присваивания (`=`, `+=`, `-=`, и т.д.)** перегрузке не подлежат напрямую, но `+=` и подобные используют перегруженные `+`, `-` и т.д.

синтаксис перегрузки операторов:

```csharp 
public static ClassName operator +(ClassName a, ClassName b)
{
    return new ClassName(a._field1 + b._field1, a._field2 + b._field2);
}
```

## Endeless arguments

`params` - это специальный параметр, который позволяет передавать переменное количество аргументов в метод. Он должен быть последним параметром в списке параметров метода и может принимать массив любого типа.

```csharp
class ClassName
{
    public void Method1(params int[] numbers)
    {
        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ClassName obj = new ClassName();
        obj.Method1(1, 2, 3, 4, 5);
        obj.Method1(10, 20);
        obj.Method1(100);
    }
}
```

## Tuple

`Tuple` - это структура данных, которая позволяет хранить несколько значений разных типов в одной переменной. Она может содержать от 1 до 8 элементов. Каждый элемент может иметь свой тип данных.

```csharp 
var tuple = new Tuple<int, string>(1, "Hello");
Console.WriteLine(tuple.Item1); // 1
Console.WriteLine(tuple.Item2); // Hello
```
или 

```csharp
var tuple = (1, "Hello");
Console.WriteLine(tuple.Item1); // 1
Console.WriteLine(tuple.Item2); // Hello
```

## Partial types

Частичные типы - это возможность разделить определение класса, структуры или интерфейса на несколько файлов. Это позволяет организовать код более удобно и удобно работать с большими классами, так будет написано везде где вы будете читать про эти классы, но это не так. 

Обычно partial классы используются для отделения вашего кода от сгенерированного кода. К примеру при работе с `Entity Framework` или `WPF`.
Иногда сгенерированный самим `framework`-ом класс может называться так же как и ваш, потому что он является частью вашего проекта. В таких случаях используются `partial` классы. 





