using System.ComponentModel.DataAnnotations;

namespace CodeFirstApp.Data.Models;


public class User
{

    public string Id { get; set; }
    
    public string Username { get; set; }
    
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string Password { get; set; }
    
    public string Email { get; set; }

    public bool IsConfirmed { get; set; } = false;

    public ICollection<UserRole> UserRoles { get; set; }
}