namespace CodeFirstApp.Data.Models;

public class Role
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    
    public virtual ICollection<UserRole> UserRoles { get; set; }
}