using DbFirst;
using Microsoft.EntityFrameworkCore;


using var context = new AuthDbOctContext();

// Найти всех пользователей с ролью "AppAdmin"

var role = context.Roles
    .FirstOrDefault(r => r.Name == "AppAdmin");

context.Entry(role).Collection(r => r.Users).Load();

foreach (var user in role.Users)
{
    Console.WriteLine(user.Name);
}
