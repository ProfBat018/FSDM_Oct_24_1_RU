# Тема урока: Наследование

- Модификаторы доступа в C#
- Сокрытие имен при наследовании
- Полиморфизм
- Абстрактные классы и методы
- Интерфейсы

# Наследование

1. В C# нет множественного наследования, но есть возможность реализовать интерфейсы.
2. Все классы в C# наследуются от класса Object, который является базовым классом для всех классов в C#. Значимые типы наследуются от класса ValueType, который в свою очередь наследуется от класса Object.
3. Класс, от которого наследуются другие классы, называется базовым классом (или суперклассом), а класс, который наследует от него, называется производным классом (или подклассом).

## Модификаторы доступа

![](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/prlmzaidpn8pcv7j9gw8.png)

- `public`: Член доступен отовсюду, без ограничений.
- `protected`: Член доступен только в пределах своего класса и производных классов.
- `private`: Член доступен только в пределах своего класса.
- `internal`: Член доступен только в пределах текущей сборки (assembly).
- `protected internal`: Член доступен в пределах текущей сборки или из производных классов.
- `private protected`: Член доступен только в пределах своего класса и производных классов, находящихся в той же сборке.

- `file`: Член доступен только внутри текущего файла (добавлен в C# 11 для ограниченного использования, например, при определении file-scoped типов).

## Сокрытие имен при наследовании

Если производный класс определяет член с тем же именем, что и в базовом классе, то он скрывает базовый член. Для этого можно использовать ключевое слово `new`. Данное ключевое слово всего лишь убирает предупреждение компилятора о том, что базовый член скрыт. Данное ключевое слово не является обязательным, но рекомендуется его использовать для повышения читаемости кода. Мое личное мнение:
Не надо вообще писать два одинаковых названия методов, если же по какой-то очень важной причине вы хотите это сделать, то используйте `new`.

```csharp
class BaseClass
{
    public void Show() => Console.WriteLine("BaseClass.Show");
}

class DerivedClass : BaseClass
{
    public new void Show() => Console.WriteLine("DerivedClass.Show");
}
```

## Полиморфизм

Полиморфизм позволяет использовать один интерфейс для разных типов объектов. В C# это реализуется через виртуальные и переопределяемые методы, а также через интерфейсы.

```csharp
class Animal
{
    public virtual void Speak() => Console.WriteLine("Animal speaks");
}

class Dog : Animal
{
    public override void Bark() => Console.WriteLine("Dog barks");
}

class Cat : Animal
{
    public override void Meow() => Console.WriteLine("Cat meows");
}

// Animal a = new(); a.Speak(); // Animal speaks
// Cat c = new(); c.Speak(); // Cat meows
// Animal a2 = new Cat(); a2.Speak(); // Cat speaks
```

## Абстрактные классы и методы

Абстрактные классы не могут быть созданы напрямую, и они могут содержать как реализованные, так и абстрактные методы. Абстрактные методы должны быть переопределены в производных классах.

```csharp
abstract class Shape
{
    public abstract double GetArea();
}

class Circle : Shape
{
    public double Radius { get; set; }

    public override double GetArea() => Math.PI * Radius * Radius;
}
```

## Интерфейсы

Интерфейсы определяют контракт, который должен быть реализован в классах. Класс может реализовать несколько интерфейсов. При названии интерфейсов принято использовать префикс `I` и необзятельно суффикс `able` (например, `IDrawable`, `IShape`).

```csharp
interface IDrawable
{
    void Draw();
}

class Square : IDrawable
{
    public void Draw() => Console.WriteLine("Drawing a square");
}

class Circle : IDrawable
{
    public void Draw() => Console.WriteLine("Drawing a circle");
}

class Triangle : IDrawable
{
    public void Draw() => Console.WriteLine("Drawing a triangle");
}

IDrawable[] shapes = { new Square(), new Circle(), new Triangle() };

foreach (var shape in shapes)
{
    shape.Draw();
}
```



