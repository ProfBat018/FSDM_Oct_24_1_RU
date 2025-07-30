using System;
using System.Collections.Generic;

namespace DbFirst;

public partial class Role
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
