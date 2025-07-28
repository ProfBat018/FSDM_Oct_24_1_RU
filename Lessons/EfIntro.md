# Тема урока: Введение в EntityFrameworkCore

Как я сказал на прошлом уроке, для работы с MSSQL Server у нас есть один драйвер ODBC. EF Core по сути это обертка над ADO.NET, которая позволяет мне делать Mapping.

`Mapping` - это связывание классов(как сущностей, то есть бизнес модель программы) с таблицами в SQL. В контексте фрэймворка, у нас есть возможность миграций и переноса БД в код.

Сам по себе чистый EF CORE - это не про миграции и db scaffolding, а про запросы в SQL. Для этого используется `LINQ to Entities`. Если в `LINQ to Objects` использовались функции расишрения для `IEnumerable`, то здесь уже они писались под `IQuerable`. Запомните этот интерфейс, так как он вам очень сильно понадобится.

При работе с EF Core мы используем 4 библиотеки. Давайте разберем каждый из них.

1. Microsoft.EntityFrameworkCore
2. Microsoft.EntityFrameworkCore.SqlServer
3. Microsoft.EntityFrameworkCore.Design
4. Microsoft.EntityFrameworkCore.Tools

**Первый** нужен нам для базовых классов внутри EF Core, таких как DbContext, DbContextOptions, IEntityTypeConfiguration и т.д.

**Второй** нам для того чтобы мы дали знать конфигурационному методу знать о том, что мы работаем с SqlServer. Вместо этого пакета могут быть и другие БД, в зависимости от вашей работы, например PostgreSql или же SqlIte, Azure Cosmos Db. Раньше была поддержка Oracle, но ее уже нет.

**Третий** пакет нужен для работы с миграциями и scaffolding-ами. Без этого пакета сделать миграцию не получится.

**Последний** пакет позволяет добавить EF команды для для Package Manager Console в Visual Studio. Абсолютно бесплозеный пакет, который я каждый раз по привычке пишу. Хотя я с 2019 года категорически протиа PMC и использую только `dotnet cli`. Если по какой-то очень волшебной и никому не понятной причине вы все установили но у вас нет dotnet ef команды в консоли, то нужно установить его глобально на весь компьютер.

```bash
dotnet tool install --global dotnet-ef
```

# Работа с сущностями

Мы создаем классы, которые должны описывать наши таблицы в БД. Такие классы являются сущностями нашего приложения или же бизнес моделью. Очень важно понимать что эти классы не должны заниматься логикой. Их работа заключается только в описании БД и работой с ней.

# Что такое миграции и зачем они нам ?

Мы должны понять, что наша задача это построить мост между нашим приложением и базой данных. Если вы начали проект с нуля и у вас тоже проблемы с SQL как у меня, то вы точно захотите создать сущности и перевести их в SQL. Для этого вам нужны миграции.

Из главных вопросов студентов, остается следующий момент:

Как описывать DDL базы, если мы просто создаем класс ?

На самом деле все очень просто, у нас есть два варианта:

1. Data Annotations
2. Fluent API

**Первый** вариант это использование атрибутов перед свойством. Вот пример такого класса:

```csharp
class Student
{
    [Key]
    public string Id {get; set;}

    [Required]
    [MaxLength(30)]
    public string Email {get; set;}

    [ForeignKey]
    public string PersonId {get; set;}

    public Person Person {get; set;}
}
```

Эти атрибуты - это пример дата аннотаций. Дело в том, что данный пример абсолютно нарушает принципе который я написал ранее про сущности. `SRP` нарушен, я дал поведение сущности прямо при описании.

**Второй метод** в таком случае именно то, что нам надо. При описании класса `[DatabaseName]DbContext` мы используем метод OnModelCreating, который переопределяем из базового класса DbContext. Тут стоит остановится и ответить на несколько вопросов.

1. Зачем нам нужен класс DbContext
2. Что в нем должно быть
3. Как работает fluentApi

Класс dbContext нам нужен для описания базы данных, если в сущностях я описывал таблицы, то тут описываю из каких таблиц состоит база данных и как она должна выглядеть. Также стоит отметить что данный класс IDisposable и именно он при обращении к нужному DbSet делает запрос и выдает мне результат. При это неважно он делает запрос в БД или оперативку.

В данном классе мы должны в первую очередь унаследоваться от класса DbContext, затем нам надо прописать нужные нам dbSet-ы, то есть описать какие у нас есть таблицы. Далее нам надо написать конструктор, в зависимости от того как вы собираетесь передавать в этот класс опции подключения и собираетесь ли вообще это делать. И уже под конец вы можете переопределить метод `OnModelCrating` для того чтобы дать поведение вашим таблицам. Давайте по. порядку разберем момент с передачей опций в БД.

