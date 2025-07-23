

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

var connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("Default");

using var conn = new SqlConnection();

string command = "select * from People";

using SqlDataAdapter adapter = new(command, conn);

DataTable people = new();

adapter.Fill(people);


