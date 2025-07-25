using CodeFirstApp.Data.Contexts;
using CodeFirstApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var optionsBuilder = new DbContextOptionsBuilder<AuthDbContext>();
optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));

using var context = new AuthDbContext(optionsBuilder.Options); 


context.Users.Add(new()
{
    Id = "723A1B3",
    Email = "test@gmail.com",
    Username = "Test",
    Password = "Test",
    Name = "Test",
    Surname = "Test"
});

context.SaveChanges();