```csharp
class UserDbContext : DbContext
{
    public DbSet<User> Users {get; set;} // название обязательно в множественном числе
    public DbSet<Role> Roles {get; set;}
    public DbSet<UserRole> UserRoles {get; set;}

    public UserDbContext()
    {

    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Ваша строка подключения");
    }
}
```

В этом примере у меня есть абсолютно пустой конструктор, метод `OnConfiguring`, который даст настройки подключения к БД когда надо будет и тут уже неважно вы делаете `dotnet ef database update` или просто создаете экзамепляр контекста. Данный метод отработает когда надо будет. Его минус в том, что строка подключения остается открытой и даже если вы внутри данного метода пропишете строку из `appsettings.json` вы уже не сможете выдавать настройки извне, что очень часто нужно бывает когда вы в одном решении используете несколько проектов.

Если коротко сделать резюме, то вам нужно понять следующее:

1. Если у вас один проект и вы не делите его на части, пишите косруктор без параметров и в `OnConfiguring` достаете строку из `appsettings.json`. Это будет самый безопастный и правильный метод в данном случае.
2. Если у вас крупный проект и вы для `Persistence` создали отдельный `Class Library`, то будьте добры напишите конструктор с **DbContextOptionsBuilder**. В таком случае у вас увеличивается работа но все выглядит красиво и без метода `OnConfiguring`.

После того как вы описали БД, вам уже нужно сделать миграцию. Миграция - это файлы с методами Up и Down, которые могут перетаскивать вас по истории ваших изменений в БД. Скажем так подобие репозитория, который можно откатывать. Чтобы создать миграцию в обычном проекте мы пишем:

```bash

dotnet ef migrations add `migration name`

```

Если у вас разделение на проекты то:

```bash

dotnet ef migrations add `migration name` --project=projectwithContext --startup-project=projectWithMain -o Migrations
```

Здесь уже в --project передаете проект в котором у вас назодится ваш DbContext, в --stratup-project передаете основной проект который запускается, -o Migrations значит что он сохранит все миграции в папке Migrations в вашем проекте. где DbContext, если это не написать данная папка будет в вашем основном проекте.

# Список LINQ методов

# 📘 LINQ Методы в EF Core

Entity Framework Core (EF Core) использует LINQ (Language Integrated Query) для построения запросов к базе данных. Ниже приведён список основных LINQ-методов с пояснением и примерами.

---

## 🔎 Фильтрация

### `Where`

Фильтрует записи по условию.

```csharp
var adults = context.Users.Where(u => u.Age >= 18);
```

### `Any`

Проверяет, удовлетворяет ли хотя бы один элемент условию.

```csharp
bool hasAdmin = context.Users.Any(u => u.Role == "Admin");
```

### `All`

Проверяет, удовлетворяют ли **все** элементы условию.

```csharp
bool allConfirmed = context.Users.All(u => u.IsConfirmed);
```

---

## 🎯 Поиск

### `First` / `FirstOrDefault`

Возвращает первый элемент, соответствующий условию.

```csharp
var user = context.Users.FirstOrDefault(u => u.Email == email);
```

### `Single` / `SingleOrDefault`

Ожидает **только один** элемент. Бросает исключение, если найдено больше одного.

```csharp
var admin = context.Users.SingleOrDefault(u => u.Role == "Admin");
```

---

## 📊 Проекция (выбор данных)

### `Select`

Выбирает нужные поля.

```csharp
var names = context.Users.Select(u => u.Name);
```

### `SelectMany`

Применяется к коллекциям (например, навигационным свойствам).

```csharp
var roles = context.Users.SelectMany(u => u.UserRoles);
```

---

## 🔢 Сортировка

### `OrderBy`, `OrderByDescending`

Сортировка по возрастанию или убыванию.

```csharp
var sorted = context.Users.OrderBy(u => u.Name);
```

### `ThenBy`, `ThenByDescending`

Сортировка по вторичному критерию.

```csharp
var sorted = context.Users
    .OrderBy(u => u.Role)
    .ThenByDescending(u => u.Name);
```

---

## 🔁 Группировка

### `GroupBy`

Группирует элементы по ключу.

```csharp
var grouped = context.Users.GroupBy(u => u.Role);
```

---

## 📌 Агрегация

### `Count`, `LongCount`

Количество элементов.

```csharp
int total = context.Users.Count();
```

### `Sum`, `Average`, `Min`, `Max`

Работают с числовыми значениями.

```csharp
var avgAge = context.Users.Average(u => u.Age);
```

---

## 📃 Страницы и диапазоны

### `Skip`, `Take`

Пропустить/взять определенное количество элементов.

```csharp
var page = context.Users.Skip(10).Take(10);
```

---

## 🔄 Объединение

### `Join`

