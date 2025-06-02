# Тема урока: Файлы

- Класс File
- Класс FileStream
- Класс FileInfo
- Класс Directory
- Класс StreamReader
- Класс StreamWriter

## Класс File

Класс File предоставляет методы для создания, копирования, удаления, перемещения и открытия файлов, а также для создания экземпляров FileStream.

### Пример использования класса File

```csharp
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "example.txt";

        // Создание файла и запись в него
        File.WriteAllText(filePath, "Hello, World!");

        // Чтение содержимого файла
        string content = File.ReadAllText(filePath);
        Console.WriteLine("Содержимое файла: " + content);

        // Копирование файла
        string copyPath = "copy_example.txt";
        File.Copy(filePath, copyPath, true);

        // Удаление файла
        File.Delete(filePath);
        Console.WriteLine("Файл удален.");
    }
}
```

### Описание методов класса File

- `WriteAllText(string path, string contents)`: Создает файл, записывает в него текст и закрывает файл.
- `ReadAllText(string path)`: Читает все текстовые данные из файла и возвращает их в виде строки.
- `Copy(string sourceFileName, string destFileName, bool overwrite)`: Копирует файл из одного места в другое.
- `Delete(string path)`: Удаляет указанный файл.
- `Exists(string path)`: Проверяет, существует ли указанный файл.
- `Move(string sourceFileName, string destFileName)`: Перемещает файл из одного места в другое.
- `Open(string path, FileMode mode)`: Открывает файл с указанным режимом доступа.

## Класс FileStream

Класс FileStream предоставляет методы для чтения и записи данных в файл с использованием потоков. Он позволяет работать с файлами на более низком уровне, чем класс File.

### Пример использования класса FileStream

```csharp
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "example.txt";

        // Создание файла и запись в него с использованием FileStream
        using FileStream fs = new FileStream(filePath, FileMode.Create);

            byte[] data = System.Text.Encoding.UTF8.GetBytes("Hello, World!");
            fs.Write(data, 0, data.Length);


        // Чтение содержимого файла с использованием FileStream
        using FileStream fs = new FileStream(filePath, FileMode.Open);

            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, data.Length);
            string content = System.Text.Encoding.UTF8.GetString(data);
            Console.WriteLine("Содержимое файла: " + content);


        // Удаление файла
        File.Delete(filePath);
        Console.WriteLine("Файл удален.");
    }
}
```

В нем есть enum-ы FileMode, FileAccess и FileShare, которые определяют режимы доступа к файлу, типы операций с файлом и способы совместного использования файла между потоками.

#### FileMode
- `Create`: Создает новый файл. Если файл уже существует, он будет перезаписан.
- `Open`: Открывает существующий файл. Если файл не существует, будет вызвано исключение.
- `Append`: Открывает файл для добавления данных. Если файл не существует, будет создан новый файл.
- `Truncate`: Открывает существующий файл и обрезает его до нулевой длины. Если файл не существует, будет вызвано исключение.
- `OpenOrCreate`: Открывает файл, если он существует, или создает новый файл, если он не существует.
- `CreateNew`: Создает новый файл. Если файл уже существует, будет вызвано исключение.

В использовании `Open` и `Truncate` вы не увидите разницу в `FileStream`. 

#### FileAccess
- `Read`: Позволяет только чтение из файла.
- `Write`: Позволяет только запись в файл.
- `ReadWrite`: Позволяет как чтение, так и запись в файл.

Данный enum будет не нужен, если вы используете свою машину, так как по умолчанию используется `ReadWrite`. Но если вы используете сервер или у вас стоит `(User Access Control)`, то вам нужно будет явно указывать режим доступа к файлу. 

#### FileShare
- `None`: Запрещает совместное использование файла. Другие процессы не могут открыть файл, пока он открыт в текущем процессе.
- `Read`: Позволяет другим процессам читать файл, пока он открыт в текущем процессе.
- `Write`: Позволяет другим процессам записывать в файл, пока он открыт в текущем процессе.
- `ReadWrite`: Позволяет другим процессам читать и записывать в файл, пока он открыт в текущем процессе.
- `Delete`: Позволяет другим процессам удалять файл, пока он открыт в текущем процессе.
- `Inheritable`: Позволяет другим процессам открывать файл с наследуемыми правами доступа.

## Класс FileInfo
Класс FileInfo предоставляет методы и свойства для работы с файлами, такие как получение информации о файле, изменение атрибутов файла и т.д. Он является оберткой над классом File и предоставляет более удобный интерфейс для работы с файлами.
### Пример использования класса FileInfo

```csharp
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "example.txt";

        // Создание файла и запись в него
        File.WriteAllText(filePath, "Hello, World!");

        // Создание экземпляра FileInfo
        FileInfo fileInfo = new FileInfo(filePath);

        // Получение информации о файле
        Console.WriteLine("Имя файла: " + fileInfo.Name);
        Console.WriteLine("Полный путь: " + fileInfo.FullName);
        Console.WriteLine("Размер файла: " + fileInfo.Length + " байт");
        Console.WriteLine("Дата создания: " + fileInfo.CreationTime);

        // Удаление файла
        fileInfo.Delete();
        Console.WriteLine("Файл удален.");
    }
}
```

## Класс Directory
Класс Directory предоставляет методы для создания, удаления и получения информации о каталогах. Он позволяет работать с каталогами на более высоком уровне, чем класс File.
### Пример использования класса Directory

```csharp
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string dirPath = "exampleDir";

        // Создание каталога
        Directory.CreateDirectory(dirPath);
        Console.WriteLine("Каталог создан: " + dirPath);

        // Получение информации о каталоге
        DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
        Console.WriteLine("Имя каталога: " + dirInfo.Name);
        Console.WriteLine("Полный путь: " + dirInfo.FullName);
        Console.WriteLine("Дата создания: " + dirInfo.CreationTime);

        // Удаление каталога
        Directory.Delete(dirPath, true);
        Console.WriteLine("Каталог удален.");
    }
}
```

Запомните, едиственное место, где невозможно заменить рекурсию на цикл - это простотр и удаление содержимого каталога. То есть если вы хотите удалить каталог с его содержимым, то вам нужно использовать рекурсию. 

## Класс StreamReader и StreamWriter

Классы StreamReader и StreamWriter предоставляют методы для чтения и записи текстовых данных в файлы с использованием потоков. Они позволяют работать с файлами на более высоком уровне, чем класс FileStream, и обеспечивают удобный интерфейс для работы с текстовыми данными.

### Пример использования класса StreamReader и StreamWriter

```csharp
using System;
using System.IO;

using var fs = new FileStream("example.txt", FileMode.Create);
using var writer = new StreamWriter(fs);
writer.WriteLine("Hello, World!");
using var reader = new StreamReader(fs);
string content = reader.ReadToEnd();
Console.WriteLine("Содержимое файла: " + content);
