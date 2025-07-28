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

#region Part1
// using var context = new AuthDbContext(optionsBuilder.Options); 


// context.Users.Add(new()
// {
//     Id = "723A1B3",
//     Email = "test@gmail.com",
//     Username = "Test",
//     Password = "Test",
//     Name = "Test",
//     Surname = "Test"
// });
//
// context.SaveChanges();

// var res = context.Users.Where(u => u.Email == "test@gmail.com");

#endregion

#region Part2

// using var context = new AuthDbContext(optionsBuilder.Options);

// нужно найти роли конкретного пользователя

// Lazy loading
/*
var userRoles = context.UserRoles
    .Where(ur => ur.User.Name == "Elvin")
    .Select(ur => ur.Role.Name)
    .ToList();

foreach (var userRole in userRoles)
{
    Console.WriteLine(userRole);
}
*/


#endregion

#region Part3

// using var context = new AuthDbContext(optionsBuilder.Options);
//
// var roles = context.UserRoles
//     .Include(ur => ur.User)
//     .Include(ur => ur.Role)
//     .Where(ur => ur.User.Name == "Elvin")
//     .Select(r => r.Role.Name)
//     .ToQueryString();

// Console.WriteLine(roles);

#endregion



#region Part4


using var context = new AuthDbContext(optionsBuilder.Options);

// var user = context.Users.FirstOrDefault(u => u.Name == "Elvin");
//
// context.Entry(user).Collection(u => u.UserRoles).Load();
//
// foreach (var userRole in user.UserRoles)
// {
//     context.Entry(userRole).Reference(ur => ur.Role).Load();
//     Console.WriteLine(userRole.Role.Name);
// }

var role = context.Roles.FirstOrDefault(r => r.Name == "AppAdmin");

context.Entry(role).Collection(r => r.UserRoles).Load();

foreach (var userRole in role.UserRoles)
{
    context.Entry(userRole).Reference(ur => ur.User).Load();

    Console.WriteLine(userRole.User.Name);
}


#endregion

