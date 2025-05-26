# Тема урока: Делегаты

**Делегаты в C#** — это типы, которые представляют ссылки на методы с определенной сигнатурой. Делегаты позволяют передавать методы как параметры, что делает код более гибким и расширяемым. Мы присваем его к категории `User defined types` (пользовательские типы). Он как и классы и интерфейсы является ссылочным типом, поэтому при передаче делегата в метод, передается ссылка на него, а не его копия.

### Синтаксис объявления делегата

```csharp
public delegate void MyDelegate(string message);

public delegate int Calculate(int a, int b);
```

Для начала вы пишите ключевое слово `delegate`, затем указываете возвращаемый тип и имя делегата, а в скобках — параметры, которые он принимает.

### Встроенные делегаты

В С# по умолчанию есть 3 встроенных делегата:

- `Action` — представляет метод, который не возвращает значение и может принимать параметры.
- `Func` — представляет метод, который возвращает значение и может принимать параметры.
- `Predicate` — представляет метод, который возвращает логическое значение и принимает один параметр.

### In & Out параметры

В С# вы можете посылать в Generic(обобщения или template bp C++) входные и выходные параметры. Это делается с помощью ключевых слов `in` и `out`.

```csharp

string aFoo(int num)
{
    return num.ToString();
}

MyDelegate<int, string> a = aFoo;

public delegate T2 MyDelegate<in T1, out T2>(T1 a);

```

### Ковариантность и контравариантность

Ковариантность и контравариантность позволяют использовать делегаты с более широкими или узкими типами, чем те, которые указаны в их сигнатуре. На самом деле это та тема которую можно не объяснять, так как ее можно понять и по логике. Но все же я опишу ее.

- **Ковариантность** позволяет использовать делегат с типом, который является производным от указанного в сигнатуре. Это означает, что если делегат возвращает тип `Base`, то его можно использовать с типом `Derived`, который наследуется от `Base`.

- **Контравариантность** позволяет использовать делегат с типом, который является базовым для указанного в сигнатуре. Это означает, что если делегат принимает параметр типа `Base`, то его можно использовать с типом `Derived`, который наследуется от `Base`.

Пример ковариантности:

```csharp

public class Transport
{
    public virtual void Show() => Console.WriteLine("Base");
}
public class Car : Transport
{
    public override void Show() => Console.WriteLine("Derived");
}

public delegate Transport MyDelegate();

public Transport GetBase()
{
    return new Transport();
}

public Car GetDerived()
{
    return new Car();
}

public void TestCovariance()
{
    MyDelegate del = GetBase; // Используем метод, возвращающий Base
    Transport b = del(); // Возвращает Base

    del = GetDerived; // Используем метод, возвращающий Derived
    b = del(); // Возвращает Derived, но делегат все еще типа Base
}
```

Пример контравариантности:

```csharp
public class Animal
{
    public virtual void Speak() => Console.WriteLine("Animal speaks");
}
public class Dog : Animal
{
    public override void Speak() => Console.WriteLine("Dog barks");
}

public delegate void AnimalDelegate(Animal animal);

public void ProcessAnimal(Animal animal)
{
    animal.Speak();
}

public void ProcessDog(Dog dog)
{
    dog.Speak();
}

public void TestContravariance()
{
    AnimalDelegate del = ProcessAnimal; // Используем метод, принимающий Animal
    del(new Animal()); // Вызывает Speak для Animal

    del = ProcessDog; // Используем метод, принимающий Dog
    del(new Dog()); // Вызывает Speak для Dog, но делегат все еще типа Animal
}
```

### Мультикастовые делегаты

Мультикастовые делегаты позволяют вызывать несколько методов одновременно. Это достигается путем добавления методов к делегату с помощью оператора `+=`. При вызове мультикастового делегата будут выполнены все методы, которые были добавлены к нему.
Давайте рассмотрим это на примере небольшой программы для вычисления суммы налогов который должен заплатить человек.

```csharp
using System;




    public void CalculateFederalTax(decimal income)
    {
        decimal federalTax = income * 0.15m; // 15% федеральный налог
        Console.WriteLine($"Federal Tax: {federalTax:C}");
    }

    public void CalculateStateTax(decimal income)
    {
        decimal stateTax = income * 0.05m; // 5% государственный налог
        Console.WriteLine($"State Tax: {stateTax:C}");
    }

public delegate void TaxDelegate(decimal income);



```
