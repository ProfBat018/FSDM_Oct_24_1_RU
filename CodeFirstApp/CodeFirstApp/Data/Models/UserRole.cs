using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstApp.Data.Models;


public class UserRole
{
    public string UserId { get; set; }
    public string RoleId { get; set; }

    public virtual User User { get; set; }
    public virtual Role Role { get; set; }
}