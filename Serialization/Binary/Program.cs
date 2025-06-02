#region BinarySerializationExample

#region Serialization

using System.Runtime.Serialization.Formatters.Binary;
/*
#pragma warning disable SYSLIB0011

BinaryFormatter a = new();
using var fs = new FileStream("person.bin", FileMode.OpenOrCreate);

Person p1 = new()
{
    Name = "Elvin",
    SurName = "Azimov",
    Age = 23
};

a.Serialize(fs, p1);



#pragma warning restore SYSLIB0011
*/

#endregion

#region Deserialization
/*
BinaryFormatter a = new();
using var fs = new FileStream("person.bin", FileMode.OpenOrCreate);

#pragma warning disable SYSLIB0011
var person = a.Deserialize(fs) as Person;

Console.WriteLine(person.Name);
#pragma warning restore SYSLIB0011

*/
#endregion

// Атрибут, который обязательно нужен для бинарной сериализации
[Serializable] 
class Person
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public int Age { get; set; }
}



#endregion