Соединяет два источника по ключу.

```csharp
var result = context.Users.Join(
    context.Orders,
    user => user.Id,
    order => order.UserId,
    (user, order) => new { user.Name, order.Total }
);
```

### `GroupJoin`

Группирует соединенные записи.

```csharp
var result = context.Users.GroupJoin(
    context.Orders,
    u => u.Id,
    o => o.UserId,
    (u, orders) => new { u.Name, Orders = orders }
);
```

---

## 🔁 Прочее

### `Distinct`

Удаляет дубликаты.

```csharp
var emails = context.Users.Select(u => u.Email).Distinct();
```

### `Contains`

Проверка на наличие значения.

```csharp
var users = context.Users.Where(u => ids.Contains(u.Id));
```

### `DefaultIfEmpty`

Используется с `GroupJoin` для left join.

```csharp
var result = context.Users
    .GroupJoin(context.Orders, u => u.Id, o => o.UserId,
        (u, orders) => new { u, orders = orders.DefaultIfEmpty() });
```

---

⚠️ **Важно:** Некоторые методы (`ToList`, `Count`, `FirstOrDefault`) могут вызывать немедленное выполнение запроса. Используйте их в конце LINQ-цепочек.

Из всего что я написал сверху вам нужно знать 2 вещи чтобы не писать на Ef Core как обезьяна с револьвером. 

1. Используйте проекцию 
2. Не пишите Tolist() там где вам придет это в голову. Delayed executing в помощь

Давайте предпложим что у меня есть таблица с людьми и мне нужны только имена людей у которых возраст больше 35. 

```csharp

using var context = new UsersDbContext 

var res = context.People.Where(p => p.Age > 35);
```

данный код вернет вам IQuerable, из Person. Но мне нужно оттуда только Name. Я вам уже показывал эту тему на SQL. Конечно же вы знаете разницу между запросами 

```sql

select * from People 
select Name from People

```

Второй запрос намного быстрее и использует меньше памяти. Так вот проекция - это способ настраивать этот самый Select в LINQ. 

```csharp

using var context = new UsersDbContext 

var res = context.People.Where(p => p.Age > 35).Select(p => p.Name);

foreach(var name in res) 
{
    Console.WriteLine(name);
}
```

Так он вернет нам `IQuerable<string>`

```csharp

using var context = new UsersDbContext 

var res = context.People.Where(p => p.Age > 35).Select(p => new 
{
    Name = p.Name
});

foreach(var p in res) 
{
    Console.WriteLine(p.Name);
}
```

а так он вернет IQuerable из анонимного типа данных в котором есть свойство Name. 

Оба варианта выдадут вам такой запрос **select Name from People** 

если вы такой же любопытный как и я, то должны знать что у DbSet который мы использкем есть метод `ToQueryString` который покажет во что превращается ваш LINQ запрос. Еще вы удивитесь тому, что Ef Core автоматически использует транзакции. 

Следующее уточнение, вы не работаете сразу с IEnumerable, по факту на это моменте

 ```csharp
using var context = new UsersDbContext 

var res = context.People.Where(p => p.Age > 35).Select(p => new 
{
    Name = p.Name,
    Suranme = p.Surname,
    FullName = $"{Name}\t{Surname}"
});



```

у вас еще нет никаких данных. 

В переменную res, записываете query, то есть сам sql запрос. Этот запрос не выолняется сразу. Он выполнится тогда, когда вы обратитесь к этой переменной. 

eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJmMzdhYmM0MC1jODMyLTQ5Y2UtOWQ5YS1mNmMzNzVlNzgzMTYiLCJhdWQiOlsibXMubXkuZ292LmF6Il0sImlzcyI6ImF1dGgubXkuZ292LmF6IiwidHlwZSI6ImFjY2Vzc190b2tlbiIsImp0aSI6ImQzYTRkM2QwLTUyOTItNDA1MS1hZDE2LTY2MzE2ZTg5OWQ4MCIsImV4cCI6MTc1MzYwNzAyMn0.2-0q1GX4Q5uhTX7OXdi-P4Gjy4GbTw7kl-t7i6SenXo

"eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJmMzdhYmM0MC1jODMyLTQ5Y2UtOWQ5YS1mNmMzNzVlNzgzMTYiLCJhdWQiOlsibXMubXkuZ292LmF6Il0sImlzcyI6ImF1dGgubXkuZ292LmF6IiwidHlwZSI6ImFjY2Vzc190b2tlbiIsImp0aSI6Ijc2MjNmY2FiLTIwMmQtNDg5MS1iYTA2LWE2ZDViNDI0YWIzMyIsImV4cCI6MTc1MzYwNzE5NH0.sIH-wZ6WTKeImosHhDkjQAJ1c7sC1nv-T9llM41w_AU"
