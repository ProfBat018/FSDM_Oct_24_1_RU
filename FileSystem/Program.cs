

// Directory.CreateDirectory("/Users/wayne/Documents/Work/FSDM_Oct_24_1_RU/Test");


// var res = Directory.GetParent("/Users/wayne/Documents/Work/FSDM_Oct_24_1_RU/");
//
// Console.WriteLine("Files");
// foreach (var file in res.GetFiles())
// {
//     Console.WriteLine(file.Name);
// }
//
//
// Console.WriteLine("Directories");
// foreach (var dir in res.GetDirectories())
// {
//     Console.WriteLine(dir.Name);
// }
//
//

using System.Text;

using FileStream fs = new("elvin.txt", FileMode.OpenOrCreate);

string textToWrite = "Hello, Elvin!";

// var bytes = Encoding.UTF8.GetBytes(textToWrite);
//
// fs.Write(bytes, 7, bytes.Length - 7);

using StreamWriter sw = new(fs);
sw.Write(textToWrite);



