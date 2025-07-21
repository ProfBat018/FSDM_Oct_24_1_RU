using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


var connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("Default");

using SqlConnection conn = new(connectionString);

#region ExecuteReader

//var command = new SqlCommand("select * from People", conn);

//conn.Open();

//SqlDataReader reader = command.ExecuteReader(); // Нужен для select команд, которые возвращают не скалярные значения. 

//while (reader.Read())
//{
//    Console.WriteLine($"Id: {reader[0]}, Name: {reader[1]}");
//}

#endregion


#region ExecuteScalar

//var command = new SqlCommand("select Max(Age) from People", conn);
//conn.Open();

//var res = command.ExecuteScalar();
//Console.WriteLine(res);


#endregion


#region ExecuteNonQuery

var command = new SqlCommand("insert into People values(N'Aziz', N'Babayev', 17);", conn);

conn.Open();

var res = command.ExecuteNonQuery();

Console.WriteLine(res);


#endregion
