using System;
using System.Collections.Generic;

namespace DbFirst;

public partial class User
{
    public string Id { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool IsConfirmed { get; set; }
    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
